using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.DTOs.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public string PatientDocument {  get; set; } = null!;
        public string PatientPhone { get; set; } = null!;
        public string? HealthInsuranceName { get; set; }
        public string? AffiliateNumber { get; set; }

        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; } = null!;
        
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime {  get; set; }
        public string TimeSlot => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";

        public string? CancellationReason { get; set; }
        public string? Observations { get; set; }
        public bool HasClinicalHistory { get; set; }

        public AppointmentStatus Status { get; set; }
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case AppointmentStatus.Pending:
                        return "Pendiente";

                    case AppointmentStatus.Confirmed:
                        return "Confirmado";

                    case AppointmentStatus.Waiting:
                        return "En Espera";

                    case AppointmentStatus.Attended:
                        return "Atendido";

                    case AppointmentStatus.Cancelled:
                        return "Cancelado";

                    case AppointmentStatus.Absent:
                        return "Ausente";

                    case AppointmentStatus.Rescheduled:
                        return "Reprogramado";

                    default:
                        return "Desconocido";
                }
            }
        }
    }
}
