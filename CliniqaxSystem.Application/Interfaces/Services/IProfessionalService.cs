using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Professional;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalDto>> GetAllAsync();
        Task<ProfessionalDto?> GetByIdAsync(int id);
        Task<OperationResult> CreateProfessionalAsync(ProfessionalCreateDto professionalCreateDto);
        Task<OperationResult> UpdateProfessionalAsync(ProfessionalUpdateDto professionalUpdateDto);
        Task<OperationResult> DeleteProfessionalAsync(int id);
        Task<OperationResult> ToggleStatusAsync(int id);
    }
}
