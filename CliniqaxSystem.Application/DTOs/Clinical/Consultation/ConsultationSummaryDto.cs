namespace CliniqaxSystem.Application.DTOs.Clinical.Consultation
{
    public class ConsultationSummaryDto
    {
        public int Id { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string ProfessionalName { get; set; } = null!;
        public string SpecialtyName { get; set; } = null!;
        public string ReasonForConsultation { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public string? MainDiagnosis { get; set; }
        public int AttachmentsCount { get; set; }
    }
}
