using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public int? AppointmentId { get; set; }
        public virtual Appointment? Appointment { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

        public int ChannelId { get; set; }
        public virtual NotificationChannel Channel { get; set; } = null!;

        public int StatusId { get; set; } = NotificationStatusConstants.PENDING;
        public virtual NotificationStatus Status { get; set; } = null!;

        public string? TemplateCode { get; set; }
        public string Recipient { get; set; } = null!;
        public string? Subject { get; set; }
        public string MessageBody { get; set; } = null!;

        public int RetryCount { get; set; } = 0;
        public int MaxRetryCount { get; set; } = 3;
        public string? ErrorMessage { get; set; }

        public DateTime ScheduledAt { get; set; } = DateTime.UtcNow;
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ==========================================
        // REGLAS DE DOMINIO Y REINTENTOS
        // ==========================================

        public void MarkAsProcessing()
        {
            StatusId = NotificationStatusConstants.PROCESSING;
        }

        public void MarkAsSent()
        {
            StatusId = NotificationStatusConstants.SENT;
            SentAt = DateTime.UtcNow;
            ErrorMessage = null;
        }

        public void RegisterFailure(string error)
        {
            RetryCount++;
            ErrorMessage = error;

            if (RetryCount >= MaxRetryCount)
            {
                StatusId = NotificationStatusConstants.FAILED;
            }
            else
            {
                StatusId = NotificationStatusConstants.RETRYING;
            }
        }

        public void Cancel()
        {
            if (StatusId == NotificationStatusConstants.SENT)
                throw new InvalidOperationException("No se puede cancelar una notificación que ya fue enviada.");

            StatusId = NotificationStatusConstants.CANCELLED;
        }
    }
}
