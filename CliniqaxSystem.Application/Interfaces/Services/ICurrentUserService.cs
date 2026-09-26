namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        string? Username { get; }
        string? FullName { get; }
        string? RoleName { get; }
        bool IsAuthenticated { get; }
    }
}
