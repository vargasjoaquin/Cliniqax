using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.License;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class LicenseManagerService : ILicenseManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverUrl;
        private readonly string? _rsaPublicKeyPem;
        private readonly string _primaryLicensePath;
        private readonly string _fallbackLicensePath;
        private readonly string _primaryLastSeenPath;
        private readonly string _fallbackLastSeenPath;

        public LicenseInformationDto? CurrentLicense { get; private set; }

        public LicenseManagerService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (m, cert, chain, err) => true
            };

            _httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
            _serverUrl = configuration["Licensing:ServerUrl"] ?? "http://licensekeysadminstrator.runasp.net";

            string? configuredKey = configuration["Licensing:RsaPublicKeyPem"];
            string keyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rsa_public_key.txt");

            if (string.IsNullOrWhiteSpace(configuredKey) && File.Exists(keyFile))
            {
                configuredKey = File.ReadAllText(keyFile);
            }

            _rsaPublicKeyPem = configuredKey;

            // Directorio protegido en ProgramData para Cliniqax
            string commonAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "CliniqaxSystem");
            EnsureFolderPermissions(commonAppData);
            _primaryLicensePath = Path.Combine(commonAppData, "license.dat");
            _primaryLastSeenPath = Path.Combine(commonAppData, "last_seen.dat");

            // Directorio fallback en AppData/Local
            string localAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CliniqaxSystem");
            Directory.CreateDirectory(localAppData);
            _fallbackLicensePath = Path.Combine(localAppData, "license.dat");
            _fallbackLastSeenPath = Path.Combine(localAppData, "last_seen.dat");
        }

        public async Task<OperationResult> ValidateInstalledLicenseAsync()
        {
            string? activeLicensePath = null;
            if (File.Exists(_primaryLicensePath))
                activeLicensePath = _primaryLicensePath;
            else if (File.Exists(_fallbackLicensePath))
                activeLicensePath = _fallbackLicensePath;

            if (activeLicensePath == null)
                return OperationResult.Failure("El sistema no se encuentra activado en esta computadora.");

            if (string.IsNullOrWhiteSpace(_rsaPublicKeyPem))
                return OperationResult.Failure("Clave pública de licenciamiento no configurada en el sistema.");

            try
            {
                byte[] encryptedBytes = await File.ReadAllBytesAsync(activeLicensePath);
                byte[] rawBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.LocalMachine);
                string tokenString = Encoding.UTF8.GetString(rawBytes);

                var (isValid, payload) = VerifyTokenSignature(tokenString);
                if (!isValid || payload == null)
                    return OperationResult.Failure("La credencial de activación está corrupta o fue alterada.");

                string currentHwid = HardwareFingerprint.GetMachineHardwareId();
                if (payload.HardwareId != currentHwid)
                    return OperationResult.Failure("Esta instalación fue copiada a otro equipo y no coincide con el hardware autorizado.");

                var clockCheck = await VerifyClockIntegrityAsync(payload.IssuedAt);
                if (!clockCheck.Success)
                    return clockCheck;

                int? daysRemaining = null;
                if (payload.ExpiresAt.HasValue)
                {
                    var span = payload.ExpiresAt.Value - DateTime.UtcNow;
                    daysRemaining = Math.Max(0, (int)Math.Ceiling(span.TotalDays));

                    if (payload.ExpiresAt.Value < DateTime.UtcNow)
                    {
                        CurrentLicense = new LicenseInformationDto
                        {
                            LicenseKey = payload.LicenseKey,
                            Cuit = payload.Cuit,
                            BusinessName = payload.BusinessName,
                            ExpiresAt = payload.ExpiresAt,
                            DaysRemaining = 0,
                            IsValid = false
                        };
                        return OperationResult.Failure("La licencia ha expirado.");
                    }
                }

                CurrentLicense = new LicenseInformationDto
                {
                    LicenseKey = payload.LicenseKey,
                    Cuit = payload.Cuit,
                    BusinessName = payload.BusinessName,
                    ExpiresAt = payload.ExpiresAt,
                    DaysRemaining = daysRemaining,
                    IsValid = true
                };

                await SaveLastSeenTimestampAsync(DateTime.UtcNow);
                return OperationResult.Ok($"Licencia válida: {payload.BusinessName}");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Error al verificar activación local: " + ex.Message);
            }
        }

        public async Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey)
        {
            try
            {
                string hwid = HardwareFingerprint.GetMachineHardwareId();
                string machine = Environment.MachineName;

                var response = await _httpClient.PostAsJsonAsync($"{_serverUrl.TrimEnd('/')}/api/licenses/activate", new
                {
                    LicenseKey = licenseKey.Trim().ToUpper(),
                    Cuit = cuit.Trim(),
                    HardwareId = hwid,
                    MachineName = machine,
                    OsVersion = Environment.OSVersion.ToString()
                });

                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var err = await response.Content.ReadFromJsonAsync<JsonElement>();
                        string msg = err.TryGetProperty("message", out var m) ? m.GetString()! : "Activación rechazada por el servidor.";
                        return OperationResult.Failure(msg);
                    }
                    catch
                    {
                        return OperationResult.Failure($"Fallo del servidor (HTTP {(int)response.StatusCode})");
                    }
                }

                var val = await response.Content.ReadFromJsonAsync<JsonElement>();
                string signedToken = val.GetProperty("signedToken").GetString()!;

                byte[] rawBytes = Encoding.UTF8.GetBytes(signedToken);
                byte[] encryptedBytes = ProtectedData.Protect(rawBytes, null, DataProtectionScope.LocalMachine);

                await SafeWriteLicenseFileAsync(encryptedBytes);
                await SaveLastSeenTimestampAsync(DateTime.UtcNow);

                return await ValidateInstalledLicenseAsync();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Error en la activación: " + ex.Message);
            }
        }

        private async Task<OperationResult> VerifyClockIntegrityAsync(DateTime issuedAtUtc)
        {
            DateTime now = DateTime.UtcNow;
            if (now < issuedAtUtc.AddMinutes(-5))
                return OperationResult.Failure("La fecha del equipo es anterior a la emisión de la licencia. Verifique la hora de Windows.");

            DateTime? lastSeen = await GetLastSeenTimestampAsync();
            if (lastSeen.HasValue && now < lastSeen.Value.AddMinutes(-5))
                return OperationResult.Failure("Se detectó una alteración en la fecha del sistema (Reloj retrasado). Corrija la hora.");

            return OperationResult.Ok();
        }

        private (bool IsValid, LicenseTokenPayloadDto? Payload) VerifyTokenSignature(string signedToken)
        {
            try
            {
                var parts = signedToken.Split('.');
                if (parts.Length != 2) return (false, null);

                byte[] payloadBytes = Convert.FromBase64String(parts[0]);
                byte[] signatureBytes = Convert.FromBase64String(parts[1]);

                using var rsa = RSA.Create();
                rsa.ImportFromPem(_rsaPublicKeyPem!);

                bool ok = rsa.VerifyData(payloadBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (!ok) return (false, null);

                string json = Encoding.UTF8.GetString(payloadBytes);
                var payload = JsonSerializer.Deserialize<LicenseTokenPayloadDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return (payload != null, payload);
            }
            catch
            {
                return (false, null);
            }
        }

        private async Task SafeWriteLicenseFileAsync(byte[] data)
        {
            try
            {
                if (File.Exists(_primaryLicensePath)) File.SetAttributes(_primaryLicensePath, FileAttributes.Normal);
                await File.WriteAllBytesAsync(_primaryLicensePath, data);
            }
            catch
            {
                if (File.Exists(_fallbackLicensePath)) File.SetAttributes(_fallbackLicensePath, FileAttributes.Normal);
                await File.WriteAllBytesAsync(_fallbackLicensePath, data);
            }
        }

        private static void EnsureFolderPermissions(string folder)
        {
            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                var di = new DirectoryInfo(folder);
                var ds = di.GetAccessControl();
                var sid = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                ds.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                di.SetAccessControl(ds);
            }
            catch { }
        }

        private async Task SaveLastSeenTimestampAsync(DateTime time)
        {
            try
            {
                byte[] raw = Encoding.UTF8.GetBytes(time.ToString("o"));
                byte[] enc = ProtectedData.Protect(raw, null, DataProtectionScope.LocalMachine);
                string path = Directory.Exists(Path.GetDirectoryName(_primaryLastSeenPath)) ? _primaryLastSeenPath : _fallbackLastSeenPath;
                await File.WriteAllBytesAsync(path, enc);
            }
            catch { }
        }

        private async Task<DateTime?> GetLastSeenTimestampAsync()
        {
            try
            {
                string? path = File.Exists(_primaryLastSeenPath) ? _primaryLastSeenPath : (File.Exists(_fallbackLastSeenPath) ? _fallbackLastSeenPath : null);
                if (path == null) return null;
                byte[] enc = await File.ReadAllBytesAsync(path);
                byte[] raw = ProtectedData.Unprotect(enc, null, DataProtectionScope.LocalMachine);
                if (DateTime.TryParse(Encoding.UTF8.GetString(raw), null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime dt))
                    return dt;
            }
            catch { }
            return null;
        }
    }
}
