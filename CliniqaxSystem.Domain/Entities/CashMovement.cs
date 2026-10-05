using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Domain.Entities
{
    public class CashMovement : BaseEntity
    {
        public int CashSessionId { get; set; }
        public virtual CashSession CashSession { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public CashMovementType MovementType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
