using CliniqaxSystem.Application.DTOs.Cash;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Cash
{
    public class ConsultationPaymentCreateValidator : AbstractValidator<ConsultationPaymentCreateDto>
    {
        public ConsultationPaymentCreateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.AppointmentId)
                .GreaterThan(0).WithMessage("Debe asociar el pago a un turno válido.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("Debe seleccionar un medio de pago válido.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El total cobrado debe ser mayor a $ 0.00.");

            RuleFor(x => x.PaymentReceived)
                .GreaterThanOrEqualTo(x => x.Amount).WithMessage("El dinero recibido no puede ser inferior al total a cobrar.");
        }
    }
}
