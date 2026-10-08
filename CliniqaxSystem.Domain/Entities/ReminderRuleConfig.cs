using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class ReminderRuleConfig : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int AdvanceHours { get; set; }

        public int ChannelId { get; set; }
        public virtual NotificationChannel Channel { get; set; } = null!;

        public int TemplateId { get; set; }
        public virtual NotificationTemplate Template { get; set; } = null!;

        public bool IsEnabled { get; set; } = true;
    }
}
