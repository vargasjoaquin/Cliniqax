namespace CliniqaxSystem.Application.DTOs.Appointment
{
    public class AgendaSlotDto
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string TimeRange => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
        public bool IsAvailable { get; set; }
        public AppointmentDto? Appointment { get; set; }
    }
}
