namespace CliniqaxSystem.Application.DTOs.Catalog
{
    public class SpecialtyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
