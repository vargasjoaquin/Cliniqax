using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class MedicalAttachment : BaseEntity
    {
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; } = null!;

        public int? ConsultationId { get; set; }
        public virtual Consultation? Consultation { get; set; }

        public int? AttachmentCategoryId { get; set; }
        public virtual AttachmentCategory? AttachmentCategory { get; set; }

        public string OriginalFileName { get; set; } = null!;
        public string StoredFileName { get; set; } = null!;
        public string RelativePath { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long FileSizeBytes { get; set; }
        public string? Notes { get; set; }
    }
}
