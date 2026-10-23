using CliniqaxSystem.Application.DTOs.Audit;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task LogActionAsync(string action, string entityName, string? entityId = null, string? details = null);
        Task<IEnumerable<AuditLogDto>> GetAuditLogsAsync(DateTime start, DateTime end, string? username = null, string? action = null, string? entityName = null);
        Task<IEnumerable<BackupExecutionLogDto>> GetBackupLogsAsync(int count = 50);
    }
}
