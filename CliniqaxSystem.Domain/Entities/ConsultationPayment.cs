using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Domain.Entities
{
    public class ConsultationPayment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; } = null!;

        public int CashSessionId { get; set; }
        public virtual CashSession CashSession { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int PaymentMethodId { get; set; } = PaymentMethodConstants.CASH_ID;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;

        public decimal Amount { get; set; }           // Monto total cobrado al paciente
        public decimal CopayAmount { get; set; }      // Copago de Obra Social
        public decimal PaymentReceived { get; set; }  // Efectivo recibido
        public decimal PaymentChange { get; set; }    // Vuelto entregado

        public string ReceiptNumber { get; set; } = null!;
        public string? Observations { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
