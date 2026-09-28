using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper, IValidator<UserCreateDto> createUserValidator, IValidator<UserProfileUpdateDto> updateProfileUserValidator) : IUserService
    {
        public async Task<IEnumerable<UserDto>> GetUserListAsync()
        {
            var users = await unitOfWork.Users.GetAllAsync();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async  Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);
            return user == null ? null : mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
           return await unitOfWork.Roles.GetAllAsync();
        }

        public async Task<OperationResult> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var validation = await createUserValidator.ValidateAsync(userCreateDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string username = userCreateDto.Username.Trim();
            
            var existingUsername = await unitOfWork.Users.GetByUsernameAsync(username);
            
            if (existingUsername != null)
                return OperationResult.Failure($"El nombre de usuario '{username}' ya se encuentra en uso.");

            var user = mapper.Map<User>(userCreateDto);
            
            user.Username = username;
            user.Password = passwordHasher.HashPassword(userCreateDto.Password);
            user.IsActive = true;

            await unitOfWork.Users.AddAsync(user);
            
            bool isSucess = await unitOfWork.CompleteAsync();

            return isSucess
                ? OperationResult.Ok("Usuario creado exitosamente.", user.Id)
                : OperationResult.Failure("Error al registrar el usuario.");
        }

        public async Task<OperationResult> UpdateUserAsync(UserDto userDto)
        {
            var user = await unitOfWork.Users.GetByIdAsync(userDto.Id);
            
            if (user == null)
                return OperationResult.Failure("El usuario no fue encontrado.");

            bool isSuperAdmin = user.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase);
            
            if (isSuperAdmin && userDto.RoleId != RoleConstants.ADMINISTRATOR_ROLE_ID)
                return OperationResult.Failure("El Administrador principal no puede cambiar su rol.");

            user.FirstName = userDto.FirstName.Trim();
            user.LastName = userDto.LastName.Trim();
            user.Email = userDto.Email?.Trim();
            user.ProfessionalId = userDto.ProfessionalId;

            if (!isSuperAdmin)
            {
                user.RoleId = userDto.RoleId;
            }

            unitOfWork.Users.Update(user);
            
            bool isSucess = await unitOfWork.CompleteAsync();

            return isSucess
                ? OperationResult.Ok("Usuario actualizado correctamente.", user.Id)
                : OperationResult.Failure("No se realizaron cambios.");
        }

        public async Task<OperationResult> UpdateProfileAsync(UserProfileUpdateDto userProfileUpdateDto)
        {
            var validation = await updateProfileUserValidator.ValidateAsync(userProfileUpdateDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var user = await unitOfWork.Users.GetByIdAsync(userProfileUpdateDto.UserId);
            
            if (user == null)
                return OperationResult.Failure("El usuario no fue encontrado.");

            if (!string.IsNullOrWhiteSpace(userProfileUpdateDto.NewPassword))
            {
                if (string.IsNullOrWhiteSpace(userProfileUpdateDto.CurrentPassword))
                    return OperationResult.Failure("Debe ingresar su contraseña actual para confirmar el cambio.");

                if (!passwordHasher.VerifyHashPassword(userProfileUpdateDto.CurrentPassword, user.Password))
                    return OperationResult.Failure("La contraseña actual ingresada es incorrecta.");

                user.Password = passwordHasher.HashPassword(userProfileUpdateDto.NewPassword);
            }

            user.FirstName = userProfileUpdateDto.FirstName.Trim();
            user.LastName = userProfileUpdateDto.LastName.Trim();
            user.Email = userProfileUpdateDto.Email?.Trim();

            if (userProfileUpdateDto.Photo != null)
                user.Photo = userProfileUpdateDto.Photo;

            unitOfWork.Users.Update(user);
            
            bool isSucess = await unitOfWork.CompleteAsync();

            return isSucess
                ? OperationResult.Ok("Perfil actualizado con éxito.")
                : OperationResult.Failure("No se detectaron cambios.");
        }

        public async Task<OperationResult> DeleteUserAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);
            
            if (user == null)
                return OperationResult.Failure("El usuario no fue encontrado.");

            if (user.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase))
                return OperationResult.Failure("El Administrador principal no puede ser eliminado.");

            user.IsDeleted = true;
            user.IsActive = false;

            unitOfWork.Users.Update(user);
            
            bool isSucess = await unitOfWork.CompleteAsync();

            return isSucess
                ? OperationResult.Ok("Usuario eliminado correctamente.")
                : OperationResult.Failure("Error al eliminar el usuario.");
        }

        public async Task<OperationResult> ToggleUserStatusAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);
            
            if (user == null)
                return OperationResult.Failure("El usuario no fue encontrado.");

            if (user.Username.Equals(RoleConstants.DEFAULT_ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase))
                return OperationResult.Failure("No se puede desactivar la cuenta del Administrador principal.");

            user.IsActive = !user.IsActive;
            
            unitOfWork.Users.Update(user);
            
            bool isSucess = await unitOfWork.CompleteAsync();

            return isSucess
                ? OperationResult.Ok($"El Usuario fue {(user.IsActive ? "activado" : "desactivado")} exitosamente.")
                : OperationResult.Failure("Error al cambiar el estado.");
        }
    }
}
