namespace CliniqaxSystem.Application.DTOs.User
{
    public class UserProfileUpdateDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public byte[]? Photo {  get; set; }
    }
}
