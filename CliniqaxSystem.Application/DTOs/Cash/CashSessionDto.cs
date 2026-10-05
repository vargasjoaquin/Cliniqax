namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class CashSessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string StationName { get; set; } = null!;
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public decimal InitialCash { get; set; }
        public decimal? RealCash { get; set; }
        public decimal? ExpectedCash { get; set; }
        public decimal? Difference { get; set; }

        public decimal TotalCashIncome { get; set; }
        public decimal TotalDebitIncome { get; set; }
        public decimal TotalCreditIncome { get; set; }
        public decimal TotalTransferIncome { get; set; }
        public decimal TotalQrIncome { get; set; }

        public decimal TotalManualCashIn { get; set; }
        public decimal TotalManualCashOut { get; set; }

        public string? Status { get; set; }
        public string? ClosingNotes { get; set; }

        public decimal CurrentSystemCash => InitialCash + TotalCashIncome + TotalManualCashIn - TotalManualCashOut;
        public decimal TotalTurnover => TotalCashIncome + TotalDebitIncome + TotalCreditIncome + TotalTransferIncome + TotalQrIncome;
    }
}
