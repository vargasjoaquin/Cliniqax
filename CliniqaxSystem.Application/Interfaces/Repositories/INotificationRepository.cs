using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetPendingNotificationsAsync(DateTime upToDate);
        Task<IEnumerable<Notification>> GetHistoryAsync(DateTime start, DateTime end, int? channelId = null, int? statusId = null);
        Task<Notification> GetByIdAsync(int id);
        Task AddAsync(Notification notification);
        void Update(Notification notification);

        // Plantillas y reglas
        Task<IEnumerable<NotificationTemplate>> GetTemplatesAsync();
        Task<NotificationTemplate?> GetTemplateByCodeAndChannelAsync(string code, int channelId);
        void UpdateTemplate(NotificationTemplate template);
        Task<IEnumerable<ReminderRuleConfig>> GetActiveReminderRulesAsync();
    }
}
