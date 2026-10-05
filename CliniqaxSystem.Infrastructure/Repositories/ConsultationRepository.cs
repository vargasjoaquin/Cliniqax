using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class ConsultationRepository(ApplicationDbContext context) : IConsultationRepository
    {
        public async Task<Consultation?> GetByIdAsync(int id)
        {
            return await context.Consultations
                .Include(c => c.MedicalRecord)
                .ThenInclude(m => m.Patient)
                .Include(c => c.Professional)
                .Include(c => c.Specialty)
                .Include(c => c.ConsultationStatus)
                .Include(c => c.Appointment)
                .Include(c => c.ClinicalEvolutions.OrderBy(e => e.EvolutionDate))
                .Include(c => c.ClinicalDiagnoses)
                .ThenInclude(d => d.DiagnosisType)
                .Include(c => c.MedicalInstructions)
                .Include(c => c.MedicalAttachments)
                .ThenInclude(a => a.AttachmentCategory)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Consultation>> GetHistoryByMedicalRecordIdAsync(int medicalRecordId)
        {
            return await context.Consultations
                .AsNoTracking()
                .Include(c => c.Professional)
                .Include(c => c.Specialty)
                .Include(c => c.ConsultationStatus)
                .Include(c => c.ClinicalDiagnoses)
                .ThenInclude(d => d.DiagnosisType)
                .Include(c => c.ClinicalEvolutions)
                .Include(c => c.MedicalInstructions)
                .Include(c => c.MedicalAttachments)
                .Where(c => c.MedicalRecordId == medicalRecordId)
                .OrderByDescending(c => c.ConsultationDate)
                .ToListAsync();
        }

        public async Task<Consultation?> GetByAppoinmentIdAsync(int appointmentId)
        {
            return await context.Consultations
                .Include(c => c.ClinicalDiagnoses)
                .Include(c => c.ClinicalEvolutions)
                .Include(c => c.MedicalInstructions)
                .FirstOrDefaultAsync(c => c.AppointmentId == appointmentId);
        }

        public async Task AddAsync(Consultation consultation)
        {
            await context.Consultations.AddAsync(consultation);
        }

        public void Update(Consultation consultation)
        {
            context.Consultations.Update(consultation);
        }

        public async Task<IEnumerable<MedicalAttachment>> GetMedicalAttachmentsByRecordIdAsync(int medicalRecordId)
        {
            return await context.MedicalAttachments
                .AsNoTracking()
                .Include(a => a.AttachmentCategory)
                .Where(a => a.MedicalRecordId == medicalRecordId)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task AddMedicalAttachmentAsync(MedicalAttachment attachment)
        {
            await context.MedicalAttachments.AddAsync(attachment);
        }

        public void UpdateMedicalAttachment(MedicalAttachment attachment)
        {
            context.MedicalAttachments.Update(attachment);
        }
    }
}
