namespace CliniqaxSystem.Application.Configuration
{
    public class DatabaseBackupSettings
    {
        public bool Enabled { get; set; }
        public string BackupPath { get; set; }
        public int RetentionDays { get; set; }
    }
}
