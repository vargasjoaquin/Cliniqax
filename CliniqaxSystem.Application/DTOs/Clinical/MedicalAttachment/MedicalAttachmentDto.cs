namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment
{
    public class MedicalAttachmentDto
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public int? ConsultationId { get; set; }
        public int? AttachmentCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string OriginalFileName { get; set; } = null!;
        public string StoredFileName { get; set; } = null!;
        public string RelativePath { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public long FileSizeBytes { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
