using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Entities;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class CatalogService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<SpecialtyDto> specialtyValidator, IValidator<HealthInsuranceDto> healthInsuranceValidator) : ICatalogService
    {
        // ==========================================
        // ESPECIALIDADES
        // ==========================================

        public async Task<IEnumerable<SpecialtyDto>> GetSpecialtiesAsync()
        {
            var specialties = await unitOfWork.Specialties.GetAllAsync();
            return mapper.Map<IEnumerable<SpecialtyDto>>(specialties);
        }

        public async Task<SpecialtyDto?> GetSpecialtyByIdAsync(int id)
        {
            var specialty = await unitOfWork.Specialties.GetByIdAsync(id);
            return specialty == null ? null : mapper.Map<SpecialtyDto>(specialty);
        }

        public async Task<OperationResult> CreateSpecialtyAsync(SpecialtyDto SpecialtyDto)
        {
            var validation = await specialtyValidator.ValidateAsync(SpecialtyDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var specialty = mapper.Map<Specialty>(SpecialtyDto);
            
            specialty.Name = SpecialtyDto.Name.Trim();
            specialty.IsActive = true;

            await unitOfWork.Specialties.AddAsync(specialty);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Especialidad creada con éxito.", specialty.Id)
                : OperationResult.Failure("Error al registrar la especialidad.");
        }

        public async Task<OperationResult> UpdateSpecialtyAsync(SpecialtyDto SpecialtyDto)
        {
            var validation = await specialtyValidator.ValidateAsync(SpecialtyDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var specialty = await unitOfWork.Specialties.GetByIdAsync(SpecialtyDto.Id);
            
            if (specialty == null)
                return OperationResult.Failure("Especialidad no fue encontrada.");

            mapper.Map(SpecialtyDto, specialty);
            specialty.Name = SpecialtyDto.Name.Trim();

            unitOfWork.Specialties.Update(specialty);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Especialidad actualizada con éxito.", specialty.Id)
                : OperationResult.Failure("No se realizaron cambios.");
        }

        public async Task<OperationResult> DeleteSpecialtyAsync(int id)
        {
            var specialty = await unitOfWork.Specialties.GetByIdAsync(id);
            
            if (specialty == null)
                return OperationResult.Failure("Especialidad no encontrada.");

            specialty.IsDeleted = true;
            specialty.IsActive = false;

            unitOfWork.Specialties.Update(specialty);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Especialidad eliminada correctamente.")
                : OperationResult.Failure("Error al eliminar la especialidad.");
        }

        public async Task<OperationResult> ToggleSpecialtyStatusAsync(int id)
        {
            var specialty = await unitOfWork.Specialties.GetByIdAsync(id);
            
            if (specialty == null) 
                return OperationResult.Failure("La especialidad no fue encontrada.");

            specialty.IsActive = !specialty.IsActive;
            
            unitOfWork.Specialties.Update(specialty);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            string specialtyState = specialty.IsActive ? "activada" : "desactivada";
            
            return isSuccess 
                ? OperationResult.Ok($"Especialidad {specialtyState} correctamente.") 
                : OperationResult.Failure("Error al cambiar estado.");
        }

        // ==========================================
        // OBRAS SOCIALES
        // ==========================================

        public async  Task<IEnumerable<HealthInsuranceDto>> GetHealthInsurancesAsync()
        {
            var healthInsurances = await unitOfWork.HealthInsurances.GetAllAsync();
            return mapper.Map<IEnumerable<HealthInsuranceDto>>(healthInsurances);
        }

        public async Task<HealthInsuranceDto?> GetHealthInsuranceByIdAsync(int id)
        {
            var healthInsurance = await unitOfWork.HealthInsurances.GetByIdAsync(id);
            return healthInsurance == null ? null : mapper.Map<HealthInsuranceDto>(healthInsurance);
        }

        public async Task<OperationResult> CreateHealthInsuranceAsync(HealthInsuranceDto healthInsuranceDto)
        {
            var validation = await healthInsuranceValidator.ValidateAsync(healthInsuranceDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var healthInsurance = mapper.Map<HealthInsurance>(healthInsuranceDto);

            healthInsurance.Name = healthInsuranceDto.Name.Trim();
            healthInsurance.IsActive = true;

            await unitOfWork.HealthInsurances.AddAsync(healthInsurance);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Obra Social registrada exitosamente.", healthInsurance.Id)
                : OperationResult.Failure("Error al registrar la obra social.");
        }

        public async Task<OperationResult> UpdateHealthInsuranceAsync(HealthInsuranceDto healthInsuranceDto)
        {
            var validation = await healthInsuranceValidator.ValidateAsync(healthInsuranceDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var healthInsurance = await unitOfWork.HealthInsurances.GetByIdAsync(healthInsuranceDto.Id);
            
            if (healthInsurance == null)
                return OperationResult.Failure("Obra Social no encontrada.");

            mapper.Map(healthInsuranceDto, healthInsurance);
            
            healthInsurance.Name = healthInsuranceDto.Name.Trim();

            unitOfWork.HealthInsurances.Update(healthInsurance);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Obra Social actualizada exitosamente.", healthInsurance.Id)
                : OperationResult.Failure("No se realizaron cambios.");
        }

        public async  Task<OperationResult> DeleteHealthInsuranceAsync(int id)
        {
            var healthInsurance = await unitOfWork.HealthInsurances.GetByIdAsync(id);
            
            if (healthInsurance == null)
                return OperationResult.Failure("Obra Social no encontrada.");

            healthInsurance.IsDeleted = true;
            healthInsurance.IsActive = false;

            unitOfWork.HealthInsurances.Update(healthInsurance);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Obra Social dada de baja correctamente.")
                : OperationResult.Failure("Error al procesar la baja.");
        }

        public async Task<OperationResult> ToggleHealthInsuranceStatusAsync(int id)
        {
            var healthInsurance = await unitOfWork.HealthInsurances.GetByIdAsync(id);
            
            if (healthInsurance == null) 
                return OperationResult.Failure("La Obra Social no fue encontrada.");

            healthInsurance.IsActive = !healthInsurance.IsActive;
            
            unitOfWork.HealthInsurances.Update(healthInsurance);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            string healthInsuranceState = healthInsurance.IsActive ? "activada" : "desactivada";
            
            return isSuccess
                ? OperationResult.Ok($"Obra Social {healthInsuranceState} correctamente.") 
                : OperationResult.Failure("Error al cambiar estado.");
        }
    }
}
