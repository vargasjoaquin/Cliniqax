using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Domain.Enums;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class AppointmentRepository(ApplicationDbContext context) : IAppointmentRepository
    {
        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await context.Appointments
                .Include(a => a.Patient)
                .ThenInclude(p => p.HealthInsurance)
                .Include(a => a.Professional)
                .Include(a => a.Specialty)
                .Include(a => a.Payments)
                .ThenInclude(pay => pay.PaymentMethod)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
        }

        public void Update(Appointment appointment)
        {
            context.Appointments.Update(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetByDateAndProfessionalAsync(DateTime date, int professionalId)
        {
            return await context.Appointments
                .AsNoTracking()
                .Include(a => a.Patient)
                .ThenInclude(p => p.HealthInsurance)
                .Include(a => a.Professional)
                .Include(a => a.Specialty)
                .Where(a => a.AppointmentDate.Date == date.Date && a.ProfessionalId == professionalId)
                .OrderBy(a => a.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, int? professionalId = null, int? specialtyId = null)
        {
            var query = context.Appointments
                .AsNoTracking()
                .Include(a => a.Patient)
                .ThenInclude(p => p.HealthInsurance)
                .Include(a => a.Professional)
                .Include(a => a.Specialty)
                .Where(a => a.AppointmentDate.Date >= startDate.Date && a.AppointmentDate.Date <= endDate.Date);

            if (professionalId.HasValue && professionalId.Value > 0)
                query = query.Where(a => a.ProfessionalId == professionalId.Value);

            if (specialtyId.HasValue && specialtyId.Value > 0)
                query = query.Where(a => a.SpecialtyId == specialtyId.Value);

            return await query
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetHistoryByPatientIdAsync(int patientId)
        {
            return await context.Appointments
                .AsNoTracking()
                .Include(a => a.Professional)
                .Include(a => a.Specialty)
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenByDescending(a => a.StartTime)
                .ToListAsync();
        }

        // Se sigue esta regla matemática de solapamiento de turnos/citas: (NuevoInicio < TurnoExistenteFin) Y (NuevoFin > TurnoExistenteInicio)
        public async Task<bool> HasOverlappingAppointmentAsync(int professionalId, DateTime date, TimeSpan start, TimeSpan end, int? excludeAppointmentId = null)
        {
            return await context.Appointments
                .AnyAsync(a =>
                    a.ProfessionalId == professionalId &&
                    a.AppointmentDate.Date == date.Date &&
                    a.Status != AppointmentStatus.Cancelled &&
                    (excludeAppointmentId == null || a.Id != excludeAppointmentId.Value) &&
                    (start < a.EndTime && end > a.StartTime));
        }

    }
}
