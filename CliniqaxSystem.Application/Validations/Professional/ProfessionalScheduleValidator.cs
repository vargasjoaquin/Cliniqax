using CliniqaxSystem.Application.DTOs.Professional;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Professional
{
    public class ProfessionalScheduleValidator : AbstractValidator<ProfessionalScheduleDto>
    {
        public ProfessionalScheduleValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.DayOfWeek)
                .IsInEnum().WithMessage("El día de la semana configurado no es válido.");

            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).WithMessage("La hora de inicio de atención debe ser anterior a la hora de fin.");
        }
    }
}