namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormBlindCashCountDialog : Form
    {
        /// <summary>
        /// Efectivo físico total contado en la gaveta por el operador.
        /// </summary>
        public decimal CountedCash => numericUpDownRealCash.Value;

        /// <summary>
        /// Observaciones o notas de cierre registradas en el arqueo.
        /// </summary>
        public string Notes => textBoxNotes.Text.Trim();

        public FormBlindCashCountDialog() : this(0) { }

        public FormBlindCashCountDialog(decimal expectedSystemCash)
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirmClose, this.picIconConfirmClose);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.buttonConfirmClose.Click += (s, e) => this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Diálogo modal versátil para solicitar motivos (como cancelación de turnos)
        /// o importes + descripción (movimientos de caja).
        /// </summary>
        public class FormPromptDialog : Form
        {
            public decimal EnteredAmount => numericUpDownAmount.Value;
            public string EnteredDescription => textBoxDescription.Text.Trim();

            private NumericUpDown numericUpDownAmount = null!;
            private TextBox textBoxDescription = null!;
            private Button buttonConfirm = null!;
            private Button buttonCancel = null!;

            public FormPromptDialog(string dialogTitle, string descriptionPrompt, bool showAmount = false)
            {
                this.Text = dialogTitle;
                this.Size = new Size(420, showAmount ? 290 : 210);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = Color.FromArgb(248, 250, 252);

                int currentY = 20;

                if (showAmount)
                {
                    var labelAmount = new Label
                    {
                        Text = "Monto ($):",
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                        Location = new Point(20, currentY),
                        AutoSize = true
                    };

                    numericUpDownAmount = new NumericUpDown
                    {
                        Location = new Point(20, currentY + 25),
                        Size = new Size(360, 32),
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        Maximum = 100000000,
                        DecimalPlaces = 2
                    };

                    this.Controls.Add(labelAmount);
                    this.Controls.Add(numericUpDownAmount);
                    currentY += 70;
                }
                else
                {
                    numericUpDownAmount = new NumericUpDown();
                }

                var labelDesc = new Label
                {
                    Text = descriptionPrompt,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(20, currentY),
                    AutoSize = true
                };

                textBoxDescription = new TextBox
                {
                    Location = new Point(20, currentY + 25),
                    Size = new Size(360, 27),
                    Font = new Font("Segoe UI", 10F)
                };

                currentY += 65;

                buttonCancel = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(140, currentY),
                    Size = new Size(110, 38),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                buttonConfirm = new Button
                {
                    Text = "Confirmar",
                    Location = new Point(260, currentY),
                    Size = new Size(120, 38),
                    BackColor = Color.FromArgb(2, 132, 199),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
                buttonConfirm.Click += (s, e) =>
                {
                    if (showAmount && numericUpDownAmount.Value <= 0)
                    {
                        MessageBox.Show("Debe ingresar un monto válido mayor a $0.00.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
                    {
                        MessageBox.Show("Debe ingresar un motivo o descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                };

                this.Controls.AddRange(new Control[] { labelDesc, textBoxDescription, buttonCancel, buttonConfirm });
            }
        }
    }
}
