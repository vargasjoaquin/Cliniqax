using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<Professional>> GetAllAsync();
        Task<Professional?> GetByIdAsync(int id);
        Task<Professional?> GetByLicenseNumberAsync(string licenseNumber);
        Task<Professional?> GetByDocumentAsync(string documentNumber);
        Task AddAsync(Professional professional);
        void Update(Professional professional);
        Task<Professional?> GetDeletedByIdAsync(int id);
        Task<IEnumerable<Professional>> GetAllDeletedAsync();
    }
}
