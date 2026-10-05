namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyHashPassword(string password, string hash);
    }
}
