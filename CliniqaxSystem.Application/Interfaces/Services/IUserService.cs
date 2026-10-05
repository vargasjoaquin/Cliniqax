using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUserListAsync();
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<UserDto?> GetByIdAsync(int id);

        Task<OperationResult> CreateUserAsync(UserCreateDto userCreateDto);
        Task<OperationResult> UpdateUserAsync(UserDto userDto);
        Task<OperationResult> UpdateProfileAsync(UserProfileUpdateDto userProfileUpdateDto);
        Task<OperationResult> DeleteUserAsync(int id);
        Task<OperationResult> ToggleUserStatusAsync(int id);
    }
}
