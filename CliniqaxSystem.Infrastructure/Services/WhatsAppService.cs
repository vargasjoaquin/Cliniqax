using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.Configuration;
using CliniqaxSystem.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net.Http.Json;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class WhatsAppService(IOptions<WhatsAppSettings> options, HttpClient httpClient) : IWhatsAppService
    {
        private readonly WhatsAppSettings _settings = options.Value;

        public async Task<OperationResult> SendMessageAsync(string toPhoneNumber, string messageText)
        {
            if (string.IsNullOrWhiteSpace(toPhoneNumber))
                return OperationResult.Failure("Número telefónico de destino requerido.");

            if (string.IsNullOrWhiteSpace(messageText))
                return OperationResult.Failure("El cuerpo del mensaje no puede estar vacío.");

            string cleanNumber = new string(toPhoneNumber.Where(char.IsDigit).ToArray());

            // 1. Modo Simulado
            if (!_settings.Enabled || _settings.Provider.Equals("Simulated", StringComparison.OrdinalIgnoreCase))
            {
                Debug.WriteLine($"[SIMULACION WHATSAPP] -> Destino: {cleanNumber} | Mensaje:\n{messageText}");
                await Task.Delay(100);
                return OperationResult.Ok($"WhatsApp simulado enviado a {cleanNumber}.");
            }

            // 2. Modo Producción
            try
            {
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = cleanNumber,
                    type = "text",
                    text = new { body = messageText }
                };

                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _settings.ApiToken);

                string endpoint = $"{_settings.ApiUrl.TrimEnd('/')}/{_settings.PhoneNumberId}/messages";
                var response = await httpClient.PostAsJsonAsync(endpoint, payload);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    return OperationResult.Failure($"Fallo del proveedor WhatsApp (HTTP {(int)response.StatusCode}): {error}");
                }

                return OperationResult.Ok("WhatsApp despachado exitosamente.");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error de conexión con proveedor WhatsApp: {ex.Message}");
            }
        }
    }
}
