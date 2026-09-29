using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> GetAllAsync();
        Task<Specialty?> GetByIdAsync(int id);
        Task AddAsync(Specialty specialty);
        void Update(Specialty specialty);
        Task<Specialty?> GetDeletedByIdAsync(int id);
        Task<IEnumerable<Specialty>> GetAllDeletedAsync();
    }
}
