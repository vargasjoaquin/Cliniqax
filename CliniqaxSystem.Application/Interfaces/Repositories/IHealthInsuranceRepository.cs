using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IHealthInsuranceRepository
    {
        Task<IEnumerable<HealthInsurance>> GetAllAsync();
        Task<HealthInsurance?> GetByIdAsync(int id);
        Task AddAsync(HealthInsurance insurance);
        Task Update(HealthInsurance insurance);
        Task<HealthInsurance?> DeleteAsync(int id);
        Task<IEnumerable<HealthInsurance>> GetAllDeletedAsync();
    }
}
