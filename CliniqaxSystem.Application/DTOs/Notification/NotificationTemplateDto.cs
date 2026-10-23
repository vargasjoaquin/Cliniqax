namespace CliniqaxSystem.Application.DTOs.Notification
{
    public class NotificationTemplateDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
