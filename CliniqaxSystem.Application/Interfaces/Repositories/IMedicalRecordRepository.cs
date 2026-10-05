using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<MedicalRecord?> GetByPatientIdAsync(int patientId);
        Task<MedicalRecord?> GetByRecordNumberAsync(string recordNumber);
        Task<MedicalRecord?> GetByIdAsync(int id);
        Task AddAsync(MedicalRecord medicalRecord);
        Task Update(MedicalRecord medicalRecord);
        Task<bool> ExistsForPatientAsync(int patientId);
    }
}
