using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Domain.Entities
{
    public class Consultation : AuditableEntity
    {
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; } = null!;

        public int ProfessionalId { get; set; }
        public virtual Professional Professional { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; } = null!;

        public int ConsultationStatusId { get; set; } = ConsultationStatusConstants.COMPLETED;
        public virtual ConsultationStatus ConsultationStatus { get; set; } = null!;

        public int? AppointmentId { get; set; }
        public virtual Appointment? Appointment { get; set; }

        public DateTime ConsultationDate { get; set; } = DateTime.UtcNow;
        public string ReasonForConsultation { get; set; } = null!;
        public string? PhysicalExamination { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<ClinicalEvolution> ClinicalEvolutions { get; set; } = new List<ClinicalEvolution>();
        public virtual ICollection<ClinicalDiagnosis> ClinicalDiagnoses { get; set; } = new List<ClinicalDiagnosis>();
        public virtual ICollection<MedicalInstruction> MedicalInstructions { get; set; } = new List<MedicalInstruction>();
        public virtual ICollection<MedicalAttachment> MedicalAttachments { get; set; } = new List<MedicalAttachment>();

        public void FinalizeConsultation()
        {
            if (ConsultationStatusId != ConsultationStatusConstants.COMPLETED)
                throw new InvalidOperationException("No se puede finalizar una consulta que ha sido anulada.");

            ConsultationStatusId = ConsultationStatusConstants.COMPLETED;
        }

        public void CancelConsultation(string reason)
        {
            ConsultationStatusId = ConsultationStatusConstants.CANCELLED;
            Notes = string.IsNullOrWhiteSpace(Notes)
                ? $"[ANULADA]: {reason}"
                : $"{Notes}\n[ANULADA]: {reason}";
        }
    }
}
