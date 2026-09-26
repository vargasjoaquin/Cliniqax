using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Application.Services
{
    public class RestoreService(IUnitOfWork unitOfWork) : IRestoreService
    {
        public async Task<IEnumerable<DeletedItemDto>> GetDeletedEntitiesAsync(string entityType)
        {
            return entityType.ToUpperInvariant() switch
            {
                "PACIENTES" => (await unitOfWork.Patients.GetAllDeletedAsync())
                    .Select(patient => new DeletedItemDto
                    {
                        Id = patient.Id,
                        EntityType = EntityNamesConstants.PATIENTS,
                        Identifier = patient.DocumentNumber,
                        Name = patient.FullName,
                        AdditionalInfo = patient.Phone,
                        DeletedAt = patient.LastUpdatedAt ?? patient.CreatedAt,
                        DeletedBy = patient.LastUpdatedBy ?? patient.CreatedBy
                    }),

                "PROFESIONALES" => (await unitOfWork.Professionals.GetAllDeletedAsync())
                    .Select(professional => new DeletedItemDto
                    {
                        Id = professional.Id,
                        EntityType = EntityNamesConstants.PROFESSIONALS,
                        Identifier = professional.LicenseNumber,
                        Name = professional.FullName,
                        AdditionalInfo = professional.DocumentNumber,
                        DeletedAt = professional.LastUpdatedAt ?? professional.CreatedAt,
                        DeletedBy = professional.LastUpdatedBy ?? professional.CreatedBy
                    }),

                "ESPECIALIDADES" => (await unitOfWork.Specialties.GetAllDeletedAsync())
                    .Select(specialty => new DeletedItemDto
                    {
                        Id = specialty.Id,
                        EntityType = EntityNamesConstants.SPECIALTIES,
                        Identifier = specialty.Id.ToString(),
                        Name = specialty.Name,
                        AdditionalInfo = specialty.Description,
                        DeletedAt = specialty.LastUpdatedAt ?? specialty.CreatedAt,
                        DeletedBy = specialty.LastUpdatedBy ?? specialty.CreatedBy
                    }),

                "OBRAS SOCIALES" => (await unitOfWork.HealthInsurances.GetAllDeletedAsync())
                    .Select(healthInsurance => new DeletedItemDto
                    {
                        Id = healthInsurance.Id,
                        EntityType = EntityNamesConstants.HEALTH_INSURANCES,
                        Identifier = healthInsurance.Cuit ?? "-",
                        Name = healthInsurance.Name,
                        AdditionalInfo = healthInsurance.Phone,
                        DeletedAt = healthInsurance.LastUpdatedAt ?? healthInsurance.CreatedAt,
                        DeletedBy = healthInsurance.LastUpdatedBy ?? healthInsurance.CreatedBy
                    }),

                "USUARIOS" => (await unitOfWork.Users.GetAllDeletedAsync())
                    .Select(user => new DeletedItemDto
                    {
                        Id = user.Id,
                        EntityType = EntityNamesConstants.USERS,
                        Identifier = user.Username,
                        Name = $"{user.LastName}, {user.FirstName}",
                        AdditionalInfo = user.Role?.Name,
                        DeletedAt = user.LastUpdatedAt ?? user.CreatedAt,
                        DeletedBy = user.LastUpdatedBy ?? user.CreatedBy
                    }),

                _ => Enumerable.Empty<DeletedItemDto>()
            };
        }

        public async Task<OperationResult> RestoreEntityAsync(string entityType, int id)
        {
            switch (entityType.ToUpperInvariant())
            {
                case "PACIENTES":
                    
                    var patient = await unitOfWork.Patients.DeleteAsync(id);
                    
                    if (patient == null) 
                        return OperationResult.Failure("Paciente no encontrado en papelera.");
                    
                    patient.IsDeleted = false;
                    patient.IsActive = true;
                    
                    unitOfWork.Patients.Update(patient);
                    break;

                case "PROFESIONALES":
                    
                    var professional = await unitOfWork.Professionals.DeleteAsync(id);
                    
                    if (professional == null) 
                        return OperationResult.Failure("Profesional no encontrado en papelera.");
                    
                    professional.IsDeleted = false;
                    professional.IsActive = true;
                    
                    unitOfWork.Professionals.Update(professional);
                    break;

                case "ESPECIALIDADES":
                    
                    var specialty = await unitOfWork.Specialties.DeleteAsync(id);
                    
                    if (specialty == null) 
                        return OperationResult.Failure("Especialidad no encontrada en papelera.");
                    
                    specialty.IsDeleted = false;
                    specialty.IsActive = true;
                    
                    unitOfWork.Specialties.Update(specialty);
                    break;

                case "OBRAS SOCIALES":
                    
                    var healthInsurance = await unitOfWork.HealthInsurances.DeleteAsync(id);
                    
                    if (healthInsurance == null) 
                        return OperationResult.Failure("Obra social no encontrada en papelera.");
                    
                    healthInsurance.IsDeleted = false;
                    healthInsurance.IsActive = true;
                    
                    unitOfWork.HealthInsurances.Update(healthInsurance);
                    break;

                case "USUARIOS":
                    
                    var user = await unitOfWork.Users.DeleteAsync(id);
                    
                    if (user == null) 
                        return OperationResult.Failure("Usuario no encontrado en papelera.");
                    
                    user.IsDeleted = false;
                    user.IsActive = true;
                    
                    unitOfWork.Users.Update(user);
                    break;

                default:
                    return OperationResult.Failure("Entidad no reconocida.");
            }

            bool isSuccess = await unitOfWork.CompleteAsync();
            
            return isSuccess
                ? OperationResult.Ok($"Registro de {entityType} restaurado correctamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }
    }
}
