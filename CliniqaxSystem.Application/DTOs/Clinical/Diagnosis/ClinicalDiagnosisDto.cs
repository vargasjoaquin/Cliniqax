namespace CliniqaxSystem.Application.DTOs.Clinical.Diagnosis
{
    public class ClinicalDiagnosisDto
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public int DiagnosisTypeId { get; set; }
        public string DiagnosisTypeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? DiagnosticCode { get; set; }
        public string? Notes { get; set; }
    }
}
