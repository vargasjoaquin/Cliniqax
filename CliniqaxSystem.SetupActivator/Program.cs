using System.Management;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CliniqaxSystem.SetupActivator
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Cliniqax.SetupActivator.exe --activate "CUIT" "KEY" "SERVER_URL" "ERROR_FILE_PATH"
            if (args.Length >= 4 && args[0] == "--activate")
            {
                string cuit = args[1];
                string licenseKey = args[2];
                string licenseServerUrl = args[3];
                string errorFilePath = args.Length >= 5 ? args[4] : Path.Combine(Path.GetTempPath(), "cliniqax_activation_error.txt");

                var (success, message) = ExecuteActivationAsync(cuit, licenseKey, licenseServerUrl).GetAwaiter().GetResult();

                if (success)
                {
                    Environment.Exit(0); // Código 0 = Éxito para el instalador
                }
                else
                {
                    try { File.WriteAllText(errorFilePath, message, Encoding.UTF8); } catch { }
                    Environment.Exit(1); // Código 1 = Bloquear instalación
                }
                return;
            }

            MessageBox.Show("Este asistente de activación está diseñado para ser ejecutado por el instalador del sistema.",
                "Cliniqax Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static async Task<(bool Success, string Message)> ExecuteActivationAsync(string cuit, string licenseKey, string serverUrl)
        {
            try
            {
                string hwid = GetMachineHardwareId();
                string machine = Environment.MachineName;

                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (m, cert, chain, err) => true
                };

                using var http = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };

                var response = await http.PostAsJsonAsync($"{serverUrl.TrimEnd('/')}/api/licenses/activate", new
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
                        var error = await response.Content.ReadFromJsonAsync<JsonElement>();
                        string message = error.TryGetProperty("message", out var m) ? m.GetString()! : "La activación fue rechazada por el servidor.";
                        
                        return (false, message);
                    }
                    catch
                    {
                        return (false, $"Error del servidor (HTTP {(int)response.StatusCode})");
                    }
                }

                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string signedToken = result.GetProperty("signedToken").GetString()!;

                // Guardar encriptado con Windows DPAPI
                string commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string folder = Path.Combine(commonAppData, "CliniqaxSystem");
                Directory.CreateDirectory(folder);

                string file = Path.Combine(folder, "license.dat");
                byte[] rawBytes = Encoding.UTF8.GetBytes(signedToken);
                byte[] encBytes = ProtectedData.Protect(rawBytes, null, DataProtectionScope.LocalMachine);

                await File.WriteAllBytesAsync(file, encBytes);
                return (true, "Activación aprobada exitosamente.");
            }
            catch (Exception ex)
            {
                return (false, $"No se pudo comunicar con el servidor ({serverUrl}):\n{ex.Message}");
            }
        }

        private static string GetMachineHardwareId()
        {
            var builder = new StringBuilder();
            
            builder.Append(GetWmiProperty("Win32_Processor", "ProcessorId"));
            builder.Append(GetWmiProperty("Win32_BaseBoard", "SerialNumber"));
            builder.Append(GetWmiProperty("Win32_DiskDrive", "SerialNumber"));

            string source = builder.ToString();
            
            if (string.IsNullOrWhiteSpace(source))
                source = Environment.MachineName + Environment.UserName + Environment.OSVersion;

            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(source));
            return Convert.ToHexString(hash);
        }

        private static string GetWmiProperty(string wmiClass, string property)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher($"SELECT {property} FROM {wmiClass}");
                
                foreach (var item in searcher.Get())
                {
                    var value = item[property]?.ToString();
                    
                    if (!string.IsNullOrWhiteSpace(value)) 
                        return value.Trim();
                }
            }
            catch 
            {
            }
            return string.Empty;
        }
    }
}