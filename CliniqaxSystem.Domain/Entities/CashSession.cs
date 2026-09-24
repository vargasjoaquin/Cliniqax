using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Domain.Entities
{
    public class CashSession : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public string StationName { get; set; }

        public DateTime OpeningDate { get; set; } = DateTime.UtcNow;
        public DateTime? ClosingDate { get; set; }

        // Arqueo y balance de caja
        public decimal InitialCash { get; set; }
        public decimal? RealCash { get; set; }
        public decimal? ExpectedCash { get; set; }
        public decimal? Difference { get; set; }


        // Ingresos cobrados por consultas y copagos
        public decimal TotalCashIncome { get; set; }
        public decimal TotalDebitIncome { get; set; }
        public decimal TotalCreditIncome { get; set; }
        public decimal TotalTransferIncome { get; set; }
        public decimal TotalQrIncome { get; set; }


        // Movimientos manuales de caja
        public decimal TotalManualCashIn { get; set; }
        public decimal TotalManualCashOut { get; set; }

        public string? Status { get; set; } = CashSessionStatusesConstants.OPEN;
        public string? ClosingNotes { get; set; }

        public virtual ICollection<CashMovement> CashMovements { get; set; } = new List<CashMovement>();
        public virtual ICollection<ConsultationPayment> Payments { get; set; } = new List<ConsultationPayment>();

        // Cálculos de balance financiero
        public decimal CurrentSystemCash => InitialCash + TotalCashIncome + TotalManualCashIn - TotalManualCashOut;
        public decimal TotalTurnover => TotalCashIncome + TotalDebitIncome + TotalCreditIncome + TotalTransferIncome + TotalQrIncome;
    }
}
