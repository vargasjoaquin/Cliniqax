namespace CliniqaxSystem.Application.DTOs.Catalog
{
    public class HealthInsuranceDto
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string? Cuit {  get; set; }
        public string? Phone {  get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
