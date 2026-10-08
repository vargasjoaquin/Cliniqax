using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class NotificationRepository(ApplicationDbContext context) : INotificationRepository
    {
        public async Task<IEnumerable<Notification>> GetPendingNotificationsAsync(DateTime upToDate)
        {
            return await context.Notifications
                .Include(n => n.Channel)
                .Include(n => n.Appointment)
                .ThenInclude(a => a!.Patient)
                .Include(n => n.Appointment)
                .ThenInclude(a => a!.Professional)
                .Include(n => n.Appointment)
                .ThenInclude(a => a!.Specialty)
                .Where(n => (n.StatusId == NotificationStatusConstants.PENDING || n.StatusId == NotificationStatusConstants.RETRYING)
                         && n.ScheduledAt <= upToDate
                         && n.RetryCount < n.MaxRetryCount)
                .OrderBy(n => n.ScheduledAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetHistoryAsync(DateTime start, DateTime end, int? channelId = null, int? statusId = null)
        {
            var query = context.Notifications
                .AsNoTracking()
                .Include(n => n.Channel)
                .Include(n => n.Status)
                .Include(n => n.Patient)
                .Where(n => n.ScheduledAt.Date >= start.Date && n.ScheduledAt.Date <= end.Date);

            if (channelId.HasValue && channelId > 0)
                query = query.Where(n => n.ChannelId == channelId.Value);

            if (statusId.HasValue && statusId > 0)
                query = query.Where(n => n.StatusId == statusId.Value);

            return await query.OrderByDescending(n => n.ScheduledAt).ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(int id)
        {
            return await context.Notifications
                .Include(n => n.Channel)
                .Include(n => n.Status)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(Notification notification)
        {
            await context.Notifications.AddAsync(notification);
        }

        public void Update(Notification notification)
        {
            context.Notifications.Update(notification);
        }

        public async Task<IEnumerable<NotificationTemplate>> GetTemplatesAsync()
        {
            return await context.NotificationTemplates
                .AsNoTracking()
                .Include(t => t.Channel)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<NotificationTemplate?> GetTemplateByCodeAndChannelAsync(string code, int channelId)
        {
            return await context.NotificationTemplates
                .FirstOrDefaultAsync(t => t.Code == code && t.ChannelId == channelId && t.IsActive);
        }

        public void UpdateTemplate(NotificationTemplate template)
        {
            template.LastUpdatedAt = DateTime.UtcNow;
            context.NotificationTemplates.Update(template);
        }

        public async Task<IEnumerable<ReminderRuleConfig>> GetActiveReminderRulesAsync()
        {
            return await context.ReminderRuleConfigs
                .AsNoTracking()
                .Include(r => r.Channel)
                .Include(r => r.Template)
                .Where(r => r.IsEnabled)
                .ToListAsync();
        }
    }
}
