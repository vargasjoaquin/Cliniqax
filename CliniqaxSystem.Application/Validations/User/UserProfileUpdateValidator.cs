using CliniqaxSystem.Application.DTOs.User;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.User
{
    public class UserProfileUpdateValidator : AbstractValidator<UserProfileUpdateDto>
    {
        public UserProfileUpdateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Identificador de usuario inválido.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es obligatorio.");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Debe ingresar su contraseña actual para establecer una nueva clave.")
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword));

            RuleFor(x => x.NewPassword)
                .MinimumLength(6).WithMessage("La nueva contraseña debe tener al menos 6 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword));
        }
    }
}
