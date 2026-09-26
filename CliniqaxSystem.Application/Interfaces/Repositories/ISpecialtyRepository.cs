using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> GetAllAsync();
        Task<Specialty?> GetByIdAsync(int id);
        Task AddAsync(Specialty specialty);
        Task Update(Specialty specialty);
        Task<Specialty?> DeleteAsync(int id);
        Task<IEnumerable<Specialty>> GetAllDeletedAsync();
    }
}
