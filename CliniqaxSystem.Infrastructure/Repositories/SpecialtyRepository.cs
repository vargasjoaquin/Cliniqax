using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class SpecialtyRepository(ApplicationDbContext context) : ISpecialtyRepository
    {
        public async Task<IEnumerable<Specialty>> GetAllAsync()
        {
            return await context.Specialties
                .AsNoTracking()
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Specialty?> GetByIdAsync(int id)
        {
            return await context.Specialties.FindAsync(id);
        }

        public async Task AddAsync(Specialty specialty)
        {
            await context.Specialties.AddAsync(specialty);
        }

        public void Update(Specialty specialty)
        {
            context.Specialties.Update(specialty);
        }

        public async Task<Specialty?> DeleteAsync(int id)
        {
            return await context.Specialties
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted);
        }

        public async Task<IEnumerable<Specialty>> GetAllDeletedAsync()
        {
            return await context.Specialties
                .IgnoreQueryFilters()
                .Where(s => s.IsDeleted)
                .OrderByDescending(s => s.LastUpdatedAt ?? s.CreatedAt)
                .ToListAsync();
        }
    }
}
