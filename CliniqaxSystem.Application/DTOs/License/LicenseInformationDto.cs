namespace CliniqaxSystem.Application.DTOs.License
{
    public class LicenseInformationDto
    {
        public string LicenseKey { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public DateTime? ExpiresAt { get; set; }
        public int? DaysRemaining { get; set; }
        public bool IsValid { get; set; }

        public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value < DateTime.UtcNow;
        public bool IsExpiredSoon => DaysRemaining.HasValue && DaysRemaining.Value <= 7 && DaysRemaining.Value >= 0;
    }
}
