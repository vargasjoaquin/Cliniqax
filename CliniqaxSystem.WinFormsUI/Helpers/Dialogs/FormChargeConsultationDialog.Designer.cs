namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormChargeConsultationDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            panelCard = new Panel();
            labelAppointmentPrompt = new Label();
            comboBoxAppointments = new ComboBox();
            labelMethodPrompt = new Label();
            comboBoxPaymentMethods = new ComboBox();
            labelCopayPrompt = new Label();
            numericUpDownCopay = new NumericUpDown();
            labelAmountPrompt = new Label();
            numericUpDownAmount = new NumericUpDown();
            labelReceivedPrompt = new Label();
            numericUpDownReceived = new NumericUpDown();
            labelChangePrompt = new Label();
            labelChangeValue = new Label();
            labelObservationsPrompt = new Label();
            textBoxObservations = new TextBox();
            picIconConfirm = new PictureBox();
            buttonConfirm = new Button();
            picIconCancel = new PictureBox();
            buttonCancel = new Button();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCopay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReceived).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(560, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(404, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "COBRO DE ATENCIÓN MÉDICA / COPAGO";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelAppointmentPrompt);
            panelCard.Controls.Add(comboBoxAppointments);
            panelCard.Controls.Add(labelMethodPrompt);
            panelCard.Controls.Add(comboBoxPaymentMethods);
            panelCard.Controls.Add(labelCopayPrompt);
            panelCard.Controls.Add(numericUpDownCopay);
            panelCard.Controls.Add(labelAmountPrompt);
            panelCard.Controls.Add(numericUpDownAmount);
            panelCard.Controls.Add(labelReceivedPrompt);
            panelCard.Controls.Add(numericUpDownReceived);
            panelCard.Controls.Add(labelChangePrompt);
            panelCard.Controls.Add(labelChangeValue);
            panelCard.Controls.Add(labelObservationsPrompt);
            panelCard.Controls.Add(textBoxObservations);
            panelCard.Controls.Add(picIconConfirm);
            panelCard.Controls.Add(buttonConfirm);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 62);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(528, 415);
            panelCard.TabIndex = 1;
            // 
            // labelAppointmentPrompt
            // 
            labelAppointmentPrompt.AutoSize = true;
            labelAppointmentPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAppointmentPrompt.Location = new Point(16, 12);
            labelAppointmentPrompt.Name = "labelAppointmentPrompt";
            labelAppointmentPrompt.Size = new Size(186, 20);
            labelAppointmentPrompt.TabIndex = 0;
            labelAppointmentPrompt.Text = "Turno del Paciente (Hoy):";
            // 
            // comboBoxAppointments
            // 
            comboBoxAppointments.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAppointments.Font = new Font("Segoe UI", 9.5F);
            comboBoxAppointments.Location = new Point(16, 35);
            comboBoxAppointments.Name = "comboBoxAppointments";
            comboBoxAppointments.Size = new Size(496, 29);
            comboBoxAppointments.TabIndex = 1;
            // 
            // labelMethodPrompt
            // 
            labelMethodPrompt.AutoSize = true;
            labelMethodPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelMethodPrompt.Location = new Point(16, 75);
            labelMethodPrompt.Name = "labelMethodPrompt";
            labelMethodPrompt.Size = new Size(117, 20);
            labelMethodPrompt.TabIndex = 2;
            labelMethodPrompt.Text = "Medio de Pago:";
            // 
            // comboBoxPaymentMethods
            // 
            comboBoxPaymentMethods.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethods.Font = new Font("Segoe UI", 9.5F);
            comboBoxPaymentMethods.Location = new Point(16, 98);
            comboBoxPaymentMethods.Name = "comboBoxPaymentMethods";
            comboBoxPaymentMethods.Size = new Size(235, 29);
            comboBoxPaymentMethods.TabIndex = 3;
            // 
            // labelCopayPrompt
            // 
            labelCopayPrompt.AutoSize = true;
            labelCopayPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelCopayPrompt.Location = new Point(275, 75);
            labelCopayPrompt.Name = "labelCopayPrompt";
            labelCopayPrompt.Size = new Size(172, 20);
            labelCopayPrompt.TabIndex = 4;
            labelCopayPrompt.Text = "Copago / Coseguro ($):";
            // 
            // numericUpDownCopay
            // 
            numericUpDownCopay.DecimalPlaces = 2;
            numericUpDownCopay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numericUpDownCopay.Location = new Point(275, 98);
            numericUpDownCopay.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownCopay.Name = "numericUpDownCopay";
            numericUpDownCopay.Size = new Size(237, 30);
            numericUpDownCopay.TabIndex = 5;
            // 
            // labelAmountPrompt
            // 
            labelAmountPrompt.AutoSize = true;
            labelAmountPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAmountPrompt.ForeColor = Color.FromArgb(2, 132, 199);
            labelAmountPrompt.Location = new Point(16, 142);
            labelAmountPrompt.Name = "labelAmountPrompt";
            labelAmountPrompt.Size = new Size(233, 21);
            labelAmountPrompt.TabIndex = 6;
            labelAmountPrompt.Text = "Total a Cobrar al Paciente ($):";
            // 
            // numericUpDownAmount
            // 
            numericUpDownAmount.DecimalPlaces = 2;
            numericUpDownAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            numericUpDownAmount.Location = new Point(16, 166);
            numericUpDownAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(235, 39);
            numericUpDownAmount.TabIndex = 7;
            // 
            // labelReceivedPrompt
            // 
            labelReceivedPrompt.AutoSize = true;
            labelReceivedPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelReceivedPrompt.Location = new Point(275, 142);
            labelReceivedPrompt.Name = "labelReceivedPrompt";
            labelReceivedPrompt.Size = new Size(149, 20);
            labelReceivedPrompt.TabIndex = 8;
            labelReceivedPrompt.Text = "Monto Recibido ($):";
            // 
            // numericUpDownReceived
            // 
            numericUpDownReceived.DecimalPlaces = 2;
            numericUpDownReceived.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            numericUpDownReceived.Location = new Point(275, 166);
            numericUpDownReceived.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownReceived.Name = "numericUpDownReceived";
            numericUpDownReceived.Size = new Size(237, 39);
            numericUpDownReceived.TabIndex = 9;
            // 
            // labelChangePrompt
            // 
            labelChangePrompt.AutoSize = true;
            labelChangePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelChangePrompt.Location = new Point(275, 214);
            labelChangePrompt.Name = "labelChangePrompt";
            labelChangePrompt.Size = new Size(59, 20);
            labelChangePrompt.TabIndex = 10;
            labelChangePrompt.Text = "Vuelto:";
            // 
            // labelChangeValue
            // 
            labelChangeValue.AutoSize = true;
            labelChangeValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelChangeValue.ForeColor = Color.FromArgb(16, 185, 129);
            labelChangeValue.Location = new Point(340, 210);
            labelChangeValue.Name = "labelChangeValue";
            labelChangeValue.Size = new Size(71, 28);
            labelChangeValue.TabIndex = 11;
            labelChangeValue.Text = "$ 0,00";
            // 
            // labelObservationsPrompt
            // 
            labelObservationsPrompt.AutoSize = true;
            labelObservationsPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelObservationsPrompt.Location = new Point(16, 248);
            labelObservationsPrompt.Name = "labelObservationsPrompt";
            labelObservationsPrompt.Size = new Size(179, 20);
            labelObservationsPrompt.TabIndex = 12;
            labelObservationsPrompt.Text = "Observaciones del Pago:";
            // 
            // textBoxObservations
            // 
            textBoxObservations.BorderStyle = BorderStyle.FixedSingle;
            textBoxObservations.Font = new Font("Segoe UI", 9.5F);
            textBoxObservations.Location = new Point(16, 271);
            textBoxObservations.MaxLength = 250;
            textBoxObservations.Multiline = true;
            textBoxObservations.Name = "textBoxObservations";
            textBoxObservations.Size = new Size(496, 60);
            textBoxObservations.TabIndex = 13;
            // 
            // picIconConfirm
            // 
            picIconConfirm.BackColor = Color.FromArgb(16, 185, 129);
            picIconConfirm.Cursor = Cursors.Hand;
            picIconConfirm.Image = Icons.clinical_cobrar_consulta;
            picIconConfirm.Location = new Point(286, 348);
            picIconConfirm.Name = "picIconConfirm";
            picIconConfirm.Size = new Size(57, 48);
            picIconConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirm.TabIndex = 99;
            picIconConfirm.TabStop = false;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.FromArgb(16, 185, 129);
            buttonConfirm.Cursor = Cursors.Hand;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.Location = new Point(286, 348);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Padding = new Padding(26, 0, 0, 0);
            buttonConfirm.Size = new Size(226, 48);
            buttonConfirm.TabIndex = 14;
            buttonConfirm.Text = "REGISTRAR PAGO";
            buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(126, 348);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(45, 48);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(126, 348);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(144, 48);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormChargeConsultationDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(560, 495);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChargeConsultationDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cobro de Atención Médica";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCopay).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReceived).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelCard;
        private Label labelAppointmentPrompt;
        private ComboBox comboBoxAppointments;
        private Label labelMethodPrompt;
        private ComboBox comboBoxPaymentMethods;
        private Label labelCopayPrompt;
        private NumericUpDown numericUpDownCopay;
        private Label labelAmountPrompt;
        private NumericUpDown numericUpDownAmount;
        private Label labelReceivedPrompt;
        private NumericUpDown numericUpDownReceived;
        private Label labelChangePrompt;
        private Label labelChangeValue;
        private Label labelObservationsPrompt;
        private TextBox textBoxObservations;
        private Button buttonConfirm;
        private Button buttonCancel;
        private PictureBox picIconConfirm;
        private PictureBox picIconCancel;
    }
}