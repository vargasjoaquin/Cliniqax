using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IClinicSettingsRepository
    {
        Task<ClinicSettings?> GetSettingsAsync();
        void Update(ClinicSettings clinicSettings);
    }
}
