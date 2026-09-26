using AutoMapper;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqaxSystem.Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork, IMapper mapper) : IReportService
    {
        public async Task<DashboardDto> GetDashboardStatsAsync()
        {
            var today = DateTime.Today;
            
            var todayAppointments = (await unitOfWork.Appointments.GetByDateRangeAsync(today, today)).ToList();

            var activeCashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();

            return new DashboardDto
            {
                TodayAppointmentsCount = todayAppointments.Count,
                PendingAppointmentsCount = todayAppointments.Count(a => a.Status == AppointmentStatus.Pending),
                ConfirmedAppointmentsCount = todayAppointments.Count(a => a.Status == AppointmentStatus.Confirmed),
                AttendedAppointmentsCount = todayAppointments.Count(a => a.Status == AppointmentStatus.Attended),
                CancelledAppointmentsCount = todayAppointments.Count(a => a.Status == AppointmentStatus.Cancelled),
                TotalIncomeToday = activeCashSession?.TotalTurnover ?? 0,
                ExpectedCashInDrawer = activeCashSession?.CurrentSystemCash ?? 0,
                UpcomingAppointments = mapper.Map<List<AppointmentDto>>(
                    todayAppointments
                        .Where(a => a.Status == AppointmentStatus.Confirmed || a.Status == AppointmentStatus.Waiting)
                        .OrderBy(a => a.StartTime)
                        .Take(5))
            };
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsReportAsync(DateTime start, DateTime end, int? professionalId = null, int? specialtyId = null)
        {
            var appointments = await unitOfWork.Appointments.GetByDateRangeAsync(start.Date, end.Date, professionalId, specialtyId);
            return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }
    }
}
