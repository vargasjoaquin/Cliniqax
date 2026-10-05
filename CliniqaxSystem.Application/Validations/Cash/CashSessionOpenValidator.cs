using CliniqaxSystem.Application.DTOs.Cash;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Cash
{
    public class CashSessionOpenValidator : AbstractValidator<CashSessionOpenDto>
    {
        public CashSessionOpenValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.InitialCash)
                .GreaterThanOrEqualTo(0).WithMessage("El fondo inicial de caja no puede ser negativo.");

            RuleFor(x => x.StationName)
                .NotEmpty().WithMessage("Debe especificar la recepción o puesto.")
                .MaximumLength(50).WithMessage("El nombre de la recepción no puede superar 50 caracteres.");
        }
    }
}
