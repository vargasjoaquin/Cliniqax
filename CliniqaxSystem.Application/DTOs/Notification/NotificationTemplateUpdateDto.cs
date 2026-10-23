namespace CliniqaxSystem.Application.DTOs.Notification
{
    public class NotificationTemplateUpdateDto
    {
        public int Id { get; set; }
        public string? SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
