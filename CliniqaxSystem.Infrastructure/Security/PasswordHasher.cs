using CliniqaxSystem.Application.Interfaces.Repositories;

namespace CliniqaxSystem.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHashPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
