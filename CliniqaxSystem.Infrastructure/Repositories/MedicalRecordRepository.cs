using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class MedicalRecordRepository(ApplicationDbContext context) : IMedicalRecordRepository
    {
        public async Task<MedicalRecord?> GetByPatientIdAsync(int patientId)
        {
            return await context.MedicalRecords
                .Include(m => m.Patient)
                .ThenInclude(p => p.HealthInsurance)
                .Include(m => m.Consultations)
                .ThenInclude(c => c.Professional)
                .Include(m => m.Consultations)
                .ThenInclude(c => c.Specialty)
                .Include(m => m.Consultations)
                .ThenInclude(c => c.ConsultationStatus)
                .Include(m => m.MedicalAttachments)
                .ThenInclude(a => a.AttachmentCategory)
                .FirstOrDefaultAsync(m => m.PatientId == patientId);
        }

        public async Task<MedicalRecord?> GetByRecordNumberAsync(string recordNumber)
        {
            return await context.MedicalRecords
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.RecordNumber == recordNumber);
        }

        public async Task<MedicalRecord?> GetByIdAsync(int id)
        {
            return await context.MedicalRecords
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(MedicalRecord medicalRecord)
        {
            await context.MedicalRecords.AddAsync(medicalRecord);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Update(medicalRecord);
        }

        public async Task<bool> ExistsForPatientAsync(int patientId)
        {
            return await context.MedicalRecords.AnyAsync(m => m.PatientId == patientId);
        }
    }
}
