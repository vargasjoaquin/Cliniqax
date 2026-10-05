using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient?> GetByDocumentAsync(string documentNumber);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        Task<Patient?> GetDeletedByIdAsync(int id);
        Task<IEnumerable<Patient?>> GetAllDeletedAsync();
    }
}
