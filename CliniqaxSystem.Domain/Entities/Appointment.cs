using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Domain.Entities
{
    public class Appointment : AuditableEntity
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public int ProfessionalId { get; set; }
        public virtual Professional Professional { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? CancellationReason {  get; set; }
        public string? Observations { get; set; }

        public bool HasClinicalHistory { get; set; } = false;

        public virtual ICollection<ConsultationPayment> Payments { get; set; } = new List<ConsultationPayment>();

        // ==========================================
        // REGLAS DE NEGOCIO Y MÁQUINA DE ESTADOS
        // ==========================================
        public void Confirm()
        {
            if (Status == AppointmentStatus.Cancelled)
                throw new InvalidOperationException("No se puede confirmar un turno cancelado.");

            Status = AppointmentStatus.Confirmed;
        }

        public void MarkInWaitingRoom()
        {
            if (Status != AppointmentStatus.Confirmed && Status != AppointmentStatus.Pending)
                throw new InvalidOperationException("Solo turnos confirmados o pendientes pueden pasar a sala de espera.");

            Status = AppointmentStatus.Waiting;
        }

        public void MarkAsAttended()
        {
            if (Status != AppointmentStatus.Waiting && Status != AppointmentStatus.Confirmed)
                throw new InvalidOperationException("El paciente debe estar en espera o confirmado para ser atendido.");

            Status = AppointmentStatus.Attended;
        }

        public void Cancel(string reason)
        {
            if (Status == AppointmentStatus.Attended)
                throw new InvalidOperationException("No se puede cancelar un turno que ya ha sido atendido.");

            Status = AppointmentStatus.Cancelled;
            CancellationReason = reason;
        }

        public void MarkAsAbsent()
        {
            if (Status == AppointmentStatus.Attended)
                throw new InvalidOperationException("Un turno ya atendido no puede registrarse como ausente.");

            Status = AppointmentStatus.Absent;
        }

        public void Reschedule(DateTime newDate, TimeSpan newStartTime, TimeSpan newEndTime)
        {
            if (Status == AppointmentStatus.Attended)
                throw new InvalidOperationException("Un turno ya atendido no puede ser reprogramado.");

            AppointmentDate = newDate.Date;
            StartTime = newStartTime;
            EndTime = newEndTime;
            Status = AppointmentStatus.Rescheduled;
        }
    }
}
