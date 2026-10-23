using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IAuditRepository
    {
        Task AddLogAsync(AuditLog log);
        Task<IEnumerable<AuditLog>> GetLogsAsync(DateTime start, DateTime end, string? username = null, string? action = null, string? entityName = null);
        Task AddBackupLogAsync(BackupExecutionLog log);
        Task<IEnumerable<BackupExecutionLog>> GetBackupLogsAsync(int count = 50);
    }
}
