namespace CliniqaxSystem.Domain.Common
{
    public abstract class LookupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
