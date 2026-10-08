using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IProfessionalRepository Professionals { get; }
        ISpecialtyRepository Specialties { get; }
        IHealthInsuranceRepository HealthInsurances { get; }
        IAppointmentRepository Appointments { get; }
        ICashSessionRepository CashSessions { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IClinicSettingsRepository ClinicSettings { get; }
        IMedicalRecordRepository MedicalRecords { get; }
        IConsultationRepository Consultations { get; }

        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
        Task<IEnumerable<DiagnosisType>> GetDiagnosisTypesAsync();
        Task<IEnumerable<ConsultationStatus>> GetConsultationStatusesAsync();
        Task<IEnumerable<AttachmentCategory>> GetAttachmentCategoriesAsync();

        Task<bool> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
