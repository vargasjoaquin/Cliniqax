namespace CliniqaxSystem.Domain.Enums
{
    public enum AppointmentStatus
    {
        Pending = 1, // Pendiente
        Confirmed = 2, // Confirmado
        Waiting = 3, // En sala de espera
        Attended = 4, //Atendido por el profesional
        Cancelled = 5, // Cancelado
        Absent = 6, // Ausente/No asistió
        Rescheduled = 7 // Re-programado
    }
}
