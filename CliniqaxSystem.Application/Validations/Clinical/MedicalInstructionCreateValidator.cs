using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Clinical
{
    public class MedicalInstructionCreateValidator : AbstractValidator<MedicalInstructionCreateDto>
    {
        public MedicalInstructionCreateValidator()
        {
            RuleFor(x => x.Instructions)
                .NotEmpty().WithMessage("El detalle de las indicaciones médicas es obligatorio.");
        }
    }
}
