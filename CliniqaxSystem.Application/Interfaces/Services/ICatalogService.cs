using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Catalog;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ICatalogService
    {
        // Especialidades
        Task<IEnumerable<SpecialtyDto>> GetSpecialtiesAsync();
        Task<SpecialtyDto?> GetSpecialtyByIdAsync(int id);
        Task<OperationResult> CreateSpecialtyAsync(SpecialtyDto specialtyDto);
        Task<OperationResult> UpdateSpecialtyAsync(SpecialtyDto specialtyDto);
        Task<OperationResult> DeleteSpecialtyAsync(int id);
        Task<OperationResult> ToggleSpecialtyStatusAsync(int id);


        // Obras Sociales
        Task<IEnumerable<HealthInsuranceDto>> GetHealthInsurancesAsync();
        Task<HealthInsuranceDto?> GetHealthInsuranceByIdAsync(int id);
        Task<OperationResult> CreateHealthInsuranceAsync(HealthInsuranceDto healthInsuranceDto);
        Task<OperationResult> UpdateHealthInsuranceAsync(HealthInsuranceDto healthInsuranceDto);
        Task<OperationResult> DeleteHealthInsuranceAsync(int id);
        Task<OperationResult> ToggleHealthInsuranceStatusAsync(int id);
    }
}
