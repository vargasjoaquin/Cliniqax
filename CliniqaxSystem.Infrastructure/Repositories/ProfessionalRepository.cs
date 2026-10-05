using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class ProfessionalRepository(ApplicationDbContext context) : IProfessionalRepository
    {
        public async Task<IEnumerable<Professional>> GetAllAsync()
        {
            return await context.Professionals
                .AsNoTracking()
                .Include(p => p.ProfessionalSpecialties)
                .ThenInclude(ps => ps.Specialty)
                .Include(p => p.Schedules)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
        }

        public async Task<Professional?> GetByIdAsync(int id)
        {
            return await context.Professionals
                .Include(p => p.ProfessionalSpecialties)
                .ThenInclude(ps => ps.Specialty)
                .Include(p => p.Schedules)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Professional?> GetByLicenseNumberAsync(string licenseNumber)
        {
            return await context.Professionals
                .FirstOrDefaultAsync(p => p.LicenseNumber == licenseNumber);
        }

        public async Task<Professional?> GetByDocumentAsync(string documentNumber)
        {
            return await context.Professionals
                .FirstOrDefaultAsync(p => p.DocumentNumber == documentNumber);
        }

        public async Task AddAsync(Professional p)
        {
            await context.Professionals.AddAsync(p);
        }

        public void Update(Professional p)
        {
            context.Professionals.Update(p);
        }

        public async Task<Professional?> GetDeletedByIdAsync(int id)
        {
            return await context.Professionals
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted);
        }

        public async Task<IEnumerable<Professional>> GetAllDeletedAsync()
        {
            return await context.Professionals
                .IgnoreQueryFilters()
                .Where(p => p.IsDeleted)
                .OrderByDescending(p => p.LastUpdatedAt ?? p.CreatedAt)
                .ToListAsync();
        }
    }
}
