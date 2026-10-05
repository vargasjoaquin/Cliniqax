using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<OperationResult> LoginAsync(string username, string password);
        void Logout();
        Task<OperationResult> SendPasswordResetAsync(string identity);
    }
}
