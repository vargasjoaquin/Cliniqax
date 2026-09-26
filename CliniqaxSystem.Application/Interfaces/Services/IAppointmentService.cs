using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetAgendaAsync(DateTime date, int professionalId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByRangeAsync(DateTime start, DateTime end, int? professionalId = null, int? specialtyId = null);
        Task<OperationResult> CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto);
        Task<OperationResult> ChangeAppointmentStatusAsync(int appointmentId, AppointmentStatus newStatus, string? reason = null);
        Task<OperationResult> RescheduleAppointmentAsync(AppointmentRescheduleDto appointmentRescheduleDto);
    }
}
