namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class ConsultationReceiptDto
    {
        public string ClinicName { get; set; } = null!;
        public string? ClinicCuit { get; set; }
        public string? ClinicAddress { get; set; }
        public string? ClinicPhone { get; set; }
        public byte[]? LogoBytes { get; set; }

        public string ReceiptNumber { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;
        public string CashierName { get; set; } = null!;

        public string PatientName { get; set; } = null!;
        public string PatientDocument { get; set; } = null!;
        public string? HealthInsuranceName { get; set; }
        public string? AffiliateNumber { get; set; }

        public string ProfessionalName { get; set; } = null!;
        public string SpecialtyName { get; set; } = null!;

        public string PaymentMethodName { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal CopayAmount { get; set; }
        public decimal PaymentReceived { get; set; }
        public decimal PaymentChange { get; set; }

        public string? FooterMessage { get; set; }
        public string PaperSize { get; set; } = "80mm";
    }
}
