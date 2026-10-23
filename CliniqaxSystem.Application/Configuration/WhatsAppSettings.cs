namespace CliniqaxSystem.Application.Configuration
{
    public class WhatsAppSettings
    {
        public bool Enabled { get; set; }
        public string Provider { get; set; }
        public string ApiUrl { get; set; }
        public string ApiToken { get; set; }
        public string PhoneNumberId { get; set; }
    }
}
