namespace CliniqaxSystem.Application.DTOs.Clinical.Diagnosis
{
    public class DiagnosisTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
