using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[]? Photo { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;

        public int? ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }

        public virtual ICollection<CashSession> CashSessions { get; set; } = new List<CashSession>();
    }
}
