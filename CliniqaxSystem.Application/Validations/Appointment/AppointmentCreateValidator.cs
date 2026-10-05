using CliniqaxSystem.Application.DTOs.Appointment;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Appointment
{
    public class AppointmentCreateValidator : AbstractValidator<AppointmentCreateDto>
    {
        public AppointmentCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Debe seleccionar un paciente válido.");

            RuleFor(x => x.ProfessionalId)
                .GreaterThan(0).WithMessage("Debe seleccionar un profesional válido.");

            RuleFor(x => x.SpecialtyId)
                .GreaterThan(0).WithMessage("Debe seleccionar una especialidad válida.");

            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("La fecha del turno es obligatoria.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("No se pueden registrar turnos en fechas pasadas.");

            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).WithMessage("La hora de inicio debe ser anterior a la hora de fin.");
        }
    }
}
