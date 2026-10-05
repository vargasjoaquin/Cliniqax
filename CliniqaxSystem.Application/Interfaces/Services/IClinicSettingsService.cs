using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicSettingsService
    {
        Task<ClinicSettingsDto> GetSettingsAsync();
        Task<OperationResult> UpdateSettingsAsync(ClinicSettingsDto clinicSettingsDto);
    }
}
