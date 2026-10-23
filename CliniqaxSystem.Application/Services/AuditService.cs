using AutoMapper;
using CliniqaxSystem.Application.DTOs.Audit;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Services
{
    public class AuditService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper) : IAuditService
    {
        public async Task LogActionAsync(string action, string entityName, string? entityId = null, string? details = null)
        {
            var log = new AuditLog
            {
                UserId = currentUserService.UserId,
                Username = currentUserService.Username,
                UserRole = currentUserService.RoleName,
                Action = action.Trim().ToUpper(),
                EntityName = entityName.Trim(),
                EntityId = entityId,
                Details = details?.Trim(),
                IpAddress = Environment.MachineName,
                Timestamp = DateTime.UtcNow
            };

            await unitOfWork.AuditLogs.AddLogAsync(log);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<AuditLogDto>> GetAuditLogsAsync(DateTime start, DateTime end, string? username = null, string? action = null, string? entityName = null)
        {
            var logs = await unitOfWork.AuditLogs.GetLogsAsync(start, end, username, action, entityName);
            return mapper.Map<IEnumerable<AuditLogDto>>(logs);
        }

        public async Task<IEnumerable<BackupExecutionLogDto>> GetBackupLogsAsync(int count = 50)
        {
            var backupLogs = await unitOfWork.AuditLogs.GetBackupLogsAsync(count);
            return mapper.Map<IEnumerable<BackupExecutionLogDto>>(backupLogs);
        }
    }
}