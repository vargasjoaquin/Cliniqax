using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormIncomeReport : Form
    {
        private readonly IReportService _reportService;
        private readonly IExcelService _excelService;
        private List<IncomeReportDto> _currentIncomeData = new();

        public FormIncomeReport(
            IReportService reportService,
            IExcelService excelService)
        {
            _reportService = reportService;
            _excelService = excelService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelFiltersCard);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonFilter, this.picIconFilter);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportExcel, this.picIconExportExcel);

            // Rango de fechas por defecto: Mes actual
            dateTimePickerStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerEnd.Value = DateTime.Today;

            this.Load += async (s, e) => await ExecuteLoadIncomeAsync();
            this.buttonFilter.Click += async (s, e) => await ExecuteLoadIncomeAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportExcel();
        }

        private async Task ExecuteLoadIncomeAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var data = await _reportService.GetIncomeReportAsync(
                    dateTimePickerStart.Value.Date,
                    dateTimePickerEnd.Value.Date);

                _currentIncomeData = data.ToList();

                // Cálculos de totales
                decimal totalRevenue = _currentIncomeData.Sum(p => p.Amount);
                decimal totalCopay = _currentIncomeData.Sum(p => p.CopayAmount);
                decimal cashRevenue = _currentIncomeData.Where(p => p.PaymentMethodName.Contains("Efectivo", StringComparison.OrdinalIgnoreCase)).Sum(p => p.Amount);
                decimal digitalRevenue = totalRevenue - cashRevenue;

                labelTotalRevenue.Text = totalRevenue.ToString("C2");
                labelCopayTotal.Text = $"Copagos: {totalCopay:C2}";
                labelCashTotal.Text = $"Efectivo: {cashRevenue:C2}";
                labelDigitalTotal.Text = $"Digital / QR: {digitalRevenue:C2}";

                dataGridViewIncome.DataSource = null;
                dataGridViewIncome.DataSource = _currentIncomeData;
                UIHelper.FormatGrid(dataGridViewIncome);
            }
        }

        private void ExecuteExportExcel()
        {
            if (!_currentIncomeData.Any())
            {
                UIHelper.WarnMessage(this, "No hay registros de cobros para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                var exportData = _currentIncomeData.Select(p => new
                {
                    Fecha = p.Date.ToString("dd/MM/yyyy HH:mm"),
                    Comprobante = p.ReceiptNumber,
                    Paciente = p.PatientName,
                    Profesional = p.ProfessionalName,
                    Especialidad = p.SpecialtyName,
                    MedioPago = p.PaymentMethodName,
                    ImporteTotal = p.Amount,
                    CopagoObraSocial = p.CopayAmount,
                    Operador = p.CashierName
                }).ToList();

                byte[] excelBytes = _excelService.ExportToExcel(exportData, "RecaudacionConsultas");
                string fileName = $"Ingresos_Clinica_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                _ = FileExportHelper.SaveAndOpenExcelAsync(this, excelBytes, fileName, "Exportar Recaudación a Excel");
            }
        }
    }
}
