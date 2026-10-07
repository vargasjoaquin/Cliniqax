using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.Evolution;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;

namespace CliniqaxSystem.Application.DTOs.Clinical.Consultation
{
    public class ConsultationDto
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; } = null!;
        public string PatientDocument { get; set; } = null!;

        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; } = null!;
        public string ProfessionalLicense { get; set; } = null!;

        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = null!;

        public int ConsultationStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public int? AppointmentId { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string ReasonForConsultation { get; set; } = null!;
        public string? PhysicalExamination { get; set; }
        public string? Notes { get; set; }

        public List<ClinicalEvolutionDto> Evolutions { get; set; } = new();
        public List<ClinicalDiagnosisDto> Diagnoses { get; set; } = new();
        public List<MedicalInstructionDto> Instructions { get; set; } = new();
        public List<MedicalAttachmentDto> Attachments { get; set; } = new();
    }
}
