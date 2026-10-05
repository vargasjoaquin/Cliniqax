using CliniqaxSystem.Application.DTOs.User;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.User
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MinimumLength(4).WithMessage("El usuario debe tener al menos 4 caracteres.")
                .MaximumLength(50).WithMessage("El usuario no puede superar 50 caracteres.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre es obligatorio.").MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es obligatorio.").MaximumLength(50);
            RuleFor(x => x.RoleId).GreaterThan(0).WithMessage("Debe seleccionar un rol válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
                .When(x => x.Id == 0);
        }
    }
}
