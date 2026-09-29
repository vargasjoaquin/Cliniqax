using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormHome : Form
    {
        private readonly IReportService _reportService;
        private readonly SemaphoreSlim _dashboardLock = new(1, 1);

        public FormHome(IReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();

            UIThemeHelper.ApplyFormStyle(this);

            this.Load += async (s, e) => await RefreshDashboardMetricsAndTablesAsync();
        }

        public async Task RefreshDashboardMetricsAndTablesAsync()
        {
            if (!await _dashboardLock.WaitAsync(0))
                return;

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var stats = await _reportService.GetDashboardStatsAsync();

                    labelTodayAppointmentsCount.Text = stats.TodayAppointmentsCount.ToString();
                    labelWaitingAndConfirmedCount.Text = (stats.ConfirmedAppointmentsCount + stats.PendingAppointmentsCount).ToString();
                    labelAttendedCount.Text = stats.AttendedAppointmentsCount.ToString();
                    labelTodayIncome.Text = stats.TotalIncomeToday.ToString("C2");

                    dataGridViewUpcomingAppointments.DataSource = null;
                    dataGridViewUpcomingAppointments.AutoGenerateColumns = true;
                    dataGridViewUpcomingAppointments.DataSource = stats.UpcomingAppointments.ToList();

                    UIHelper.FormatGrid(dataGridViewUpcomingAppointments);
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"No se pudieron cargar las métricas del panel principal:\n{ex.Message}", "Dashboard");
                }
                finally
                {
                    _dashboardLock.Release();
                }
            }
        }
    }
}
