using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class ConsultationStatus : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
