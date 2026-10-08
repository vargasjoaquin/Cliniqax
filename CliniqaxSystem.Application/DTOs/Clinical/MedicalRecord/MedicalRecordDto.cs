using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;

namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; } = null!;
        public string PatientDocument { get; set; } = null!;
        public string? PatientHealthInsurance { get; set; }
        public string? PatientAffiliateNumber { get; set; }
        public int PatientAge { get; set; }
        public string RecordNumber { get; set; } = null!;

        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? PathologicalHistory { get; set; }
        public string? NonPathologicalHistory { get; set; }
        public string? SurgicalHistory { get; set; }
        public string? FamilyHistory { get; set; }
        public string? GeneralObservations { get; set; }

        public List<ConsultationSummaryDto> Consultations { get; set; } = new();
        public List<MedicalAttachmentDto> MedicalAttachments { get; set; } = new();
    }
}
