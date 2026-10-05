using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Domain.Entities
{
    public class ClinicalDiagnosis : BaseEntity
    {
        public int ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; } = null!;

        public int DiagnosisTypeId { get; set; } = DiagnosisTypeConstants.DEFINITIVE;
        public virtual DiagnosisType DiagnosisType { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string? DiagnosisCode { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
    }
}
