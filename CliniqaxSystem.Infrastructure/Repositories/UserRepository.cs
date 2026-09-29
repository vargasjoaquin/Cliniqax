using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .Include(u => u.Professional)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Role)
                .Include(u => u.Professional)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await context.Users
                .Include(u => u.Role)
                .Include(u => u.Professional)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public async Task<User?> GetDeletedByIdAsync(int id)
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsDeleted);
        }

        public async Task<IEnumerable<User>> GetAllDeletedAsync()
        {
            return await context.Users
                .IgnoreQueryFilters()
                .Include(u => u.Role)
                .Where(u => u.IsDeleted)
                .OrderByDescending(u => u.LastUpdatedAt ?? u.CreatedAt)
                .ToListAsync();
        }
    }
}
