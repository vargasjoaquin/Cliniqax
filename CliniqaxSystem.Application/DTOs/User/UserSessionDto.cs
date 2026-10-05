namespace CliniqaxSystem.Application.DTOs.User
{
    public class UserSessionDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.UtcNow;
        public byte[]? Photo { get; set; }
    }
}
