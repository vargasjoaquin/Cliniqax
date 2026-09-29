using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await context.Patients
                .AsNoTracking()
                .Include(patient => patient.HealthInsurance)
                .OrderBy(patient => patient.LastName)
                .ThenBy(patient => patient.FirstName)
                .ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await context.Patients
                .Include(patient => patient.HealthInsurance)
                .FirstOrDefaultAsync(patient => patient.Id == id);
        }

        public async Task<Patient?> GetByDocumentAsync(string documentNumber)
        {
            return await context.Patients
                .Include(patient => patient.HealthInsurance)
                .FirstOrDefaultAsync(patient => patient.DocumentNumber == documentNumber);
        }

        public async Task AddAsync(Patient patient)
        {
            await context.Patients.AddAsync(patient);
        }

        public void Update(Patient patient)
        {
            context.Patients.Update(patient);
        }

        public async Task<Patient?> GetDeletedByIdAsync(int id)
        {
            return await context.Patients
                .IgnoreQueryFilters()
                .Include(patient => patient.HealthInsurance)
                .FirstOrDefaultAsync(patient => patient.Id == id && patient.IsDeleted);
        }

        public async Task<IEnumerable<Patient?>> GetAllDeletedAsync()
        {
            return await context.Patients
                .IgnoreQueryFilters()
                .Include(patient => patient.HealthInsurance)
                .Where(patient => patient.IsDeleted)
                .OrderByDescending(patient => patient.LastUpdatedAt ?? patient.CreatedAt)
                .ToListAsync();
        }


    }
}
