using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public UserSessionDto? CurrentUser { get; set; }

        public int? UserId => CurrentUser?.UserId;
        public string? Username => CurrentUser?.Username;
        public string? FullName => CurrentUser?.FullName;
        public string? RoleName => CurrentUser?.RoleName;
        public bool IsAuthenticated => CurrentUser != null;
    }
}
