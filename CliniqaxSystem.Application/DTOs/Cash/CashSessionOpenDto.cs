namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class CashSessionOpenDto
    {
        public decimal InitialCash { get; set; }
        public string StationName { get; set; } = null!;
    }
}
