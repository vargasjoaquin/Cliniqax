using CliniqaxSystem.Application.DTOs.Professional;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Professional
{
    public class ProfessionalCreateValidator : AbstractValidator<ProfessionalCreateDto>
    {
        public ProfessionalCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El DNI/Documento del profesional es obligatorio.")
                .Length(8, 8).WithMessage("El documento debe tener 8 caracteres.")
                .Matches(@"^[0-9]+$").WithMessage("El documento solo puede contener números.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre del profesional es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido del profesional es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("La matrícula profesional es obligatoria.")
                .MaximumLength(30).WithMessage("La matrícula no puede superar los 30 caracteres.");

            RuleFor(x => x.AppointmentDuration)
                .InclusiveBetween(5, 120).WithMessage("La duración del turno debe ser de entre 5 y 120 minutos.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono de contacto es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.SpecialtyIds)
                .NotEmpty().WithMessage("Debe asociar al menos una especialidad médica al profesional.");

            RuleFor(x => x.Observations)
                .MaximumLength(500).WithMessage("Las observaciones no pueden superar los 500 caracteres.");

            RuleForEach(x => x.Schedules)
                .SetValidator(new ProfessionalScheduleValidator());
        }
    }
}