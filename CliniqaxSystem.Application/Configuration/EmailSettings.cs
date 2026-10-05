namespace CliniqaxSystem.Application.Configuration
{
    public class EmailSettings
    {
        public bool Enabled { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
