namespace CliniqaxSystem.Application.DTOs.Audit
{
    public class BackupExecutionLogDto
    {
        public int Id { get; set; }
        public string BackupType { get; set; } = null!;
        public string DestinationPath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public long FileSizeBytes { get; set; }
        public string FileSizeFormatted => FileSizeBytes < 1024 * 1024
            ? $"{FileSizeBytes / 1024.0:F1} KB"
            : $"{FileSizeBytes / (1024.0 * 1024.0):F2} MB";
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int DurationSeconds { get; set; }
        public DateTime ExecutedAt { get; set; }
        public string ExecutedBy { get; set; } = null!;
    }
}
