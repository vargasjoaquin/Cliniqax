using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class HealthInsurance : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string? Cuit {  get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
