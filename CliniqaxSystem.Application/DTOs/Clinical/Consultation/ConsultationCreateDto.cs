using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;

namespace CliniqaxSystem.Application.DTOs.Clinical.Consultation
{
    public class ConsultationCreateDto
    {
        public int PatientId { get; set; }
        public int ProfessionalId { get; set; }
        public int SpecialtyId { get; set; }
        public int? AppointmentId { get; set; }

        public DateTime ConsultationDate { get; set; } = DateTime.Now;
        public string ReasonForConsultation { get; set; } = null!;
        public string? PhysicalExamination { get; set; }
        public string? EvolutionNotes { get; set; }
        public string? Notes { get; set; }

        public List<ClinicalDiagnosisCreateDto> Diagnoses { get; set; } = new();
        public List<MedicalInstructionCreateDto> Instructions { get; set; } = new();
    }
}
