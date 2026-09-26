using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(int id);
        Task AddAsync(Appointment appointment);
        Task Update(Appointment appointment);
        Task<IEnumerable<Appointment>> GetByDateAndProfessionalAsync(DateTime time, int professionalId);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startTime, DateTime endTime, int? professionalId = null, int? specialtyId = null);
        Task<IEnumerable<Appointment>> GetHistoryByPatientIdAsync(int patientId);
        Task<bool> HasOverlappingAppointmentAsync(int professionalId, DateTime date, TimeSpan start, TimeSpan end, int? excludeAppointmentId = null);
    }
}
