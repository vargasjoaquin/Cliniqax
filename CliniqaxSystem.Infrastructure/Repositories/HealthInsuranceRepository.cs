using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class HealthInsuranceRepository(ApplicationDbContext context) : IHealthInsuranceRepository
    {
        public async Task<IEnumerable<HealthInsurance>> GetAllAsync()
        {
            return await context.HealthInsurances
                 .AsNoTracking()
                 .OrderBy(h => h.Name)
                 .ToListAsync();
        }

        public async Task<HealthInsurance?> GetByIdAsync(int id)
        {
            return await context.HealthInsurances.FindAsync(id);
        }

        public async Task AddAsync(HealthInsurance insurance)
        {
            await context.HealthInsurances.AddAsync(insurance);
        }

        public void Update(HealthInsurance insurance)
        {
            context.HealthInsurances.Update(insurance);
        }

        public async Task<HealthInsurance?> DeleteAsync(int id)
        {
            return await context.HealthInsurances
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(h => h.Id == id && h.IsDeleted);
        }

        public async Task<IEnumerable<HealthInsurance>> GetAllDeletedAsync()
        {
            return await context.HealthInsurances
                .IgnoreQueryFilters()
                .Where(h => h.IsDeleted)
                .OrderByDescending(h => h.LastUpdatedAt ?? h.CreatedAt)
                .ToListAsync();
        } 
    }
}
