using CliniqaxSystem.Application.DTOs.Cash;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Cash
{
    public class CashSessionCloseValidator : AbstractValidator<CashSessionCloseDto>
    {
        public CashSessionCloseValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SessionId)
                .GreaterThan(0).WithMessage("Identificador de sesión inválido.");

            RuleFor(x => x.RealCash)
                .GreaterThanOrEqualTo(0).WithMessage("El monto contado físicamente en caja no puede ser negativo.");

            RuleFor(x => x.ClosingNotes)
                .MaximumLength(250).WithMessage("Las observaciones no pueden superar los 250 caracteres.");
        }
    }
}
