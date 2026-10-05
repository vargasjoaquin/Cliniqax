namespace CliniqaxSystem.Application.DTOs.User
{
    public class UserDto
    {
        public int Id {  get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int? ProfessionalId { get; set; }
        public string? ProfessionalName { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? Photo { get; set; }
    }
}
