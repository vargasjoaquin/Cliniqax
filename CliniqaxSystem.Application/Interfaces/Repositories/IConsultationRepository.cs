using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IConsultationRepository
    {
        Task<Consultation?> GetByIdAsync(int id);
        Task<IEnumerable<Consultation>> GetHistoryByMedicalRecordIdAsync(int medicalRecordId);
        Task<Consultation?> GetByAppoinmentIdAsync(int appointmentId);
        Task AddAsync(Consultation consultation);
        void Update(Consultation consultation);
        Task<IEnumerable<MedicalAttachment>> GetMedicalAttachmentsByRecordIdAsync(int medicalRecordId);
        Task<MedicalAttachment?> GetAttachmentByIdAsync(int attachmentId);
        Task AddMedicalAttachmentAsync(MedicalAttachment medicalAttachment);
        void UpdateMedicalAttachment(MedicalAttachment medicalAttachment);
    }
}
