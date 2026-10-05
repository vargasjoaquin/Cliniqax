using CliniqaxSystem.Application.DTOs.Catalog;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Catalog
{
    public class HealthInsuranceValidator : AbstractValidator<HealthInsuranceDto>
    {
        public HealthInsuranceValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la obra social es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");
        }
    }
}
