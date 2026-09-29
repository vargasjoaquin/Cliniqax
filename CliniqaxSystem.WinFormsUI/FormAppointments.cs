using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Enums;
using CliniqaxSystem.WinFormsUI.Helpers;
using CliniqaxSystem.WinFormsUI.Helpers.Dialogs;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormAppointments : Form
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IProfessionalService _professionalService;
        private readonly ICatalogService _catalogService;
        private readonly IDocumentService _documentService;
        private readonly IExcelService _excelService;

        private bool _isInitializing = false;
        private List<AppointmentDto> _loadedAppointments = new();
        private AppointmentDto? _selectedAppointment = null;

        public FormAppointments(
            IAppointmentService appointmentService,
            IProfessionalService professionalService,
            ICatalogService catalogService,
            IDocumentService documentService,
            IExcelService excelService)
        {
            _appointmentService = appointmentService;
            _professionalService = professionalService;
            _catalogService = catalogService;
            _documentService = documentService;
            _excelService = excelService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);
            UIThemeHelper.ApplyCardStyle(panelActionsCard);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonFilter, this.picIconFilter);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportExcel, this.picIconExportExcel);
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirm, this.picIconConfirm);
            ButtonIconOverlayHelper.BindEvents(this.buttonWaitingRoom, this.picIconWaitingRoom);
            ButtonIconOverlayHelper.BindEvents(this.buttonMarkAttended, this.picIconAttended);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Fechas por defecto: Semana actual
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today.AddDays(7);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonFilter.Click += async (s, e) => await LoadAppointmentsAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportPdfAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportExcel();
            this.textBoxSearch.TextChanged += (s, e) => FilterAppointmentsGrid();

            // Acciones sobre turnos
            this.buttonConfirm.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Confirmed);
            this.buttonWaitingRoom.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Waiting);
            this.buttonMarkAttended.Click += async (s, e) => await ExecuteChangeStatusAsync(AppointmentStatus.Attended);
            this.buttonCancel.Click += async (s, e) => await ExecuteCancelAppointmentAsync();

            this.dataGridViewAppointments.CellClick += (s, e) => SynchronizeSelectedAppointment();
            this.dataGridViewAppointments.CellFormatting += OnGridCellFormatting;
        }

        private async Task InitializeFormAsync()
        {
            _isInitializing = true;
            try
            {
                using (new WaitCursorHelper(this))
                {
                    // 1. Cargar Médicos
                    var professionals = (await _professionalService.GetAllAsync()).ToList();
                    professionals.Insert(0, new ProfessionalDto { Id = 0, FirstName = "[ Todos los ", LastName = "Profesionales ]" });
                    comboBoxProfessional.DataSource = professionals;
                    comboBoxProfessional.DisplayMember = "FullName";
                    comboBoxProfessional.ValueMember = "Id";

                    // 2. Cargar Especialidades
                    var specialties = (await _catalogService.GetSpecialtiesAsync()).ToList();
                    specialties.Insert(0, new SpecialtyDto { Id = 0, Name = "[ Todas las Especialidades ]" });
                    comboBoxSpecialty.DataSource = specialties;
                    comboBoxSpecialty.DisplayMember = "Name";
                    comboBoxSpecialty.ValueMember = "Id";

                    // 3. Cargar Estados de Turno
                    var statuses = new List<object>
                {
                    new { Id = 0, Name = "[ Todos los Estados ]" },
                    new { Id = (int)AppointmentStatus.Pending, Name = "Pendiente" },
                    new { Id = (int)AppointmentStatus.Confirmed, Name = "Confirmado" },
                    new { Id = (int)AppointmentStatus.Waiting, Name = "En Sala de Espera" },
                    new { Id = (int)AppointmentStatus.Attended, Name = "Atendido" },
                    new { Id = (int)AppointmentStatus.Cancelled, Name = "Cancelado" },
                    new { Id = (int)AppointmentStatus.Absent, Name = "Ausente" }
                };
                    comboBoxStatus.DataSource = statuses;
                    comboBoxStatus.DisplayMember = "Name";
                    comboBoxStatus.ValueMember = "Id";
                }
            }
            finally
            {
                _isInitializing = false;
            }

            await LoadAppointmentsAsync();
        }

        private async Task LoadAppointmentsAsync()
        {
            if (_isInitializing) return;

            int? professionalId = comboBoxProfessional.SelectedValue is int pId && pId > 0 ? pId : null;
            int? specialtyId = comboBoxSpecialty.SelectedValue is int sId && sId > 0 ? sId : null;

            using (new WaitCursorHelper(this))
            {
                var appointments = await _appointmentService.GetAppointmentsByRangeAsync(
                    dateTimePickerStart.Value.Date,
                    dateTimePickerEnd.Value.Date,
                    professionalId,
                    specialtyId);

                _loadedAppointments = appointments.ToList();
                FilterAppointmentsGrid();
                ResetSelection();
            }
        }

        private void FilterAppointmentsGrid()
        {
            string term = textBoxSearch.Text.Trim().ToLower();
            int statusFilter = comboBoxStatus.SelectedValue is int stId ? stId : 0;

            var filtered = _loadedAppointments.Where(a =>
                (statusFilter == 0 || (int)a.Status == statusFilter) &&
                (string.IsNullOrWhiteSpace(term) ||
                 a.PatientName.ToLower().Contains(term) ||
                 a.PatientDocument.Contains(term) ||
                 a.ProfessionalName.ToLower().Contains(term) ||
                 a.SpecialtyName.ToLower().Contains(term) ||
                 (a.Observations != null && a.Observations.ToLower().Contains(term)))
            ).ToList();

            dataGridViewAppointments.DataSource = null;
            dataGridViewAppointments.DataSource = filtered;
            UIHelper.FormatGrid(dataGridViewAppointments);

            labelTotalCount.Text = $"Turnos encontrados: {filtered.Count}";
        }

        private void SynchronizeSelectedAppointment()
        {
            if (dataGridViewAppointments.CurrentRow == null || dataGridViewAppointments.CurrentRow.DataBoundItem is not AppointmentDto app)
            {
                ResetSelection();
                return;
            }

            _selectedAppointment = app;
            labelSelectedInfo.Text = $"Turno: {app.AppointmentDate:dd/MM/yyyy} {app.TimeSlot}  |  Paciente: {app.PatientName}  |  Estado: {app.StatusName}";
            labelSelectedInfo.ForeColor = UIThemeHelper.Primary;

            buttonConfirm.Enabled = app.Status == AppointmentStatus.Pending;
            buttonWaitingRoom.Enabled = app.Status == AppointmentStatus.Confirmed || app.Status == AppointmentStatus.Pending;
            buttonMarkAttended.Enabled = app.Status == AppointmentStatus.Waiting || app.Status == AppointmentStatus.Confirmed;
            buttonCancel.Enabled = app.Status != AppointmentStatus.Attended && app.Status != AppointmentStatus.Cancelled;
        }

        private void ResetSelection()
        {
            _selectedAppointment = null;
            labelSelectedInfo.Text = "Haga clic en un turno de la lista para operar sobre su estado.";
            labelSelectedInfo.ForeColor = UIThemeHelper.TextMuted;

            buttonConfirm.Enabled = false;
            buttonWaitingRoom.Enabled = false;
            buttonMarkAttended.Enabled = false;
            buttonCancel.Enabled = false;
        }

        private async Task ExecuteChangeStatusAsync(AppointmentStatus newStatus)
        {
            if (_selectedAppointment == null) return;

            using (new WaitCursorHelper(this))
            {
                var result = await _appointmentService.ChangeAppointmentStatusAsync(_selectedAppointment.Id, newStatus);
                UIHelper.ShowResult(result, "Gestión de Turnos", async () =>
                {
                    await LoadAppointmentsAsync();
                });
            }
        }

        private async Task ExecuteCancelAppointmentAsync()
        {
            if (_selectedAppointment == null) return;

            using var prompt = new FormBlindCashCountDialog.FormPromptDialog("Cancelar Turno", "Motivo de la cancelación:");
            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _appointmentService.ChangeAppointmentStatusAsync(_selectedAppointment.Id, AppointmentStatus.Cancelled, prompt.EnteredDescription);
                    UIHelper.ShowResult(result, "Cancelar Turno", async () =>
                    {
                        await LoadAppointmentsAsync();
                    });
                }
            }
        }

        private async Task ExecuteExportPdfAsync()
        {
            if (!_loadedAppointments.Any())
            {
                UIHelper.WarnMessage(this, "No hay turnos para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                string title = $"Listado de Turnos ({dateTimePickerStart.Value:dd/MM/yyyy} al {dateTimePickerEnd.Value:dd/MM/yyyy})";
                byte[] pdfBytes = await _documentService.GenerateAppointmentsReportPdfAsync(_loadedAppointments, title);
                string fileName = $"Turnos_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Reporte de Turnos en PDF");
            }
        }

        private void ExecuteExportExcel()
        {
            if (!_loadedAppointments.Any())
            {
                UIHelper.WarnMessage(this, "No hay turnos para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var exportData = _loadedAppointments.Select(a => new
                {
                    Fecha = a.AppointmentDate.ToString("dd/MM/yyyy"),
                    Horario = a.TimeSlot,
                    Paciente = a.PatientName,
                    DNI = a.PatientDocument,
                    Telefono = a.PatientPhone,
                    ObraSocial = a.HealthInsuranceName,
                    Afiliado = a.AffiliateNumber,
                    Profesional = a.ProfessionalName,
                    Especialidad = a.SpecialtyName,
                    Estado = a.StatusName,
                    Observaciones = a.Observations
                }).ToList();

                byte[] excelBytes = _excelService.ExportToExcel(exportData, "Turnos");
                string fileName = $"Turnos_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                _ = FileExportHelper.SaveAndOpenExcelAsync(this, excelBytes, fileName, "Reporte de Turnos en Excel");
            }
        }

        private void OnGridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewAppointments.Rows.Count) return;

            var statusName = dataGridViewAppointments.Rows[e.RowIndex].Cells["StatusName"]?.Value?.ToString();

            if (statusName == "En Espera")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Primary;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            else if (statusName == "Confirmado")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Success;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else if (statusName == "Atendido")
            {
                e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else if (statusName == "Cancelado" || statusName == "Ausente")
            {
                e.CellStyle.ForeColor = UIThemeHelper.Danger;
            }
        }
    }
}
