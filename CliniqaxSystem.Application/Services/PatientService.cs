using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Application.Validations.Patient;
using CliniqaxSystem.Domain.Entities;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class PatientService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<PatientCreateDto> patientValidator) : IPatientService
    {
        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var allPatients = await unitOfWork.Patients.GetAllAsync();
            return mapper.Map<IEnumerable<PatientDto>>(allPatients);
        }

        public async Task<PatientDto?> GetByIdAsync(int id)
        {
            var patient = await unitOfWork.Patients.GetByIdAsync(id);
            return patient == null ? null : mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto?> GetByDocumentAsync(string documentNumber)
        {
            var patientDocumentNumber = await unitOfWork.Patients.GetByDocumentAsync(documentNumber);
            return patientDocumentNumber == null ? null : mapper.Map<PatientDto>(patientDocumentNumber);
        }

        public async Task<OperationResult> RegisterPatientAsync(PatientCreateDto patientCreateDto)
        {
            var validation = await patientValidator.ValidateAsync(patientCreateDto);

            if (!validation.IsValid)
                return validation.ToResult();

            string patientDocumentNumber = patientCreateDto.DocumentNumber.Trim();

            var existingDocumentNumber = await unitOfWork.Patients.GetByDocumentAsync(patientDocumentNumber);

            if (existingDocumentNumber != null)
                return OperationResult.Failure($"Ya existe un paciente registrado con el DNI {patientDocumentNumber}");

            var patient = mapper.Map<Patient>(patientCreateDto);
            patient.DocumentNumber = patientDocumentNumber;

            await unitOfWork.Patients.AddAsync(patient);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Paciente registrado exitosamente.", patient.Id)
                : OperationResult.Failure("Error al guardar el paciente en la base de datos.");

        }

        public async Task<OperationResult> UpdatePatientAsync(PatientUpdateDto patientUpdateDto)
        {
            var validation = await patientValidator.ValidateAsync(patientUpdateDto);

            if (!validation.IsValid)
                return validation.ToResult();

            var patient = await unitOfWork.Patients.GetByIdAsync(patientUpdateDto.Id);

            if (patient == null)
                return OperationResult.Failure($"El paciente {patient} no fue encontrado.");

            string patientDocumentNumber = patientUpdateDto.DocumentNumber.Trim();

            if (!string.Equals(patient.DocumentNumber, patientDocumentNumber, StringComparison.OrdinalIgnoreCase))
            {
                var existingDocumentNumber = await unitOfWork.Patients.GetByDocumentAsync(patientDocumentNumber);

                if (existingDocumentNumber != null)
                    return OperationResult.Failure($"El DNI {patientDocumentNumber} ya pertenece a otro paciente.");
            }

            mapper.Map(patientUpdateDto, patient);
            patient.DocumentNumber = patientDocumentNumber;

            unitOfWork.Patients.Update(patient);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Ficha de paciente actualizada con éxito.", patient.Id)
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        public async Task<OperationResult> DeletePatientAsync(int id)
        {
            var patient = await unitOfWork.Patients.GetByIdAsync(id);
            
            if (patient ==  null)
                return OperationResult.Failure($"El paciente {patient} no fue encontrado.");

            patient.IsDeleted = true;
            patient.IsActive = false;

            unitOfWork.Patients.Update(patient);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Paciente dado de baja correctamente.")
            : OperationResult.Failure("Error al procesar la baja del paciente.");
        }

        public async Task<IEnumerable<PatientDto>> SearchPatientsAsync(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Enumerable.Empty<PatientDto>();

            string termSearch = term.Trim().ToLower();
            
            var allPatients = await unitOfWork.Patients.GetAllAsync();

            var matches = allPatients.Where(p =>
                p.DocumentNumber.Contains(termSearch, StringComparison.OrdinalIgnoreCase) ||
                p.LastName.Contains(termSearch, StringComparison.OrdinalIgnoreCase) ||
                p.FirstName.Contains(termSearch, StringComparison.OrdinalIgnoreCase))
                .Take(15);

            return mapper.Map<IEnumerable<PatientDto>>(matches);
        }
    }
}
