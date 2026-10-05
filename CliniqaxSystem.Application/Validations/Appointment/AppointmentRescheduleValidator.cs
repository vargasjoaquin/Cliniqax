using CliniqaxSystem.Application.DTOs.Appointment;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Appointment
{
    public class AppointmentRescheduleValidator : AbstractValidator<AppointmentRescheduleDto>
    {
        public AppointmentRescheduleValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.AppointmentId)
                .GreaterThan(0).WithMessage("Identificador de turno inválido.");

            RuleFor(x => x.NewDate)
                .NotEmpty().WithMessage("La nueva fecha es obligatoria.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La nueva fecha no puede ser en el pasado.");

            RuleFor(x => x.NewStartTime)
                .LessThan(x => x.NewEndTime).WithMessage("La hora de inicio debe ser anterior a la hora de fin.");
        }
    }
}
