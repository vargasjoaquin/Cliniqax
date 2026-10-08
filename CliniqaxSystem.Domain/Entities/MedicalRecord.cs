using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class MedicalRecord : AuditableEntity
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public string RecordNumber { get; set; } = null!;

        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? PathologicalHistory { get; set; }
        public string? NonPathologicalHistory { get; set; }
        public string? SurgicalHistory { get; set; }
        public string? FamilyHistory { get; set; }
        public string? GeneralObservations { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
        public virtual ICollection<MedicalAttachment> MedicalAttachments { get; set; } = new List<MedicalAttachment>();
    }
}
