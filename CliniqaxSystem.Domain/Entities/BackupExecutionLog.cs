namespace CliniqaxSystem.Domain.Entities
{
    public class BackupExecutionLog
    {
        public int Id { get; set; }
        public string BackupType { get; set; } = null!;
        public string DestinationPath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public long FileSizeBytes { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int DurationSeconds { get; set; }
        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
        public string ExecutedBy { get; set; } = null!;
    }
}
