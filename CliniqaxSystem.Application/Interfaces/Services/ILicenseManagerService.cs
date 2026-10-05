using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.License;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ILicenseManagerService
    {
        Task<OperationResult> ValidateInstalledLicenseAsync();
        Task<OperationResult> ActivateOnlineAsync(string cuit, string licenseKey);
        LicenseInformationDto? CurrentLicense { get; }
    }
}
