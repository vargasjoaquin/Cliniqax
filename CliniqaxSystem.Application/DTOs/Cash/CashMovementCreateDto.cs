using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class CashMovementCreateDto
    {
        public CashMovementType MovementType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}
