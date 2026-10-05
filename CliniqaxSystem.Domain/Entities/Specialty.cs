using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class Specialty : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpecialty>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
