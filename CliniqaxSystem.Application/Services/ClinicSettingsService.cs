using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Services
{
    public class ClinicSettingsService(IUnitOfWork unitOfWork, IMapper mapper) : IClinicSettingsService
    {
        public async Task<ClinicSettingsDto> GetSettingsAsync()
        {
            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            
            if (settings == null)
            {
                return new ClinicSettingsDto 
                { 
                    ClinicName = "Consultorio Médico Cliniqax" 
                };
            }
            
            return mapper.Map<ClinicSettingsDto>(settings);
        }

        public async Task<OperationResult> UpdateSettingsAsync(ClinicSettingsDto clinicSettingsDto)
        {
            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            
            if (settings == null)
            {
                settings = mapper.Map<ClinicSettings>(clinicSettingsDto);
            }
            else
            {
                mapper.Map(clinicSettingsDto, settings);
            }

            unitOfWork.ClinicSettings.Update(settings);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Configuración del consultorio actualizada correctamente.")
                : OperationResult.Failure("No se realizaron cambios en la configuración.");
        }
    }
}
