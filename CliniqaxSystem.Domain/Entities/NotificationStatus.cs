using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class NotificationStatus : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
