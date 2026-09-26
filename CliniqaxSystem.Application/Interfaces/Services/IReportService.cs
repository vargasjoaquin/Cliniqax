using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.DTOs.Appointment;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IReportService
    {
        Task<DashboardDto> GetDashboardStatsAsync();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsReportAsync(DateTime start, DateTime end, int? professionalId = null, int? specialtyId = null);
    }
}
