using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.Application.Services
{
    public class AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ICurrentUserService currentUserService, IMapper mapper) : IAuthService
    {
        public async Task<OperationResult> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult.Failure("Debe ingresar usuario y contraseña.");

            var user = await unitOfWork.Users.GetByUsernameAsync(username);

            if (user == null)
                return OperationResult.Failure($"El usuario '{user}' no existe en el sistema.");

            if (!user.IsActive)
                return OperationResult.Failure($"La cuenta de usuario '{user}' se encuenta inactiva. Contacte con el administrador.");

            bool isPasswordValid = passwordHasher.VerifyHashPassword(password, user.Password);

            if (!isPasswordValid)
                return OperationResult.Failure("La contraseña es incorrecta. Verifique sus credenciales.");

            if (currentUserService is CurrentUserService sessionHolder)
            {
                sessionHolder.CurrentUser = mapper.Map<UserSessionDto>(user);
                sessionHolder.CurrentUser.LoginTime = DateTime.Now;
            }

            return OperationResult.Ok($"¡Bienvenido/a, {user.FirstName}!");
        }

        public void Logout()
        {
            if (currentUserService is CurrentUserService sessionHolder)
            {
                sessionHolder.CurrentUser = null;
            }
        }

        public async Task<OperationResult> SendPasswordResetAsync(string identity)
        {
            if (string.IsNullOrWhiteSpace(identity))
                return OperationResult.Failure("Debe ingresar un usuario o correo electrónico.");

            var allUsers = await unitOfWork.Users.GetAllAsync();

            var user = allUsers.FirstOrDefault(user =>
                user.Username.Equals(identity.Trim(), StringComparison.OrdinalIgnoreCase) ||
                (user.Email != null && user.Email.Equals(identity.Trim(), StringComparison.OrdinalIgnoreCase)));

            if (user == null)
                return OperationResult.Failure("No se encontró ningún usuario vinculado al dato ingresado.");

            string temporaryPassword = $"CLX#{new Random().Next(1000, 9999)}";

            user.Password = passwordHasher.HashPassword(temporaryPassword);

            unitOfWork.Users.Update(user);
            await unitOfWork.CompleteAsync();

            return OperationResult.Ok($"Clave temporal generada: '{temporaryPassword}'. Inicie sesión y cámbiela en la seccion de 'Mi Perfil'.");
        }
    }
}
