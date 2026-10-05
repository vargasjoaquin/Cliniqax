namespace CliniqaxSystem.Application.DTOs.AdminAndDashboard
{
    public class ClinicSettingsDto
    {
        public string ClinicName { get; set; } = null!;
        public string? Cuit { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public byte[]? Logo { get; set; }
        public string ReceiptFormat { get; set; } = "80mm";
        public string? ReceiptFooterMessage { get; set; }
        public bool ShowLogoOnReceipt { get; set; } = true;
        public bool AutoPrintReceipt { get; set; } = false;
        public string? ThermalPrinterName { get; set; }
    }
}
