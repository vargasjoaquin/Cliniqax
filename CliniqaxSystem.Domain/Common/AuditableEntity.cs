namespace CliniqaxSystem.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
