namespace CliniqaxSystem.Application.DTOs.Patient
{
    public class PatientCreateDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? HealthInsuranceId { get; set; }
        public string? AffiliateNumber { get; set; }
        public string? AdministrativeNotes { get; set; }
    }
}
