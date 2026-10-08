using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class ClinicalEvolution : BaseEntity
    {
        public int ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; } = null!;

        public string Description { get; set; } = null!;
        public DateTime EvolutionDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
    }
}