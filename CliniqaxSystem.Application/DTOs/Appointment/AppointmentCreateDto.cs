namespace CliniqaxSystem.Application.DTOs.Appointment
{
    public class AppointmentCreateDto
    {
        public int PatientId { get; set; }
        public int ProfessionalId { get; set; }
        public int SpecialtyId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Observations { get; set; }
    }
}
