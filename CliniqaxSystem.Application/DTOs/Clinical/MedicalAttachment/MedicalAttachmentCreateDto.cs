namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment
{
    public class MedicalAttachmentCreateDto
    {
        public int PatientId { get; set; }
        public int? ConsultationId { get; set; }
        public int? AttachmentCategoryId { get; set; }
        public string OriginalFileName { get; set; } = null!;
        public byte[] FileBytes { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
