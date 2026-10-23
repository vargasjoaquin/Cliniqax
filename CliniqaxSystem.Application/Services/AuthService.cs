using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Application.Services
{
    public class AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ICurrentUserService currentUserService, IEmailService emailService, IAuditService auditService, IMapper mapper) : IAuthService
    {
        public async Task<OperationResult> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult.Failure("Debe ingresar usuario y contraseña.");

            var user = await unitOfWork.Users.GetByUsernameAsync(username);

            if (user == null)
                return OperationResult.Failure($"El usuario '{username}' no existe en el sistema.");

            if (!user.IsActive)
                return OperationResult.Failure($"La cuenta de usuario '{user.Username}' se encuentra inactiva. Contacte con el administrador.");

            bool isPasswordValid = passwordHasher.VerifyHashPassword(password, user.Password);

            if (!isPasswordValid)
            {
                // Registrar intento fallido en auditoría
                await auditService.LogActionAsync("LOGIN_FALLIDO", "User", user.Id.ToString(), $"Intento con contraseña incorrecta para @{username}");
                return OperationResult.Failure("La contraseña es incorrecta. Verifique sus credenciales.");
            }

            if (currentUserService is CurrentUserService sessionHolder)
            {
                sessionHolder.CurrentUser = mapper.Map<UserSessionDto>(user);
                sessionHolder.CurrentUser.LoginTime = DateTime.Now;
            }

            await auditService.LogActionAsync(AuditActionConstants.LOGIN, "User", user.Id.ToString(), $"Inicio de sesión exitoso del operador @{user.Username}");

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

            string normalizedLoginIdentifier = identity.Trim();
            var allUsers = await unitOfWork.Users.GetAllAsync();

            var user = allUsers.FirstOrDefault(user =>
                user.Username.Equals(normalizedLoginIdentifier, StringComparison.OrdinalIgnoreCase) ||
                (!string.IsNullOrWhiteSpace(user.Email) && user.Email.Equals(normalizedLoginIdentifier, StringComparison.OrdinalIgnoreCase)));

            if (user == null)
                return OperationResult.Failure($"No se encontró ninguna cuenta activa vinculada a '{normalizedLoginIdentifier}'.");

            if (string.IsNullOrWhiteSpace(user.Email))
                return OperationResult.Failure($"El usuario '{user.Username}' no posee un correo electrónico registrado. Solicite el blanqueo directamente al Administrador.");

            string temporaryPassword = GenerateTemporaryPassword();

            user.Password = passwordHasher.HashPassword(temporaryPassword);
            user.LastUpdatedAt = DateTime.UtcNow;
            user.LastUpdatedBy = "AutoRecovery";

            unitOfWork.Users.Update(user);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            if (!isSuccess)
                return OperationResult.Failure("No se pudo actualizar la credencial temporal en la base de datos.");

            string maskedEmailAddress = MaskEmail(user.Email);

            string emailBody = $@"
            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e2e8f0; border-radius: 8px;'>
                <h2 style='color: #0284c7;'>Cliniqax — Restablecimiento de Credenciales</h2>
                <p>Hola <strong>{user.FirstName} {user.LastName}</strong>,</p>
                <p>Se ha solicitado el restablecimiento de tu contraseña para el usuario <strong>{user.Username}</strong>.</p>
                <div style='background: #f8fafc; padding: 15px; border-left: 4px solid #10b981; margin: 20px 0;'>
                    <p style='margin: 0; font-size: 14px; color: #64748b;'>Tu nueva contraseña temporal es:</p>
                    <p style='margin: 5px 0 0 0; font-size: 22px; font-weight: bold; color: #0f172a;'>{temporaryPassword}</p>
                </div>
                <p style='color: #ef4444; font-size: 13px;'>⚠️ Por seguridad, una vez que inicies sesión ingresa a <strong>Mi Perfil</strong> y cámbiala por una contraseña personal.</p>
                <hr style='border: none; border-top: 1px solid #cbd5e1; margin: 20px 0;' />
                <p style='font-size: 12px; color: #94a3b8;'>Cliniqax — Sistema de Gestión para Consultorios.</p>
            </div>";

            try
            {
                await emailService.SendEmailAsync(user.Email, "Restablecimiento de Contraseña — Cliniqax", emailBody);
                await auditService.LogActionAsync("RESET_PASSWORD", "User", user.Id.ToString(), $"Blanqueo de clave despachado a {maskedEmailAddress}");
            }
            catch (Exception ex)
            {
                string errorDetail = ex.InnerException != null ? $"{ex.Message} -> {ex.InnerException.Message}" : ex.Message;
                return OperationResult.Ok($"Se generó tu clave temporal: '{temporaryPassword}'. (Aviso: No se pudo despachar el correo SMTP: {errorDetail})");
            }

            return OperationResult.Ok($"¡Contraseña temporal generada con éxito! Se ha enviado a tu correo: {maskedEmailAddress}. Inicia sesión con la clave recibida y cámbiala desde 'Mi Perfil'.");
        }

        private static string GenerateTemporaryPassword()
        {
            const string uppercaseCharacters = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string numericCharacters = "23456789";
            
            var randomGenerator = new Random();

            var randomLetters = new string(Enumerable.Range(0, 4).Select(_ => uppercaseCharacters[randomGenerator.Next(uppercaseCharacters.Length)]).ToArray());
            var randomNumbers = new string(Enumerable.Range(0, 4).Select(_ => numericCharacters[randomGenerator.Next(numericCharacters.Length)]).ToArray());

            return $"CQX#{randomLetters}{randomNumbers}";
        }

        private static string MaskEmail(string email)
        {
            var emailParts = email.Split('@');
            
            if (emailParts.Length != 2)
                return email;

            string emailUsername = emailParts[0];
            string emailDomain = emailParts[1];
            
            string maskedEmailUsername = emailUsername.Length <= 2 ? emailUsername + "***" : emailUsername.Substring(0, 2) + new string('*', emailUsername.Length - 2);

            return $"{maskedEmailUsername}@{emailDomain}";
        }
    }
}
