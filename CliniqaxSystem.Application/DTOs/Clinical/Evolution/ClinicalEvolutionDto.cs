namespace CliniqaxSystem.Application.DTOs.Clinical.Evolution
{
    public class ClinicalEvolutionDto
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime EvolutionDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
