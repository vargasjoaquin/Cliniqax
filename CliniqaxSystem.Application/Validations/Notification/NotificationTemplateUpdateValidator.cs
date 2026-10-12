using CliniqaxSystem.Application.DTOs.Notification;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Notifications
{
    public class NotificationTemplateUpdateValidator : AbstractValidator<NotificationTemplateUpdateDto>
    {
        public NotificationTemplateUpdateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Identificador de plantilla inválido.");

            RuleFor(x => x.BodyTemplate)
                .NotEmpty().WithMessage("El cuerpo de la plantilla de mensaje es obligatorio.")
                .MaximumLength(4000).WithMessage("La plantilla no puede superar los 4000 caracteres.");

            RuleFor(x => x.SubjectTemplate)
                .MaximumLength(200).WithMessage("El asunto no puede superar los 200 caracteres.");
        }
    }
}