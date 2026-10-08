using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Clinical
{
    public class MedicalRecordUpdateValidator : AbstractValidator<MedicalRecordUpdateDto>
    {
        public MedicalRecordUpdateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Identificador de paciente inválido.");

            RuleFor(x => x.BloodType)
                .MaximumLength(10).WithMessage("El grupo sanguíneo no puede superar los 10 caracteres.");

            RuleFor(x => x.Allergies)
                .MaximumLength(500).WithMessage("El campo de alergias no puede superar los 500 caracteres.");
        }
    }
}
