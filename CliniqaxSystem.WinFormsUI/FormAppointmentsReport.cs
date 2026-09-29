using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Enums;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormAppointmentsReport : Form
    {
        private readonly IReportService _reportService;
        private readonly IProfessionalService _professionalService;
        private readonly ICatalogService _catalogService;
        private readonly IDocumentService _documentService;
        private readonly IExcelService _excelService;

        private bool _isInitializing = false;
        private List<AppointmentDto> _currentReportData = new();

        public FormAppointmentsReport(
            IReportService reportService,
            IProfessionalService professionalService,
            ICatalogService catalogService,
            IDocumentService documentService,
            IExcelService excelService)
        {
            _reportService = reportService;
            _professionalService = professionalService;
            _catalogService = catalogService;
            _documentService = documentService;
            _excelService = excelService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonFilter, this.picIconFilter);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportExcel, this.picIconExportExcel);

            // Rango de fechas por defecto: Mes actual
            dateTimePickerStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerEnd.Value = DateTime.Today;

            this.dataGridViewReport.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewReport, e);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonFilter.Click += async (s, e) => await ExecuteLoadReportAsync();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportPdfAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportExcel();
        }

        private async Task InitializeFormAsync()
        {
            _isInitializing = true;
            try
            {
                using (new WaitCursorHelper(this))
                {
                    // Cargar Médicos
                    var professionals = (await _professionalService.GetAllAsync()).ToList();
                    professionals.Insert(0, new ProfessionalDto { Id = 0, FirstName = "[ Todos los ", LastName = "Profesionales ]" });
                    comboBoxProfessional.DataSource = professionals;
                    comboBoxProfessional.DisplayMember = "FullName";
                    comboBoxProfessional.ValueMember = "Id";

                    // Cargar Especialidades
                    var specialties = (await _catalogService.GetSpecialtiesAsync()).ToList();
                    specialties.Insert(0, new SpecialtyDto { Id = 0, Name = "[ Todas las Especialidades ]" });
                    comboBoxSpecialty.DataSource = specialties;
                    comboBoxSpecialty.DisplayMember = "Name";
                    comboBoxSpecialty.ValueMember = "Id";
                }
            }
            finally
            {
                _isInitializing = false;
            }

            await ExecuteLoadReportAsync();
        }

        private async Task ExecuteLoadReportAsync()
        {
            if (_isInitializing) return;

            int? professionalId = comboBoxProfessional.SelectedValue is int pId && pId > 0 ? pId : null;
            int? specialtyId = comboBoxSpecialty.SelectedValue is int sId && sId > 0 ? sId : null;

            using (new WaitCursorHelper(this))
            {
                var data = await _reportService.GetAppointmentsReportAsync(
                    dateTimePickerStart.Value.Date,
                    dateTimePickerEnd.Value.Date,
                    professionalId,
                    specialtyId);

                _currentReportData = data.ToList();

                // Actualizar contadores analíticos
                int total = _currentReportData.Count;
                int attended = _currentReportData.Count(a => a.Status == AppointmentStatus.Attended);
                int cancelled = _currentReportData.Count(a => a.Status == AppointmentStatus.Cancelled);
                int absent = _currentReportData.Count(a => a.Status == AppointmentStatus.Absent);

                labelTotalCount.Text = $"Total: {total}";
                labelAttendedCount.Text = $"Atendidos: {attended}";
                labelCancelledCount.Text = $"Cancelados: {cancelled}";
                labelAbsentCount.Text = $"Ausentes: {absent}";

                dataGridViewReport.DataSource = null;
                dataGridViewReport.DataSource = _currentReportData;
                UIHelper.FormatGrid(dataGridViewReport);
            }
        }

        private async Task ExecuteExportPdfAsync()
        {
            if (!_currentReportData.Any())
            {
                UIHelper.WarnMessage(this, "No hay turnos para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                string title = $"Informe de Turnos ({dateTimePickerStart.Value:dd/MM/yyyy} al {dateTimePickerEnd.Value:dd/MM/yyyy})";
                byte[] pdfBytes = await _documentService.GenerateAppointmentsReportPdfAsync(_currentReportData, title);
                string fileName = $"Reporte_Turnos_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Exportar Reporte de Turnos");
            }
        }

        private void ExecuteExportExcel()
        {
            if (!_currentReportData.Any())
            {
                UIHelper.WarnMessage(this, "No hay turnos para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var exportData = _currentReportData.Select(a => new
                {
                    Fecha = a.AppointmentDate.ToString("dd/MM/yyyy"),
                    Horario = a.TimeSlot,
                    Paciente = a.PatientName,
                    DNI = a.PatientDocument,
                    Telefono = a.PatientPhone,
                    ObraSocial = a.HealthInsuranceName,
                    Profesional = a.ProfessionalName,
                    Especialidad = a.SpecialtyName,
                    Estado = a.StatusName,
                    MotivoCancelacion = a.CancellationReason ?? "",
                    Observaciones = a.Observations ?? ""
                }).ToList();

                byte[] excelBytes = _excelService.ExportToExcel(exportData, "ReporteTurnos");
                string fileName = $"Reporte_Turnos_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                _ = FileExportHelper.SaveAndOpenExcelAsync(this, excelBytes, fileName, "Exportar a Excel");
            }
        }
    }
}
