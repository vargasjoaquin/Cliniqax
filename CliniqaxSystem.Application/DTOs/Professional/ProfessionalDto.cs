namespace CliniqaxSystem.Application.DTOs.Professional
{
    public class ProfessionalDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public string DocumentNumber { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
        public string? Phone {  get; set; }
        public string? Email { get; set; }
        public int AppointmentDuration { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Observations { get; set; }

        public List<int> SpecialtyIds { get; set; } = new();
        public List<string> SpecialtyNames { get; set;} = new();
        public List<ProfessionalScheduleDto> Schedules { get; set; } = new();
    }
}
