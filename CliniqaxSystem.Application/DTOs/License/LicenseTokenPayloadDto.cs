namespace CliniqaxSystem.Application.DTOs.License
{
    public class LicenseTokenPayloadDto
    {
        public string LicenseKey { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public string HardwareId { get; set; } = null!;
        public DateTime IssuedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime ValidationGraceUntil { get; set; }
    }
}
