using CliniqaxSystem.Application.DTOs.Audit;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormAuditViewer : Form
    {
        private readonly IAuditService _auditService;
        private List<AuditLogDto> _loadedLogs = new();

        public FormAuditViewer(IAuditService auditService)
        {
            _auditService = auditService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);

            // Icono overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonFilter, this.picIconFilter);

            // Fechas: últimos 7 días por defecto
            dateTimePickerStart.Value = DateTime.Today.AddDays(-7);
            dateTimePickerEnd.Value = DateTime.Today;

            this.Load += async (s, e) => await LoadAuditLogsAsync();
            this.buttonFilter.Click += async (s, e) => await LoadAuditLogsAsync();
            this.textBoxSearch.TextChanged += (s, e) => FilterLogsInGrid();
        }

        private async Task LoadAuditLogsAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var logs = await _auditService.GetAuditLogsAsync(
                    dateTimePickerStart.Value.Date,
                    dateTimePickerEnd.Value.Date);

                _loadedLogs = logs.ToList();
                FilterLogsInGrid();
            }
        }

        private void FilterLogsInGrid()
        {
            string term = textBoxSearch.Text.Trim().ToLower();

            var filtered = _loadedLogs.Where(l =>
                string.IsNullOrWhiteSpace(term) ||
                l.Username.ToLower().Contains(term) ||
                l.Action.ToLower().Contains(term) ||
                l.EntityName.ToLower().Contains(term) ||
                (l.Details != null && l.Details.ToLower().Contains(term)) ||
                (l.IpAddress != null && l.IpAddress.ToLower().Contains(term))
            ).ToList();

            dataGridViewAudit.DataSource = null;
            dataGridViewAudit.DataSource = filtered;
            UIHelper.FormatGrid(dataGridViewAudit);

            labelTotalCount.Text = $"Registros de Auditoría: {filtered.Count}";
        }
    }
}