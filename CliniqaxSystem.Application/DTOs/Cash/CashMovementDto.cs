using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.DTOs.Cash
{
    public class CashMovementDto
    {
        public int Id { get; set; }
        public int CashSessionId { get; set; }
        public CashMovementType MovementType { get; set; }
        public string MovementTypeName => MovementType == CashMovementType.CashIn ? "Ingreso Manual" : "Retiro / Egreso";
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = null!;
    }
}
