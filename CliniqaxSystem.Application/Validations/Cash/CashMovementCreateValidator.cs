using CliniqaxSystem.Application.DTOs.Cash;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Cash
{
    public class CashMovementCreateValidator : AbstractValidator<CashMovementCreateDto>
    {
        public CashMovementCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto del movimiento debe ser mayor a $ 0.00.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Debe ingresar el motivo o descripción del movimiento.")
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.");

            RuleFor(x => x.MovementType)
                .IsInEnum().WithMessage("Tipo de movimiento de caja inválido.");
        }
    }
}
