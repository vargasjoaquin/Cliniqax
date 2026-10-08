using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Clinical
{
    public class ConsultationCreateValidator : AbstractValidator<ConsultationCreateDto>
    {
        public ConsultationCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Debe seleccionar un paciente válido.");

            RuleFor(x => x.ProfessionalId)
                .GreaterThan(0).WithMessage("Debe asociar un profesional médico a la consulta.");

            RuleFor(x => x.SpecialtyId)
                .GreaterThan(0).WithMessage("Debe especificar la especialidad médica de atención.");

            RuleFor(x => x.ReasonForConsultation)
                .NotEmpty().WithMessage("El motivo de consulta es obligatorio.")
                .MaximumLength(500).WithMessage("El motivo de consulta no puede superar los 500 caracteres.");
        }
    }
}
