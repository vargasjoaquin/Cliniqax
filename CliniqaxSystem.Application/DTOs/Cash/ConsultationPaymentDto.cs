namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class ConsultationPaymentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string ReceiptNumber { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public string PatientDocument { get; set; } = null!;
        public string ProfessionalName { get; set; } = null!;
        public string SpecialtyName { get; set; } = null!;
        public string PaymentMethodName { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal CopayAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
