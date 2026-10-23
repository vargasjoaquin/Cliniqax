using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IWhatsAppService
    {
        Task<OperationResult> SendMessageAsync(string toPhoneNumber, string messageText);
    }
}
