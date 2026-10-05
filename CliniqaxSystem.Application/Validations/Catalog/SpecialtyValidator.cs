using CliniqaxSystem.Application.DTOs.Catalog;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Catalog
{
    public class SpecialtyValidator : AbstractValidator<SpecialtyDto>
    {
        public SpecialtyValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre de la especialidad es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");
        }
    }
}
