using CliniqaxSystem.Application.DTOs.Appointment;

namespace CliniqaxSystem.Application.DTOs.AdminAndDashboard
{
    public class DashboardDto
    {
        public int TodayAppointmentsCount { get; set; }
        public int PendingAppointmentsCount { get; set; }
        public int ConfirmedAppointmentsCount { get; set; }
        public int AttendedAppointmentsCount { get; set; }
        public int CancelledAppointmentsCount { get; set; }
        public decimal TotalIncomeToday { get; set; }
        public decimal ExpectedCashInDrawer { get; set; }

        public List<AppointmentDto> UpcomingAppointments { get; set; } = new();
    }
}
