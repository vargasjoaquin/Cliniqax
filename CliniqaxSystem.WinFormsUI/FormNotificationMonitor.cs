using CliniqaxSystem.Application.DTOs.Notification;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormNotificationMonitor : Form
    {
        private readonly INotificationService _notificationService;
        private List<NotificationDto> _loadedNotifications = new();

        public FormNotificationMonitor(INotificationService notificationService)
        {
            _notificationService = notificationService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);
            UIThemeHelper.ApplyCardStyle(panelActionsCard);

            // Iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonFilter, this.picIconFilter);
            ButtonIconOverlayHelper.BindEvents(this.buttonProcessQueueNow, this.picIconProcessQueue);
            ButtonIconOverlayHelper.BindEvents(this.buttonRetry, this.picIconRetry);

            // Fechas por defecto: últimos 3 días
            dateTimePickerStart.Value = DateTime.Today.AddDays(-3);
            dateTimePickerEnd.Value = DateTime.Today.AddDays(1);

            this.Load += async (s, e) => await LoadNotificationsHistoryAsync();
            this.buttonFilter.Click += async (s, e) => await LoadNotificationsHistoryAsync();
            this.buttonProcessQueueNow.Click += async (s, e) => await ExecuteProcessQueueAsync();
            this.buttonRetry.Click += async (s, e) => await ExecuteRetryNotificationAsync();
            this.dataGridViewNotifications.CellClick += (s, e) => SynchronizeSelectedNotification();
        }

        private async Task LoadNotificationsHistoryAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var history = await _notificationService.GetNotificationHistoryAsync(
                    dateTimePickerStart.Value.Date,
                    dateTimePickerEnd.Value.Date);

                _loadedNotifications = history.ToList();
                dataGridViewNotifications.DataSource = null;
                dataGridViewNotifications.DataSource = _loadedNotifications;
                UIHelper.FormatGrid(dataGridViewNotifications);

                labelTotalCount.Text = $"Notificaciones Registradas: {_loadedNotifications.Count}";
                buttonRetry.Enabled = false;
            }
        }

        private void SynchronizeSelectedNotification()
        {
            if (dataGridViewNotifications.CurrentRow?.DataBoundItem is NotificationDto n)
            {
                // Solo se permite reintentar si falló o fue cancelada
                buttonRetry.Enabled = n.StatusName.Equals("Fallida", StringComparison.OrdinalIgnoreCase)
                                   || n.StatusName.Equals("Reintentando", StringComparison.OrdinalIgnoreCase);

                labelSelectedInfo.Text = $"ID: #{n.Id}  |  Canal: {n.ChannelName}  |  Destinatario: {n.Recipient}  |  Estado: {n.StatusName}";
            }
            else
            {
                buttonRetry.Enabled = false;
                labelSelectedInfo.Text = "Haga clic en una notificación para ver opciones.";
            }
        }

        private async Task ExecuteProcessQueueAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var result = await _notificationService.ProcessPendingNotificationsQueueAsync();
                UIHelper.ShowResult(result, "Procesamiento de Cola", async () =>
                {
                    await LoadNotificationsHistoryAsync();
                });
            }
        }

        private async Task ExecuteRetryNotificationAsync()
        {
            if (dataGridViewNotifications.CurrentRow?.DataBoundItem is NotificationDto n)
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _notificationService.RetryNotificationAsync(n.Id);
                    UIHelper.ShowResult(result, "Reintento de Notificación", async () =>
                    {
                        await LoadNotificationsHistoryAsync();
                    });
                }
            }
        }
    }
}