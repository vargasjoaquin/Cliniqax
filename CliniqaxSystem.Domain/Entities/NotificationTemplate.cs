using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class NotificationTemplate : BaseEntity
    {
        public string Code { get; set; } = null!;
        public int ChannelId { get; set; }
        public virtual NotificationChannel Channel { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set; }
    }
}
