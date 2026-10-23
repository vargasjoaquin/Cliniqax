using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class NotificationChannel : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
