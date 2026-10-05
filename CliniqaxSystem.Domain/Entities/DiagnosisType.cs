using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class DiagnosisType : LookupEntity
    {
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
