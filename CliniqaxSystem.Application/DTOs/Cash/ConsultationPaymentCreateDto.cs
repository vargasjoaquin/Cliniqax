namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class ConsultationPaymentCreateDto
    {
        public int AppointmentId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public decimal CopayAmount { get; set; }
        public decimal PaymentReceived { get; set; }
        public string? Observations { get; set; }
    }
}
