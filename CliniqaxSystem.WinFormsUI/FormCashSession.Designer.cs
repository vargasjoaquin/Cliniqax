namespace CliniqaxSystem.WinFormsUI
{
    partial class FormCashSession
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
            picIconOpenSession = new PictureBox();
            picIconChargeConsultation = new PictureBox();
            picIconRegisterCashIn = new PictureBox();
            picIconRegisterCashOut = new PictureBox();
            picIconPrintPartialCloseX = new PictureBox();
            picIconCloseSessionZ = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelOpenSession = new Panel();
            labelOpenTitle = new Label();
            labelInitialCashPrompt = new Label();
            numericUpDownInitialCash = new NumericUpDown();
            labelStationPrompt = new Label();
            textBoxStationName = new TextBox();
            buttonOpenSession = new Button();
            panelActiveSession = new Panel();
            labelSessionStatus = new Label();
            labelSessionStation = new Label();
            labelInitialCashValue = new Label();
            labelCashIncomeValue = new Label();
            labelDigitalIncomeValue = new Label();
            labelTotalTurnoverValue = new Label();
            labelExpectedCashValue = new Label();
            buttonChargeConsultation = new Button();
            buttonRegisterCashIn = new Button();
            buttonRegisterCashOut = new Button();
            buttonPrintPartialCloseX = new Button();
            buttonCloseSessionZ = new Button();
            panelMovementsContainer = new Panel();
            dataGridViewMovements = new DataGridView();
            labelMovementsTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)picIconOpenSession).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconChargeConsultation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintPartialCloseX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCloseSessionZ).BeginInit();
            panelHeader.SuspendLayout();
            panelOpenSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInitialCash).BeginInit();
            panelActiveSession.SuspendLayout();
            panelMovementsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovements).BeginInit();
            SuspendLayout();
            // 
            // picIconOpenSession
            // 
            picIconOpenSession.BackColor = Color.FromArgb(16, 185, 129);
            picIconOpenSession.Cursor = Cursors.Hand;
            picIconOpenSession.Image = Icons.action_guardar;
            picIconOpenSession.Location = new Point(565, 82);
            picIconOpenSession.Name = "picIconOpenSession";
            picIconOpenSession.Size = new Size(24, 24);
            picIconOpenSession.SizeMode = PictureBoxSizeMode.Zoom;
            picIconOpenSession.TabIndex = 99;
            picIconOpenSession.TabStop = false;
            // 
            // picIconChargeConsultation
            // 
            picIconChargeConsultation.BackColor = Color.FromArgb(16, 185, 129);
            picIconChargeConsultation.Cursor = Cursors.Hand;
            picIconChargeConsultation.Image = Icons.clinical_cobrar_consulta;
            picIconChargeConsultation.Location = new Point(714, 12);
            picIconChargeConsultation.Name = "picIconChargeConsultation";
            picIconChargeConsultation.Size = new Size(49, 44);
            picIconChargeConsultation.SizeMode = PictureBoxSizeMode.Zoom;
            picIconChargeConsultation.TabIndex = 99;
            picIconChargeConsultation.TabStop = false;
            // 
            // picIconRegisterCashIn
            // 
            picIconRegisterCashIn.BackColor = Color.FromArgb(2, 132, 199);
            picIconRegisterCashIn.Cursor = Cursors.Hand;
            picIconRegisterCashIn.Image = Icons.caja_ingreso_manual;
            picIconRegisterCashIn.Location = new Point(714, 67);
            picIconRegisterCashIn.Name = "picIconRegisterCashIn";
            picIconRegisterCashIn.Size = new Size(41, 44);
            picIconRegisterCashIn.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRegisterCashIn.TabIndex = 99;
            picIconRegisterCashIn.TabStop = false;
            // 
            // picIconRegisterCashOut
            // 
            picIconRegisterCashOut.BackColor = Color.White;
            picIconRegisterCashOut.Cursor = Cursors.Hand;
            picIconRegisterCashOut.Image = Icons.caja_retiro_egreso;
            picIconRegisterCashOut.Location = new Point(739, 123);
            picIconRegisterCashOut.Name = "picIconRegisterCashOut";
            picIconRegisterCashOut.Size = new Size(41, 44);
            picIconRegisterCashOut.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRegisterCashOut.TabIndex = 99;
            picIconRegisterCashOut.TabStop = false;
            // 
            // picIconPrintPartialCloseX
            // 
            picIconPrintPartialCloseX.BackColor = Color.White;
            picIconPrintPartialCloseX.Cursor = Cursors.Hand;
            picIconPrintPartialCloseX.Image = Icons.action_imprimir_recibo;
            picIconPrintPartialCloseX.Location = new Point(739, 177);
            picIconPrintPartialCloseX.Name = "picIconPrintPartialCloseX";
            picIconPrintPartialCloseX.Size = new Size(41, 44);
            picIconPrintPartialCloseX.SizeMode = PictureBoxSizeMode.Zoom;
            picIconPrintPartialCloseX.TabIndex = 99;
            picIconPrintPartialCloseX.TabStop = false;
            // 
            // picIconCloseSessionZ
            // 
            picIconCloseSessionZ.BackColor = Color.FromArgb(239, 68, 68);
            picIconCloseSessionZ.Cursor = Cursors.Hand;
            picIconCloseSessionZ.Image = Icons.caja_arqueo_cierre_z;
            picIconCloseSessionZ.Location = new Point(1139, 33);
            picIconCloseSessionZ.Name = "picIconCloseSessionZ";
            picIconCloseSessionZ.Size = new Size(61, 69);
            picIconCloseSessionZ.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCloseSessionZ.TabIndex = 99;
            picIconCloseSessionZ.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1361, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(409, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CONTROL Y GESTIÓN DE CAJA DIARIA";
            // 
            // panelOpenSession
            // 
            panelOpenSession.BackColor = Color.White;
            panelOpenSession.Controls.Add(labelOpenTitle);
            panelOpenSession.Controls.Add(labelInitialCashPrompt);
            panelOpenSession.Controls.Add(numericUpDownInitialCash);
            panelOpenSession.Controls.Add(labelStationPrompt);
            panelOpenSession.Controls.Add(textBoxStationName);
            panelOpenSession.Controls.Add(picIconOpenSession);
            panelOpenSession.Controls.Add(buttonOpenSession);
            panelOpenSession.Location = new Point(16, 70);
            panelOpenSession.Name = "panelOpenSession";
            panelOpenSession.Padding = new Padding(20);
            panelOpenSession.Size = new Size(850, 160);
            panelOpenSession.TabIndex = 1;
            panelOpenSession.Visible = false;
            // 
            // labelOpenTitle
            // 
            labelOpenTitle.AutoSize = true;
            labelOpenTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelOpenTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelOpenTitle.Location = new Point(20, 15);
            labelOpenTitle.Name = "labelOpenTitle";
            labelOpenTitle.Size = new Size(359, 25);
            labelOpenTitle.TabIndex = 0;
            labelOpenTitle.Text = "APERTURA DE NUEVA SESIÓN DE CAJA";
            // 
            // labelInitialCashPrompt
            // 
            labelInitialCashPrompt.AutoSize = true;
            labelInitialCashPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelInitialCashPrompt.Location = new Point(20, 55);
            labelInitialCashPrompt.Name = "labelInitialCashPrompt";
            labelInitialCashPrompt.Size = new Size(251, 20);
            labelInitialCashPrompt.TabIndex = 1;
            labelInitialCashPrompt.Text = "Fondo Inicial en Efectivo / Cambio:";
            // 
            // numericUpDownInitialCash
            // 
            numericUpDownInitialCash.DecimalPlaces = 2;
            numericUpDownInitialCash.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numericUpDownInitialCash.Location = new Point(20, 78);
            numericUpDownInitialCash.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownInitialCash.Name = "numericUpDownInitialCash";
            numericUpDownInitialCash.Size = new Size(245, 34);
            numericUpDownInitialCash.TabIndex = 2;
            // 
            // labelStationPrompt
            // 
            labelStationPrompt.AutoSize = true;
            labelStationPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStationPrompt.Location = new Point(290, 55);
            labelStationPrompt.Name = "labelStationPrompt";
            labelStationPrompt.Size = new Size(157, 20);
            labelStationPrompt.TabIndex = 3;
            labelStationPrompt.Text = "Puesto de Recepción:";
            // 
            // textBoxStationName
            // 
            textBoxStationName.BorderStyle = BorderStyle.FixedSingle;
            textBoxStationName.Font = new Font("Segoe UI", 11F);
            textBoxStationName.Location = new Point(290, 79);
            textBoxStationName.Name = "textBoxStationName";
            textBoxStationName.Size = new Size(220, 32);
            textBoxStationName.TabIndex = 4;
            textBoxStationName.Text = "Recepción Principal";
            // 
            // buttonOpenSession
            // 
            buttonOpenSession.BackColor = Color.FromArgb(16, 185, 129);
            buttonOpenSession.Cursor = Cursors.Hand;
            buttonOpenSession.FlatAppearance.BorderSize = 0;
            buttonOpenSession.FlatStyle = FlatStyle.Flat;
            buttonOpenSession.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonOpenSession.ForeColor = Color.White;
            buttonOpenSession.Location = new Point(540, 73);
            buttonOpenSession.Name = "buttonOpenSession";
            buttonOpenSession.Padding = new Padding(28, 0, 0, 0);
            buttonOpenSession.Size = new Size(260, 44);
            buttonOpenSession.TabIndex = 5;
            buttonOpenSession.Text = "ABRIR CAJA";
            buttonOpenSession.UseVisualStyleBackColor = false;
            // 
            // panelActiveSession
            // 
            panelActiveSession.BackColor = Color.White;
            panelActiveSession.Controls.Add(labelSessionStatus);
            panelActiveSession.Controls.Add(labelSessionStation);
            panelActiveSession.Controls.Add(labelInitialCashValue);
            panelActiveSession.Controls.Add(labelCashIncomeValue);
            panelActiveSession.Controls.Add(labelDigitalIncomeValue);
            panelActiveSession.Controls.Add(labelTotalTurnoverValue);
            panelActiveSession.Controls.Add(labelExpectedCashValue);
            panelActiveSession.Controls.Add(picIconChargeConsultation);
            panelActiveSession.Controls.Add(buttonChargeConsultation);
            panelActiveSession.Controls.Add(picIconRegisterCashIn);
            panelActiveSession.Controls.Add(buttonRegisterCashIn);
            panelActiveSession.Controls.Add(picIconRegisterCashOut);
            panelActiveSession.Controls.Add(buttonRegisterCashOut);
            panelActiveSession.Controls.Add(picIconPrintPartialCloseX);
            panelActiveSession.Controls.Add(buttonPrintPartialCloseX);
            panelActiveSession.Controls.Add(picIconCloseSessionZ);
            panelActiveSession.Controls.Add(buttonCloseSessionZ);
            panelActiveSession.Location = new Point(16, 70);
            panelActiveSession.Name = "panelActiveSession";
            panelActiveSession.Padding = new Padding(16);
            panelActiveSession.Size = new Size(1329, 240);
            panelActiveSession.TabIndex = 2;
            // 
            // labelSessionStatus
            // 
            labelSessionStatus.AutoSize = true;
            labelSessionStatus.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelSessionStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelSessionStatus.Location = new Point(16, 12);
            labelSessionStatus.Name = "labelSessionStatus";
            labelSessionStatus.Size = new Size(257, 28);
            labelSessionStatus.TabIndex = 0;
            labelSessionStatus.Text = "SESIÓN DE CAJA ABIERTA";
            // 
            // labelSessionStation
            // 
            labelSessionStation.AutoSize = true;
            labelSessionStation.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSessionStation.ForeColor = Color.FromArgb(100, 116, 139);
            labelSessionStation.Location = new Point(16, 40);
            labelSessionStation.Name = "labelSessionStation";
            labelSessionStation.Size = new Size(234, 20);
            labelSessionStation.TabIndex = 1;
            labelSessionStation.Text = "PUESTO: RECEPCIÓN PRINCIPAL";
            // 
            // labelInitialCashValue
            // 
            labelInitialCashValue.AutoSize = true;
            labelInitialCashValue.Font = new Font("Segoe UI", 9.5F);
            labelInitialCashValue.Location = new Point(16, 70);
            labelInitialCashValue.Name = "labelInitialCashValue";
            labelInitialCashValue.Size = new Size(148, 21);
            labelInitialCashValue.TabIndex = 2;
            labelInitialCashValue.Text = "Fondo Inicial: $ 0,00";
            // 
            // labelCashIncomeValue
            // 
            labelCashIncomeValue.AutoSize = true;
            labelCashIncomeValue.Font = new Font("Segoe UI", 9.5F);
            labelCashIncomeValue.Location = new Point(16, 98);
            labelCashIncomeValue.Name = "labelCashIncomeValue";
            labelCashIncomeValue.Size = new Size(168, 21);
            labelCashIncomeValue.TabIndex = 3;
            labelCashIncomeValue.Text = "Cobros Efectivo: $ 0,00";
            // 
            // labelDigitalIncomeValue
            // 
            labelDigitalIncomeValue.AutoSize = true;
            labelDigitalIncomeValue.Font = new Font("Segoe UI", 9.5F);
            labelDigitalIncomeValue.Location = new Point(16, 126);
            labelDigitalIncomeValue.Name = "labelDigitalIncomeValue";
            labelDigitalIncomeValue.Size = new Size(207, 21);
            labelDigitalIncomeValue.TabIndex = 4;
            labelDigitalIncomeValue.Text = "Digital / QR / Tarjetas: $ 0,00";
            // 
            // labelTotalTurnoverValue
            // 
            labelTotalTurnoverValue.AutoSize = true;
            labelTotalTurnoverValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalTurnoverValue.Location = new Point(16, 154);
            labelTotalTurnoverValue.Name = "labelTotalTurnoverValue";
            labelTotalTurnoverValue.Size = new Size(189, 21);
            labelTotalTurnoverValue.TabIndex = 5;
            labelTotalTurnoverValue.Text = "Total Recaudado: $ 0,00";
            // 
            // labelExpectedCashValue
            // 
            labelExpectedCashValue.AutoSize = true;
            labelExpectedCashValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelExpectedCashValue.ForeColor = Color.FromArgb(2, 132, 199);
            labelExpectedCashValue.Location = new Point(16, 190);
            labelExpectedCashValue.Name = "labelExpectedCashValue";
            labelExpectedCashValue.Size = new Size(287, 28);
            labelExpectedCashValue.TabIndex = 6;
            labelExpectedCashValue.Text = "EFECTIVO EN GAVETA: $ 0,00";
            // 
            // buttonChargeConsultation
            // 
            buttonChargeConsultation.BackColor = Color.FromArgb(16, 185, 129);
            buttonChargeConsultation.Cursor = Cursors.Hand;
            buttonChargeConsultation.FlatAppearance.BorderSize = 0;
            buttonChargeConsultation.FlatStyle = FlatStyle.Flat;
            buttonChargeConsultation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonChargeConsultation.ForeColor = Color.White;
            buttonChargeConsultation.Location = new Point(714, 12);
            buttonChargeConsultation.Name = "buttonChargeConsultation";
            buttonChargeConsultation.Padding = new Padding(30, 0, 0, 0);
            buttonChargeConsultation.Size = new Size(290, 44);
            buttonChargeConsultation.TabIndex = 7;
            buttonChargeConsultation.Text = "COBRAR CONSULTA / COPAGO";
            buttonChargeConsultation.UseVisualStyleBackColor = false;
            // 
            // buttonRegisterCashIn
            // 
            buttonRegisterCashIn.BackColor = Color.FromArgb(2, 132, 199);
            buttonRegisterCashIn.Cursor = Cursors.Hand;
            buttonRegisterCashIn.FlatAppearance.BorderSize = 0;
            buttonRegisterCashIn.FlatStyle = FlatStyle.Flat;
            buttonRegisterCashIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRegisterCashIn.ForeColor = Color.White;
            buttonRegisterCashIn.Location = new Point(714, 67);
            buttonRegisterCashIn.Name = "buttonRegisterCashIn";
            buttonRegisterCashIn.Padding = new Padding(30, 0, 0, 0);
            buttonRegisterCashIn.Size = new Size(290, 44);
            buttonRegisterCashIn.TabIndex = 8;
            buttonRegisterCashIn.Text = "INGRESO MANUAL DE EFECTIVO";
            buttonRegisterCashIn.UseVisualStyleBackColor = false;
            // 
            // buttonRegisterCashOut
            // 
            buttonRegisterCashOut.BackColor = Color.White;
            buttonRegisterCashOut.Cursor = Cursors.Hand;
            buttonRegisterCashOut.FlatStyle = FlatStyle.Flat;
            buttonRegisterCashOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRegisterCashOut.ForeColor = Color.FromArgb(15, 23, 42);
            buttonRegisterCashOut.Location = new Point(714, 123);
            buttonRegisterCashOut.Name = "buttonRegisterCashOut";
            buttonRegisterCashOut.Padding = new Padding(30, 0, 0, 0);
            buttonRegisterCashOut.Size = new Size(290, 44);
            buttonRegisterCashOut.TabIndex = 9;
            buttonRegisterCashOut.Text = "RETIRO / GASTO DE CAJA";
            buttonRegisterCashOut.UseVisualStyleBackColor = true;
            // 
            // buttonPrintPartialCloseX
            // 
            buttonPrintPartialCloseX.BackColor = Color.White;
            buttonPrintPartialCloseX.Cursor = Cursors.Hand;
            buttonPrintPartialCloseX.FlatStyle = FlatStyle.Flat;
            buttonPrintPartialCloseX.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonPrintPartialCloseX.ForeColor = Color.FromArgb(100, 116, 139);
            buttonPrintPartialCloseX.Location = new Point(714, 177);
            buttonPrintPartialCloseX.Name = "buttonPrintPartialCloseX";
            buttonPrintPartialCloseX.Padding = new Padding(30, 0, 0, 0);
            buttonPrintPartialCloseX.Size = new Size(290, 44);
            buttonPrintPartialCloseX.TabIndex = 10;
            buttonPrintPartialCloseX.Text = "INFORME PARCIAL (X)";
            buttonPrintPartialCloseX.UseVisualStyleBackColor = true;
            // 
            // buttonCloseSessionZ
            // 
            buttonCloseSessionZ.BackColor = Color.FromArgb(239, 68, 68);
            buttonCloseSessionZ.Cursor = Cursors.Hand;
            buttonCloseSessionZ.FlatAppearance.BorderSize = 0;
            buttonCloseSessionZ.FlatStyle = FlatStyle.Flat;
            buttonCloseSessionZ.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCloseSessionZ.ForeColor = Color.White;
            buttonCloseSessionZ.Location = new Point(1031, 12);
            buttonCloseSessionZ.Name = "buttonCloseSessionZ";
            buttonCloseSessionZ.Padding = new Padding(0, 40, 0, 0);
            buttonCloseSessionZ.Size = new Size(274, 209);
            buttonCloseSessionZ.TabIndex = 11;
            buttonCloseSessionZ.Text = "CERRAR CAJA\r\nY ARQUEO (Z)";
            buttonCloseSessionZ.UseVisualStyleBackColor = false;
            // 
            // panelMovementsContainer
            // 
            panelMovementsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMovementsContainer.BackColor = Color.White;
            panelMovementsContainer.Controls.Add(dataGridViewMovements);
            panelMovementsContainer.Controls.Add(labelMovementsTitle);
            panelMovementsContainer.Location = new Point(16, 320);
            panelMovementsContainer.Name = "panelMovementsContainer";
            panelMovementsContainer.Padding = new Padding(16);
            panelMovementsContainer.Size = new Size(1329, 410);
            panelMovementsContainer.TabIndex = 3;
            // 
            // dataGridViewMovements
            // 
            dataGridViewMovements.BackgroundColor = Color.White;
            dataGridViewMovements.BorderStyle = BorderStyle.None;
            dataGridViewMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovements.Dock = DockStyle.Fill;
            dataGridViewMovements.Location = new Point(16, 46);
            dataGridViewMovements.Name = "dataGridViewMovements";
            dataGridViewMovements.RowHeadersWidth = 51;
            dataGridViewMovements.Size = new Size(1297, 348);
            dataGridViewMovements.TabIndex = 1;
            // 
            // labelMovementsTitle
            // 
            labelMovementsTitle.Dock = DockStyle.Top;
            labelMovementsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelMovementsTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelMovementsTitle.Location = new Point(16, 16);
            labelMovementsTitle.Name = "labelMovementsTitle";
            labelMovementsTitle.Size = new Size(1297, 30);
            labelMovementsTitle.TabIndex = 0;
            labelMovementsTitle.Text = "Movimientos Registrados en la Sesión:";
            // 
            // FormCashSession
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1361, 750);
            Controls.Add(panelMovementsContainer);
            Controls.Add(panelActiveSession);
            Controls.Add(panelOpenSession);
            Controls.Add(panelHeader);
            Name = "FormCashSession";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Caja Diaria - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconOpenSession).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconChargeConsultation).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconRegisterCashOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintPartialCloseX).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCloseSessionZ).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelOpenSession.ResumeLayout(false);
            panelOpenSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInitialCash).EndInit();
            panelActiveSession.ResumeLayout(false);
            panelActiveSession.PerformLayout();
            panelMovementsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelOpenSession;
        private Label labelOpenTitle;
        private Label labelInitialCashPrompt;
        private NumericUpDown numericUpDownInitialCash;
        private Label labelStationPrompt;
        private TextBox textBoxStationName;
        private Button buttonOpenSession;
        private Panel panelActiveSession;
        private Label labelSessionStatus;
        private Label labelSessionStation;
        private Label labelInitialCashValue;
        private Label labelCashIncomeValue;
        private Label labelDigitalIncomeValue;
        private Label labelTotalTurnoverValue;
        private Label labelExpectedCashValue;
        private Button buttonChargeConsultation;
        private Button buttonRegisterCashIn;
        private Button buttonRegisterCashOut;
        private Button buttonPrintPartialCloseX;
        private Button buttonCloseSessionZ;
        private Panel panelMovementsContainer;
        private DataGridView dataGridViewMovements;
        private Label labelMovementsTitle;
        private PictureBox picIconOpenSession;
        private PictureBox picIconChargeConsultation;
        private PictureBox picIconRegisterCashIn;
        private PictureBox picIconRegisterCashOut;
        private PictureBox picIconPrintPartialCloseX;
        private PictureBox picIconCloseSessionZ;
    }
}