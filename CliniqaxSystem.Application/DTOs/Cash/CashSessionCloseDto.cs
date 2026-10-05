namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class CashSessionCloseDto
    {
        public int SessionId { get; set; }
        public decimal RealCash { get; set; }
        public string? ClosingNotes { get; set; }
    }
}
