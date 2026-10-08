namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction
{
    public class MedicalInstructionDto
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public string Instructions { get; set; } = null!;
        public string? MedicationDetails { get; set; }
        public string? FollowUpNotes { get; set; }
    }
}
