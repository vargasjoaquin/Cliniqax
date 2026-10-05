using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class PaymentMethod : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
