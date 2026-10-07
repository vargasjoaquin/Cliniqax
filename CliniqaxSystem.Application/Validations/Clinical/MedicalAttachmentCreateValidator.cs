using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Clinical
{
    public class MedicalAttachmentCreateValidator : AbstractValidator<MedicalAttachmentCreateDto>
    {
        public MedicalAttachmentCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Debe vincular el archivo a un paciente válido.");

            RuleFor(x => x.OriginalFileName)
                .NotEmpty().WithMessage("El nombre original del archivo es requerido.");

            RuleFor(x => x.FileBytes)
                .NotEmpty().WithMessage("El archivo seleccionado se encuentra vacío.");
        }
    }
}
