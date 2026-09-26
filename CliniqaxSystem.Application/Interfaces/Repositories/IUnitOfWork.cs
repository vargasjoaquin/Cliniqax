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

        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();

        Task<bool> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
