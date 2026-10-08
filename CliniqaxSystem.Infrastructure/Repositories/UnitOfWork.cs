using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Patients = new PatientRepository(_context);
            Professionals = new ProfessionalRepository(_context);
            Specialties = new SpecialtyRepository(_context);
            HealthInsurances = new HealthInsuranceRepository(_context);
            Appointments = new AppointmentRepository(_context);
            CashSessions = new CashSessionRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            ClinicSettings = new ClinicSettingsRepository(_context);
            MedicalRecords = new MedicalRecordRepository(_context);
            Consultations = new ConsultationRepository(_context);
        }

        public IPatientRepository Patients { get; }
        public IProfessionalRepository Professionals { get; }
        public ISpecialtyRepository Specialties { get; }
        public IHealthInsuranceRepository HealthInsurances { get; }
        public IAppointmentRepository Appointments { get; }
        public ICashSessionRepository CashSessions { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IClinicSettingsRepository ClinicSettings { get; }
        public IMedicalRecordRepository MedicalRecords { get; }
        public IConsultationRepository Consultations { get; }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods
                .AsNoTracking()
                .Where(pm => pm.IsActive)
                .OrderBy(pm => pm.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<DiagnosisType>> GetDiagnosisTypesAsync()
        {
            return await _context.DiagnosisTypes
                .AsNoTracking()
                .Where(d => d.IsActive)
                .OrderBy(d => d.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ConsultationStatus>> GetConsultationStatusesAsync()
        {
            return await _context.ConsultationStatuses
                .AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<AttachmentCategory>> GetAttachmentCategoriesAsync()
        {
            return await _context.AttachmentCategories
                .AsNoTracking()
                .Where(a => a.IsActive)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
