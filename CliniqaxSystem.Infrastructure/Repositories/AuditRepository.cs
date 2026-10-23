using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class AuditRepository(ApplicationDbContext context) : IAuditRepository
    {
        public async Task AddLogAsync(AuditLog log)
        {
            await context.AuditLogs.AddAsync(log);
        }

        public async Task<IEnumerable<AuditLog>> GetLogsAsync(DateTime start, DateTime end, string? username = null, string? action = null, string? entityName = null)
        {
            DateTime adjustedEnd = end.Date.AddDays(1);

            var query = context.AuditLogs
                .AsNoTracking()
                .Where(a => a.Timestamp.Date >= start.Date && a.Timestamp.Date <= adjustedEnd);

            if (!string.IsNullOrWhiteSpace(username))
                query = query.Where(a => a.Username.Contains(username.Trim()));

            if (!string.IsNullOrWhiteSpace(action))
                query = query.Where(a => a.Action == action.Trim());

            if (!string.IsNullOrWhiteSpace(entityName))
                query = query.Where(a => a.EntityName == entityName.Trim());

            return await query.OrderByDescending(a => a.Timestamp).Take(200).ToListAsync();
        }

        public async Task AddBackupLogAsync(BackupExecutionLog log)
        {
            await context.BackupExecutionLogs.AddAsync(log);
        }

        public async Task<IEnumerable<BackupExecutionLog>> GetBackupLogsAsync(int count = 50)
        {
            return await context.BackupExecutionLogs
                .AsNoTracking()
                .OrderByDescending(b => b.ExecutedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}
