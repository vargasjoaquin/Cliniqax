using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class AttachmentCategory : LookupEntity
    {
        public bool IsActive { get; set; } = true;
    }
}
