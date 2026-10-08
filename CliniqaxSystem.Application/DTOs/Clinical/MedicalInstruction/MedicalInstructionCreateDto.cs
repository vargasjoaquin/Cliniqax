namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction
{
    public class MedicalInstructionCreateDto
    {
        public string Instructions { get; set; } = null!;
        public string? MedicationDetails { get; set; }
        public string? FollowUpNotes { get; set; }
    }
}
