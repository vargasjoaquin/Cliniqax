namespace CliniqaxSystem.Application.DTOs.Professional
{
    public class ProfessionalScheduleDto
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; } = true;

        public string DayName
        {
            get
            {
                switch (DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return "Lunes";

                    case DayOfWeek.Tuesday:
                        return "Martes";

                    case DayOfWeek.Wednesday:
                        return "Miércoles";

                    case DayOfWeek.Thursday:
                        return "Jueves";

                    case DayOfWeek.Friday:
                        return "Viernes";

                    case DayOfWeek.Saturday:
                        return "Sábado";

                    case DayOfWeek.Sunday:
                        return "Domingo";

                    default:
                        return "";
                }
            }
        }
    }
}
