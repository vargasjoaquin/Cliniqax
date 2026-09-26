using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await context.Roles
                .AsNoTracking()
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await context.Roles.FindAsync(id);
        }
    }
}
