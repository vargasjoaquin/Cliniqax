using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class ClinicSettingsRepository(ApplicationDbContext context) : IClinicSettingsRepository
    {
        public async Task<ClinicSettings?> GetSettingsAsync()
        {
            return await context.ClinicSettings.FirstOrDefaultAsync();
        }

        public void Update(ClinicSettings clinicSettings)
        {
            context.ClinicSettings.Update(clinicSettings);
        }
    }
}
