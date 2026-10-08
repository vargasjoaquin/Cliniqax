using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Clinical
{
    public class ClinicalDiagnosisCreateValidator : AbstractValidator<ClinicalDiagnosisCreateDto>
    {
        public ClinicalDiagnosisCreateValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción del diagnóstico es obligatoria.")
                .MaximumLength(250).WithMessage("El diagnóstico no puede superar 250 caracteres.");

            RuleFor(x => x.DiagnosisTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de diagnóstico válido.");
        }
    }
}
