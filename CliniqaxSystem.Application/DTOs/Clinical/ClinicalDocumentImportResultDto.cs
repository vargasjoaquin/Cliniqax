namespace CliniqaxSystem.Application.DTOs.Clinical
{
    public class ClinicalDocumentImportResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int PatientId { get; set; }
        public int? ConsultationId { get; set; }
        public string GeneratedRelativePath { get; set; } = null!;
    }
}
