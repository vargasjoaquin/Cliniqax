namespace CliniqaxSystem.Domain.Entities
{
    public class ProfessionalSpecialty
    {
        public int ProfessionalId { get; set; }
        public virtual Professional Professional { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; } = null!;
    }
}
