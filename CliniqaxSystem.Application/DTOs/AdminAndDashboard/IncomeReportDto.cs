namespace CliniqaxSystem.Application.DTOs.AdminAndDashboard
{
    public class IncomeReportDto
    {
        public DateTime Date { get; set; }
        public string ReceiptNumber { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public string ProfessionalName { get; set; } = null!;
        public string SpecialtyName { get; set; } = null!;
        public string PaymentMethodName { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal CopayAmount { get; set; }
        public string CashierName { get; set; } = null!;
    }
}
