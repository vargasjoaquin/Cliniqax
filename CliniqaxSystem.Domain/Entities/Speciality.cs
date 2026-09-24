using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class Speciality : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<ProfessionalSpeciality> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpeciality>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
