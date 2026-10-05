using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class MedicalInstruction : BaseEntity
    {
        public int ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; } = null!;

        public string Instruction { get; set; } = null!;
        public string? MedicationDetails { get; set; }
        public string? FollowUpNotes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
    }
}
