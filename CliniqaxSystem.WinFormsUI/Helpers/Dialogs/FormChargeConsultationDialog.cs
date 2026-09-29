using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public class FormChargeConsultationDialog : Form
    {
        public int SelectedAppointmentId => (int)(comboBoxAppointments.SelectedValue ?? 0);
        public int SelectedPaymentMethodId => (int)(comboBoxPaymentMethods.SelectedValue ?? 1);
        public string SelectedPaymentMethodName => comboBoxPaymentMethods.Text;
        public decimal Amount => numericUpDownAmount.Value;
        public decimal CopayAmount => numericUpDownCopay.Value;
        public decimal PaymentReceived => numericUpDownReceived.Value;
        public string? Observations => textBoxObservations.Text.Trim();

        private readonly IAppointmentService _appointmentService;

        private ComboBox comboBoxAppointments = null!;
        private ComboBox comboBoxPaymentMethods = null!;
        private NumericUpDown numericUpDownAmount = null!;
        private NumericUpDown numericUpDownCopay = null!;
        private NumericUpDown numericUpDownReceived = null!;
        private Label labelChangeValue = null!;
        private TextBox textBoxObservations = null!;
        private Button buttonConfirm = null!;
        private Button buttonCancel = null!;

        public FormChargeConsultationDialog(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;

            InitializeCustomDialog();
            UIThemeHelper.ApplyFormStyle(this);

            this.Load += async (s, e) => await LoadAppointmentsAsync();
            this.numericUpDownReceived.ValueChanged += (s, e) => CalculateChange();
            this.numericUpDownAmount.ValueChanged += (s, e) => CalculateChange();
            this.buttonConfirm.Click += (s, e) => ValidateAndConfirm();
            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private async Task LoadAppointmentsAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var today = DateTime.Today;
                // Listar turnos de hoy que estén en espera, confirmados o atendidos
                var appointments = (await _appointmentService.GetAppointmentsByRangeAsync(today, today))
                    .Where(a => a.Status != AppointmentStatus.Cancelled)
                    .Select(a => new
                    {
                        Id = a.Id,
                        Display = $"{a.TimeSlot} | {a.PatientName} ({a.HealthInsuranceName}) - Dr/a. {a.ProfessionalName}"
                    })
                    .ToList();

                comboBoxAppointments.DataSource = appointments;
                comboBoxAppointments.DisplayMember = "Display";
                comboBoxAppointments.ValueMember = "Id";

                // Medios de pago fijos
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
                MessageBox.Show("Debe seleccionar un turno para cobrar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownAmount.Value <= 0)
            {
                MessageBox.Show("El monto a cobrar debe ser mayor a $ 0.00.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownReceived.Value < numericUpDownAmount.Value && SelectedPaymentMethodId == PaymentMethodConstants.CASH_ID)
            {
                MessageBox.Show("El dinero recibido no puede ser inferior al total a cobrar en efectivo.", "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void InitializeCustomDialog()
        {
            this.Text = "Cobro de Atención Médica / Consulta";
            this.Size = new Size(540, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(248, 250, 252);

            var lblApp = new Label { Text = "Turno del Paciente (Hoy):", Location = new Point(20, 15), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            comboBoxAppointments = new ComboBox { Location = new Point(20, 38), Size = new Size(480, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };

            var lblMethod = new Label { Text = "Medio de Pago:", Location = new Point(20, 75), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            comboBoxPaymentMethods = new ComboBox { Location = new Point(20, 98), Size = new Size(230, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };

            var lblCopay = new Label { Text = "Copago / Coseguro ($):", Location = new Point(270, 75), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            numericUpDownCopay = new NumericUpDown { Location = new Point(270, 98), Size = new Size(230, 28), Font = new Font("Segoe UI", 10F, FontStyle.Bold), Maximum = 10000000, DecimalPlaces = 2 };

            var lblAmount = new Label { Text = "Total a Cobrar al Paciente ($):", Location = new Point(20, 140), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(2, 132, 199) };
            numericUpDownAmount = new NumericUpDown { Location = new Point(20, 165), Size = new Size(230, 34), Font = new Font("Segoe UI", 14F, FontStyle.Bold), Maximum = 10000000, DecimalPlaces = 2 };

            var lblReceived = new Label { Text = "Monto Recibido ($):", Location = new Point(270, 140), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            numericUpDownReceived = new NumericUpDown { Location = new Point(270, 165), Size = new Size(230, 34), Font = new Font("Segoe UI", 14F, FontStyle.Bold), Maximum = 10000000, DecimalPlaces = 2 };

            var lblChange = new Label { Text = "Vuelto:", Location = new Point(270, 210), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            labelChangeValue = new Label { Text = "$ 0,00", Location = new Point(330, 208), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(16, 185, 129) };

            var lblObs = new Label { Text = "Observaciones del Pago:", Location = new Point(20, 245), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            textBoxObservations = new TextBox { Location = new Point(20, 270), Size = new Size(480, 28), Font = new Font("Segoe UI", 10F) };

            buttonCancel = new Button { Text = "CANCELAR", Location = new Point(240, 375), Size = new Size(125, 42), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            buttonConfirm = new Button { Text = "REGISTRAR PAGO", Location = new Point(375, 375), Size = new Size(125, 42), BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            this.Controls.AddRange(new Control[] {
            lblApp, comboBoxAppointments, lblMethod, comboBoxPaymentMethods, lblCopay, numericUpDownCopay,
            lblAmount, numericUpDownAmount, lblReceived, numericUpDownReceived, lblChange, labelChangeValue,
            lblObs, textBoxObservations, buttonCancel, buttonConfirm
        });
        }
    }
}
