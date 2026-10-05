using CliniqaxSystem.Application.DTOs.Patient;
using FluentValidation;

namespace CliniqaxSystem.Application.Validations.Patient
{
    public class PatientUpdateValidator : AbstractValidator<PatientUpdateDto>
    {
        public PatientUpdateValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Identificador de paciente inválido.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El DNI/Documento del paciente es obligatorio.")
                .Length(8, 8).WithMessage("El documento debe tener 8 caracteres.")
                .Matches(@"^[0-9]+$").WithMessage("El documento solo puede contener números.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre del paciente es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido del paciente es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                .LessThan(DateTime.Today).WithMessage("La fecha de nacimiento no puede ser futura.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono del paciente es obligatorio.")
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo electrónico no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Address)
                .MaximumLength(150).WithMessage("La dirección no puede superar los 150 caracteres.");

            RuleFor(x => x.AffiliateNumber)
                .MaximumLength(50).WithMessage("El número de afiliado no puede superar los 50 caracteres.");
        }
    }
}
