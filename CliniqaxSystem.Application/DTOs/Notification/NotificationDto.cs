namespace CliniqaxSystem.Application.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string Recipient { get; set; } = null!;
        public string? Subject { get; set; }
        public string MessageBody { get; set; } = null!;
        public int RetryCount { get; set; }
        public int MaxRetries { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
