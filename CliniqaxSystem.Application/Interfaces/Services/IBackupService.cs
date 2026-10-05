using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IBackupService
    {
        Task<OperationResult> ExecuteAutomaticBackupAsync();
    }
}
