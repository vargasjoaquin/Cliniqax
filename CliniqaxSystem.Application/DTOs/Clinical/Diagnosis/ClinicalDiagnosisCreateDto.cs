namespace CliniqaxSystem.Application.DTOs.Clinical.Diagnosis
{
    public class ClinicalDiagnosisCreateDto
    {
        public int DiagnosisTypeId { get; set; } = 2; // Definitivo por defecto
        public string Description { get; set; } = null!;
        public string? DiagnosticCode { get; set; }
        public string? Notes { get; set; }
    }
}
