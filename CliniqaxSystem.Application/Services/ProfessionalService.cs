using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Entities;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class ProfessionalService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<ProfessionalCreateDto> createProfessionalValidator,
                                    IValidator<ProfessionalUpdateDto> updateProfessionalValidator) : IProfessionalService
    {
        public async Task<IEnumerable<ProfessionalDto>> GetAllAsync()
        {
            var professionals = await unitOfWork.Professionals.GetAllAsync();
            return mapper.Map<IEnumerable<ProfessionalDto>>(professionals);
        }

        public async Task<ProfessionalDto?> GetByIdAsync(int id)
        {
            var professional = await unitOfWork.Professionals.GetByIdAsync(id);
            return professional == null ? null : mapper.Map<ProfessionalDto>(professional);
        }

        public async Task<OperationResult> CreateProfessionalAsync(ProfessionalCreateDto professionalCreateDto)
        {
            var validation = await createProfessionalValidator.ValidateAsync(professionalCreateDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string professionalDocumentNumber = professionalCreateDto.DocumentNumber.Trim();
            string professionalLicenseNumber = professionalCreateDto.LicenseNumber.Trim();

            var existingDocumentNumber = await unitOfWork.Professionals.GetByDocumentAsync(professionalDocumentNumber);

            if (existingDocumentNumber != null)
                return OperationResult.Failure($"El DNI '{professionalDocumentNumber}' ya pertenece a otro profesional registrado.");

            var existingLicenseNumber = await unitOfWork.Professionals.GetByLicenseNumberAsync(professionalLicenseNumber);

            if (existingLicenseNumber != null)
                return OperationResult.Failure($"La matrícula '{professionalLicenseNumber}' ya pertenece a otro profesional registrado.");

            var professional = mapper.Map<Professional>(professionalCreateDto);
            
            professional.DocumentNumber = professionalDocumentNumber;
            professional.LicenseNumber = professionalLicenseNumber;
            professional.IsActive = true;

            // Mapeo de Especialidades asignadas
            foreach (var specialtyId in professionalCreateDto.SpecialtyIds)
            {
                professional.ProfessionalSpecialties.Add(new ProfessionalSpecialty
                {
                    SpecialtyId = specialtyId
                });
            }

            // Mapeo de Horarios semanales
            foreach (var scheduleDto in professionalCreateDto.Schedules)
            {
                professional.Schedules.Add(new ProfessionalSchedule
                {
                    DayOfWeek = scheduleDto.DayOfWeek,
                    StartTime = scheduleDto.StartTime,
                    EndTime = scheduleDto.EndTime,
                    IsActive = true
                });
            }

            await unitOfWork.Professionals.AddAsync(professional);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok($"Profesional registrado exitosamente (Id del profesional: {professional.Id}).")
                : OperationResult.Failure("Error al guardar el profesional.");
        }

        public async Task<OperationResult> UpdateProfessionalAsync(ProfessionalUpdateDto professionalUpdateDto)
        {
            var validation = await updateProfessionalValidator.ValidateAsync(professionalUpdateDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var professional = await unitOfWork.Professionals.GetByIdAsync(professionalUpdateDto.Id);

            if (professional == null)
                return OperationResult.Failure($"El profesional con ID {professionalUpdateDto.Id} no fue encontrado.");

            string professionalDocumentNumber = professionalUpdateDto.DocumentNumber.Trim();
            string professionalLicenseNumber = professionalUpdateDto.LicenseNumber.Trim();

            var existingDocumentNumber = await unitOfWork.Professionals.GetByDocumentAsync(professionalDocumentNumber);

            if (existingDocumentNumber != null && existingDocumentNumber.Id != professionalUpdateDto.Id)
                return OperationResult.Failure($"El DNI '{professionalDocumentNumber}' ya pertenece a otro profesional registrado.");

            var existingLicenseNumber = await unitOfWork.Professionals.GetByLicenseNumberAsync(professionalLicenseNumber);
            
            if (existingLicenseNumber != null && existingLicenseNumber.Id != professionalUpdateDto.Id)
                return OperationResult.Failure($"La matrícula '{professionalLicenseNumber}' ya pertenece a otro profesional.");

            mapper.Map(professionalUpdateDto, professional);
            
            professional.DocumentNumber = professionalUpdateDto.DocumentNumber.Trim();
            professional.LicenseNumber = professionalLicenseNumber;

            professional.AppointmentDuration = professionalUpdateDto.AppointmentDuration;

            professional.ProfessionalSpecialties.Clear();
            foreach (var specialtyId in professionalUpdateDto.SpecialtyIds)
            {
                professional.ProfessionalSpecialties.Add(new ProfessionalSpecialty
                {
                    ProfessionalId = professional.Id,
                    SpecialtyId = specialtyId
                });
            }

            // Actualizar Horarios de atención
            professional.Schedules.Clear();
            foreach (var scheduleDto in professionalUpdateDto.Schedules)
            {
                professional.Schedules.Add(new ProfessionalSchedule
                {
                    ProfessionalId = professional.Id,
                    DayOfWeek = scheduleDto.DayOfWeek,
                    StartTime = scheduleDto.StartTime,
                    EndTime = scheduleDto.EndTime,
                    IsActive = scheduleDto.IsActive
                });
            }

            unitOfWork.Professionals.Update(professional);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok($"Datos del profesional actualizados exitosamente. Id del profesional: {professional.Id} ")
                : OperationResult.Failure("No se realizaron cambios.");
        }

        public async Task<OperationResult> DeleteProfessionalAsync(int id)
        {
            var professional = await unitOfWork.Professionals.GetByIdAsync(id);

            if (professional == null)
                return OperationResult.Failure($"El profesional con ID {id} no fue encontrado.");

            professional.IsDeleted = true;
            professional.IsActive = false;

            unitOfWork.Professionals.Update(professional);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Profesional dado de baja exitosamente.")
                : OperationResult.Failure("Error al dar de baja al profesional.");
        }

        public async Task<OperationResult> ToggleStatusAsync(int id)
        {
            var professional = await unitOfWork.Professionals.GetByIdAsync(id);
            
            if (professional == null)
                return OperationResult.Failure("Profesional no encontrado.");

            professional.IsActive = !professional.IsActive;
            
            unitOfWork.Professionals.Update(professional);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            string professionalState = professional.IsActive ? "activado" : "desactivado";
            
            return isSuccess
                ? OperationResult.Ok($"Profesional {professionalState} correctamente.")
                : OperationResult.Failure("Error al actualizar el estado.");
        }
    }
}
