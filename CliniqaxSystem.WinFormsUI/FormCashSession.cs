using CliniqaxSystem.Application.DTOs.Cash;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Enums;
using CliniqaxSystem.WinFormsUI.Helpers;
using CliniqaxSystem.WinFormsUI.Helpers.Dialogs;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormCashSession : Form
    {
        private readonly ICashSessionService _cashSessionService;
        private readonly IDocumentService _documentService;
        private readonly IAppointmentService _appointmentService;
        private readonly ICurrentUserService _currentUserService;

        private CashSessionDto? _currentSession;

        public FormCashSession(
            ICashSessionService cashSessionService,
            IDocumentService documentService,
            IAppointmentService appointmentService,
            ICurrentUserService currentUserService)
        {
            _cashSessionService = cashSessionService;
            _documentService = documentService;
            _appointmentService = appointmentService;
            _currentUserService = currentUserService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelOpenSession);
            UIThemeHelper.ApplyCardStyle(panelActiveSession);
            UIThemeHelper.ApplyCardStyle(panelMovementsContainer);

            // Vinculación de Iconos Overlay (Patrón Compriax)
            ButtonIconOverlayHelper.BindEvents(this.buttonOpenSession, this.picIconOpenSession);
            ButtonIconOverlayHelper.BindEvents(this.buttonChargeConsultation, this.picIconChargeConsultation);
            ButtonIconOverlayHelper.BindEvents(this.buttonRegisterCashIn, this.picIconRegisterCashIn);
            ButtonIconOverlayHelper.BindEvents(this.buttonRegisterCashOut, this.picIconRegisterCashOut);
            ButtonIconOverlayHelper.BindEvents(this.buttonPrintPartialCloseX, this.picIconPrintPartialCloseX);
            ButtonIconOverlayHelper.BindEvents(this.buttonCloseSessionZ, this.picIconCloseSessionZ);

            // Eventos
            this.Load += async (s, e) => await RefreshSessionStatusAsync();
            this.buttonOpenSession.Click += async (s, e) => await ExecuteOpenSessionAsync();
            this.buttonChargeConsultation.Click += async (s, e) => await ExecuteChargeConsultationDialogAsync();
            this.buttonRegisterCashIn.Click += async (s, e) => await ExecuteManualMovementAsync(CashMovementType.CashIn);
            this.buttonRegisterCashOut.Click += async (s, e) => await ExecuteManualMovementAsync(CashMovementType.CashOut);
            this.buttonPrintPartialCloseX.Click += async (s, e) => await ExecutePrintSessionTicketAsync(isZClose: false);
            this.buttonCloseSessionZ.Click += async (s, e) => await ExecuteCloseSessionAndBlindCountAsync();
        }

        private async Task RefreshSessionStatusAsync()
        {
            using (new WaitCursorHelper(this))
            {
                _currentSession = await _cashSessionService.GetActiveSessionAsync();

                if (_currentSession == null)
                {
                    // No hay caja abierta -> Mostrar pantalla de apertura
                    panelOpenSession.Visible = true;
                    panelActiveSession.Visible = false;
                    panelMovementsContainer.Visible = false;
                    numericUpDownInitialCash.Value = 0;
                    textBoxStationName.Text = "Recepción Principal";
                    numericUpDownInitialCash.Focus();
                }
                else
                {
                    // Caja abierta -> Mostrar balances y panel operativo
                    panelOpenSession.Visible = false;
                    panelActiveSession.Visible = true;
                    panelMovementsContainer.Visible = true;

                    labelSessionStatus.Text = $"SESIÓN ABIERTA #{_currentSession.Id} ({_currentSession.OpeningDate:dd/MM/yyyy HH:mm}) - OPERADOR: {_currentSession.UserName.ToUpper()}";
                    labelSessionStation.Text = $"PUESTO: {_currentSession.StationName.ToUpper()}";

                    labelInitialCashValue.Text = $"Fondo Inicial: {_currentSession.InitialCash:C2}";
                    labelCashIncomeValue.Text = $"Cobros Efectivo: {_currentSession.TotalCashIncome:C2}";

                    decimal digitalIncome = _currentSession.TotalDebitIncome + _currentSession.TotalCreditIncome +
                                            _currentSession.TotalTransferIncome + _currentSession.TotalQrIncome;

                    labelDigitalIncomeValue.Text = $"Digital / QR / Tarjetas: {digitalIncome:C2}";
                    labelTotalTurnoverValue.Text = $"Total Recaudado: {_currentSession.TotalTurnover:C2}";
                    labelExpectedCashValue.Text = $"EFECTIVO EN GAVETA: {_currentSession.CurrentSystemCash:C2}";

                    // Cargar tabla de movimientos
                    var movements = await _cashSessionService.GetCurrentSessionMovementsAsync();
                    dataGridViewMovements.DataSource = null;
                    dataGridViewMovements.DataSource = movements.ToList();
                    UIHelper.FormatGrid(dataGridViewMovements);
                }
            }
        }

        private async Task ExecuteOpenSessionAsync()
        {
            if (numericUpDownInitialCash.Value < 0)
            {
                UIHelper.WarnMessage(this, "El fondo inicial no puede ser negativo.", "Monto Inválido");
                return;
            }

            var dto = new CashSessionOpenDto
            {
                InitialCash = numericUpDownInitialCash.Value,
                StationName = textBoxStationName.Text.Trim()
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _cashSessionService.OpenSessionAsync(dto);
                UIHelper.ShowResult(result, "Apertura de Caja", async () =>
                {
                    await RefreshSessionStatusAsync();
                });
            }
        }

        private async Task ExecuteChargeConsultationDialogAsync()
        {
            if (_currentSession == null)
                return;

            // Modal para seleccionar el turno del día y cobrar la consulta/copago
            using var chargeDialog = new FormChargeConsultationDialog(_appointmentService);
            if (chargeDialog.ShowDialog(this) == DialogResult.OK)
            {
                var dto = new ConsultationPaymentCreateDto
                {
                    AppointmentId = chargeDialog.SelectedAppointmentId,
                    PaymentMethodId = chargeDialog.SelectedPaymentMethodId,
                    Amount = chargeDialog.Amount,
                    CopayAmount = chargeDialog.CopayAmount,
                    PaymentReceived = chargeDialog.PaymentReceived,
                    Observations = chargeDialog.Observations
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashSessionService.ProcessPaymentAsync(dto);
                    if (result.Success)
                    {
                        // Preguntar si desea imprimir el comprobante térmico para el paciente
                        if (UIHelper.ConfirmMessage("¿Desea imprimir el recibo de atención para el paciente?", "Recibo Emitido"))
                        {
                            try
                            {
                                var app = await _appointmentService.GetByIdAsync(dto.AppointmentId);
                                var receiptDto = new ConsultationReceiptDto
                                {
                                    ClinicName = "Consultorio Médico Cliniqax",
                                    ReceiptNumber = $"REC-{DateTime.Now:yyyyMMddHHmmss}",
                                    Date = DateTime.Now,
                                    CashierName = _currentUserService.FullName ?? "Recepción",
                                    PatientName = app?.PatientName ?? "Paciente",
                                    PatientDocument = app?.PatientDocument ?? "-",
                                    HealthInsuranceName = app?.HealthInsuranceName,
                                    AffiliateNumber = app?.AffiliateNumber,
                                    ProfessionalName = app?.ProfessionalName ?? "-",
                                    SpecialtyName = app?.SpecialtyName ?? "-",
                                    PaymentMethodName = chargeDialog.SelectedPaymentMethodName,
                                    Amount = dto.Amount,
                                    CopayAmount = dto.CopayAmount,
                                    PaymentReceived = dto.PaymentReceived,
                                    PaymentChange = Math.Max(0, dto.PaymentReceived - dto.Amount)
                                };

                                byte[] pdfBytes = await _documentService.GenerateConsultationReceiptPdfAsync(receiptDto);
                                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, $"Recibo_{receiptDto.ReceiptNumber}.pdf", "Recibo de Consulta");
                            }
                            catch { }
                        }

                        await RefreshSessionStatusAsync();
                    }
                    else
                    {
                        UIHelper.ShowResult(result, "Error de Cobro");
                    }
                }
            }
        }

        private async Task ExecuteManualMovementAsync(CashMovementType type)
        {
            if (_currentSession == null) return;

            string title = type == CashMovementType.CashIn ? "Ingreso Manual de Efectivo" : "Retiro / Egreso de Efectivo";
            string promptMsg = type == CashMovementType.CashIn ? "Motivo del ingreso a caja:" : "Motivo del gasto / retiro:";

            using var prompt = new FormBlindCashCountDialog.FormPromptDialog(title, promptMsg, showAmount: true);
            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                var dto = new CashMovementCreateDto
                {
                    MovementType = type,
                    Amount = prompt.EnteredAmount,
                    Description = prompt.EnteredDescription
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashSessionService.RegisterMovementAsync(dto);
                    UIHelper.ShowResult(result, title, async () =>
                    {
                        await RefreshSessionStatusAsync();
                    });
                }
            }
        }

        private async Task ExecutePrintSessionTicketAsync(bool isZClose)
        {
            if (_currentSession == null) return;

            using (new WaitCursorHelper(this))
            {
                var summary = await _cashSessionService.GetCurrentSessionSummaryAsync();
                byte[] ticketPdf = await _documentService.GenerateCashSessionTicketPdfAsync(summary, isZClose);

                string fileName = isZClose ? $"Cierre_Z_Sesion_{summary.Id}.pdf" : $"Arqueo_X_Sesion_{summary.Id}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, ticketPdf, fileName, "Ticket de Caja");
            }
        }

        private async Task ExecuteCloseSessionAndBlindCountAsync()
        {
            if (_currentSession == null) return;

            var summary = await _cashSessionService.GetCurrentSessionSummaryAsync();

            // Diálogo de arqueo ciego: el operador cuenta el dinero físico sin ver el sistema
            using var blindDialog = new FormBlindCashCountDialog(summary.CurrentSystemCash);
            if (blindDialog.ShowDialog(this) == DialogResult.OK)
            {
                var closeDto = new CashSessionCloseDto
                {
                    SessionId = _currentSession.Id,
                    RealCash = blindDialog.CountedCash,
                    ClosingNotes = blindDialog.Notes
                };

                using (new WaitCursorHelper(this))
                {
                    var result = await _cashSessionService.CloseSessionAsync(closeDto);
                    if (result.Success)
                    {
                        summary.RealCash = blindDialog.CountedCash;
                        summary.ClosingDate = DateTime.UtcNow;

                        try
                        {
                            byte[] ticketPdf = await _documentService.GenerateCashSessionTicketPdfAsync(summary, isZClose: true);
                            await FileExportHelper.SaveAndOpenPdfAsync(this, ticketPdf, $"Cierre_Z_{summary.Id}.pdf", "Ticket Cierre Z");
                        }
                        catch { }

                        UIHelper.ShowResult(result, "Cierre de Caja Finalizado", async () =>
                        {
                            await RefreshSessionStatusAsync();
                        });
                    }
                    else
                    {
                        UIHelper.ShowResult(result, "Error en Cierre de Caja");
                    }
                }
            }
        }
    }
}
