using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Enums;
using System.Data;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormChargeConsultationDialog : Form
    {
        public int SelectedAppointmentId => (int)(comboBoxAppointments.SelectedValue ?? 0);
        public int SelectedPaymentMethodId => (int)(comboBoxPaymentMethods.SelectedValue ?? PaymentMethodConstants.CASH_ID);
        public string SelectedPaymentMethodName => comboBoxPaymentMethods.Text;
        public decimal Amount => numericUpDownAmount.Value;
        public decimal CopayAmount => numericUpDownCopay.Value;
        public decimal PaymentReceived => numericUpDownReceived.Value;
        public string? Observations => textBoxObservations.Text.Trim();

        private readonly IAppointmentService _appointmentService;

        public FormChargeConsultationDialog(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirm, this.picIconConfirm);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Eventos
            this.Load += async (s, e) => await LoadAppointmentsAndPaymentMethodsAsync();
            this.numericUpDownReceived.ValueChanged += (s, e) => CalculateChange();
            this.numericUpDownAmount.ValueChanged += (s, e) => CalculateChange();
            this.buttonConfirm.Click += (s, e) => ValidateAndConfirm();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task LoadAppointmentsAndPaymentMethodsAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var today = DateTime.Today;

                // Cargar turnos del día no cancelados
                var appointments = (await _appointmentService.GetAppointmentsByRangeAsync(today, today))
                    .Where(a => a.Status != AppointmentStatus.Cancelled)
                    .Select(a => new
                    {
                        Id = a.Id,
                        Display = $"{a.TimeSlot} | {a.PatientName} ({a.HealthInsuranceName ?? "Particular"}) - Dr/a. {a.ProfessionalName}"
                    })
                    .ToList();

                comboBoxAppointments.DataSource = appointments;
                comboBoxAppointments.DisplayMember = "Display";
                comboBoxAppointments.ValueMember = "Id";

                // Medios de pago
                var methods = new[]
                {
                    new { Id = PaymentMethodConstants.CASH_ID, Name = PaymentMethodConstants.CASH },
                    new { Id = PaymentMethodConstants.DEBIT_CARD_ID, Name = PaymentMethodConstants.DEBIT_CARD },
                    new { Id = PaymentMethodConstants.CREDIT_CARD_ID, Name = PaymentMethodConstants.CREDIT_CARD },
                    new { Id = PaymentMethodConstants.BANK_TRANSFER_ID, Name = PaymentMethodConstants.BANK_TRANSFER },
                    new { Id = PaymentMethodConstants.MERCADO_PAGO_QR_ID, Name = PaymentMethodConstants.MERCADO_PAGO_QR }
                };

                comboBoxPaymentMethods.DataSource = methods;
                comboBoxPaymentMethods.DisplayMember = "Name";
                comboBoxPaymentMethods.ValueMember = "Id";
                comboBoxPaymentMethods.SelectedValue = PaymentMethodConstants.CASH_ID;
            }
        }

        private void CalculateChange()
        {
            decimal change = numericUpDownReceived.Value - numericUpDownAmount.Value;
            labelChangeValue.Text = (change >= 0 ? change : 0).ToString("C2");
            labelChangeValue.ForeColor = change >= 0 ? UIThemeHelper.Success : UIThemeHelper.Danger;
        }

        private void ValidateAndConfirm()
        {
            if (SelectedAppointmentId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un turno para cobrar.", "Selección Requerida");
                comboBoxAppointments.Focus();
                return;
            }

            if (numericUpDownAmount.Value <= 0)
            {
                UIHelper.WarnMessage(this, "El monto total a cobrar debe ser mayor a $ 0,00.", "Importe Inválido");
                numericUpDownAmount.Focus();
                return;
            }

            if (SelectedPaymentMethodId == PaymentMethodConstants.CASH_ID && numericUpDownReceived.Value < numericUpDownAmount.Value)
            {
                UIHelper.WarnMessage(this, "El dinero recibido no puede ser inferior al total a cobrar en efectivo.", "Pago Insuficiente");
                numericUpDownReceived.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
