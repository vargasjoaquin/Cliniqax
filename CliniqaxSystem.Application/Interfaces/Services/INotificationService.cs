using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Notification;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task<OperationResult> QueueNotificationAsync(int channelId, string recipient, string templateCode, IDictionary<string, string> tokens, int? appointmentId = null, int? patientId = null, DateTime? scheduledAt = null);
        Task<OperationResult> ProcessPendingNotificationsQueueAsync();
        Task<OperationResult> RetryNotificationAsync(int notificationId);
        Task<IEnumerable<NotificationDto>> GetNotificationHistoryAsync(DateTime start, DateTime end, int? channelId = null, int? statusId = null);

        // Administración de Plantillas y Reglas
        Task<IEnumerable<NotificationTemplateDto>> GetTemplatesAsync();
        Task<OperationResult> UpdateTemplateAsync(NotificationTemplateUpdateDto dto);
        Task<IEnumerable<ReminderRuleConfigDto>> GetReminderRulesAsync();
        Task<OperationResult> ToggleReminderRuleAsync(int ruleId);
    }
}
