namespace CliniqaxSystem.WinFormsUI
{
    partial class FormAppointments
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
            picIconFilter = new PictureBox();
            picIconExportPdf = new PictureBox();
            picIconExportExcel = new PictureBox();
            picIconConfirm = new PictureBox();
            picIconWaitingRoom = new PictureBox();
            picIconAttended = new PictureBox();
            picIconCancel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportPdf = new Button();
            buttonExportExcel = new Button();
            panelFiltersCard = new Panel();
            labelStartPrompt = new Label();
            dateTimePickerStart = new DateTimePicker();
            labelEndPrompt = new Label();
            dateTimePickerEnd = new DateTimePicker();
            labelProfPrompt = new Label();
            comboBoxProfessional = new ComboBox();
            labelSpecPrompt = new Label();
            comboBoxSpecialty = new ComboBox();
            labelStatusPrompt = new Label();
            comboBoxStatus = new ComboBox();
            buttonFilter = new Button();
            panelSearchAndCount = new Panel();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            labelTotalCount = new Label();
            panelActionsCard = new Panel();
            labelSelectedInfo = new Label();
            buttonConfirm = new Button();
            buttonWaitingRoom = new Button();
            buttonMarkAttended = new Button();
            buttonCancel = new Button();
            dataGridViewAppointments = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconWaitingRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconAttended).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            panelSearchAndCount.SuspendLayout();
            panelActionsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // picIconFilter
            // 
            picIconFilter.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilter.Cursor = Cursors.Hand;
            picIconFilter.Image = Icons.action_buscar_filtrar;
            picIconFilter.Location = new Point(1062, 13);
            picIconFilter.Name = "picIconFilter";
            picIconFilter.Size = new Size(45, 49);
            picIconFilter.SizeMode = PictureBoxSizeMode.Zoom;
            picIconFilter.TabIndex = 99;
            picIconFilter.TabStop = false;
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Icons.action_exportar_pdf;
            picIconExportPdf.Location = new Point(902, 12);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(45, 62);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconExportExcel
            // 
            picIconExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            picIconExportExcel.Cursor = Cursors.Hand;
            picIconExportExcel.Image = Icons.action_exportar_excel;
            picIconExportExcel.Location = new Point(1088, 12);
            picIconExportExcel.Name = "picIconExportExcel";
            picIconExportExcel.Size = new Size(39, 62);
            picIconExportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportExcel.TabIndex = 99;
            picIconExportExcel.TabStop = false;
            // 
            // picIconConfirm
            // 
            picIconConfirm.BackColor = Color.FromArgb(16, 185, 129);
            picIconConfirm.Cursor = Cursors.Hand;
            picIconConfirm.Image = Icons.status_confirmado;
            picIconConfirm.Location = new Point(589, 16);
            picIconConfirm.Name = "picIconConfirm";
            picIconConfirm.Size = new Size(38, 49);
            picIconConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirm.TabIndex = 99;
            picIconConfirm.TabStop = false;
            // 
            // picIconWaitingRoom
            // 
            picIconWaitingRoom.BackColor = Color.FromArgb(2, 132, 199);
            picIconWaitingRoom.Cursor = Cursors.Hand;
            picIconWaitingRoom.Image = Icons.status_en_sala_espera;
            picIconWaitingRoom.Location = new Point(752, 16);
            picIconWaitingRoom.Name = "picIconWaitingRoom";
            picIconWaitingRoom.Size = new Size(42, 49);
            picIconWaitingRoom.SizeMode = PictureBoxSizeMode.Zoom;
            picIconWaitingRoom.TabIndex = 99;
            picIconWaitingRoom.TabStop = false;
            // 
            // picIconAttended
            // 
            picIconAttended.BackColor = Color.FromArgb(15, 23, 42);
            picIconAttended.Cursor = Cursors.Hand;
            picIconAttended.Image = Icons.status_atendido;
            picIconAttended.Location = new Point(907, 16);
            picIconAttended.Name = "picIconAttended";
            picIconAttended.Size = new Size(43, 49);
            picIconAttended.SizeMode = PictureBoxSizeMode.Zoom;
            picIconAttended.TabIndex = 99;
            picIconAttended.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.FromArgb(239, 68, 68);
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.status_cancelado;
            picIconCancel.Location = new Point(1080, 16);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(48, 49);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Controls.Add(picIconExportExcel);
            panelHeader.Controls.Add(buttonExportExcel);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1280, 87);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(380, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN Y AUDITORÍA DE TURNOS";
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(902, 12);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Padding = new Padding(30, 0, 0, 0);
            buttonExportPdf.Size = new Size(176, 62);
            buttonExportPdf.TabIndex = 1;
            buttonExportPdf.Text = "EXPORTAR PDF";
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            buttonExportExcel.FlatAppearance.BorderSize = 0;
            buttonExportExcel.FlatStyle = FlatStyle.Flat;
            buttonExportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.White;
            buttonExportExcel.Location = new Point(1088, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Padding = new Padding(30, 0, 0, 0);
            buttonExportExcel.Size = new Size(180, 62);
            buttonExportExcel.TabIndex = 2;
            buttonExportExcel.Text = "EXPORTAR EXCEL";
            buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStartPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerStart);
            panelFiltersCard.Controls.Add(labelEndPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerEnd);
            panelFiltersCard.Controls.Add(labelProfPrompt);
            panelFiltersCard.Controls.Add(comboBoxProfessional);
            panelFiltersCard.Controls.Add(labelSpecPrompt);
            panelFiltersCard.Controls.Add(comboBoxSpecialty);
            panelFiltersCard.Controls.Add(labelStatusPrompt);
            panelFiltersCard.Controls.Add(comboBoxStatus);
            panelFiltersCard.Controls.Add(picIconFilter);
            panelFiltersCard.Controls.Add(buttonFilter);
            panelFiltersCard.Dock = DockStyle.Top;
            panelFiltersCard.Location = new Point(0, 87);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Padding = new Padding(16, 10, 16, 10);
            panelFiltersCard.Size = new Size(1280, 77);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelStartPrompt
            // 
            labelStartPrompt.AutoSize = true;
            labelStartPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStartPrompt.Location = new Point(16, 13);
            labelStartPrompt.Name = "labelStartPrompt";
            labelStartPrompt.Size = new Size(56, 20);
            labelStartPrompt.TabIndex = 0;
            labelStartPrompt.Text = "Desde:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(16, 33);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(110, 29);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelEndPrompt
            // 
            labelEndPrompt.AutoSize = true;
            labelEndPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelEndPrompt.Location = new Point(135, 13);
            labelEndPrompt.Name = "labelEndPrompt";
            labelEndPrompt.Size = new Size(53, 20);
            labelEndPrompt.TabIndex = 2;
            labelEndPrompt.Text = "Hasta:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(135, 33);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(110, 29);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // labelProfPrompt
            // 
            labelProfPrompt.AutoSize = true;
            labelProfPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelProfPrompt.Location = new Point(255, 13);
            labelProfPrompt.Name = "labelProfPrompt";
            labelProfPrompt.Size = new Size(92, 20);
            labelProfPrompt.TabIndex = 4;
            labelProfPrompt.Text = "Profesional:";
            // 
            // comboBoxProfessional
            // 
            comboBoxProfessional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfessional.Font = new Font("Segoe UI", 9.5F);
            comboBoxProfessional.Location = new Point(255, 33);
            comboBoxProfessional.Name = "comboBoxProfessional";
            comboBoxProfessional.Size = new Size(240, 29);
            comboBoxProfessional.TabIndex = 5;
            // 
            // labelSpecPrompt
            // 
            labelSpecPrompt.AutoSize = true;
            labelSpecPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSpecPrompt.Location = new Point(505, 13);
            labelSpecPrompt.Name = "labelSpecPrompt";
            labelSpecPrompt.Size = new Size(98, 20);
            labelSpecPrompt.TabIndex = 6;
            labelSpecPrompt.Text = "Especialidad:";
            // 
            // comboBoxSpecialty
            // 
            comboBoxSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialty.Font = new Font("Segoe UI", 9.5F);
            comboBoxSpecialty.Location = new Point(505, 33);
            comboBoxSpecialty.Name = "comboBoxSpecialty";
            comboBoxSpecialty.Size = new Size(210, 29);
            comboBoxSpecialty.TabIndex = 7;
            // 
            // labelStatusPrompt
            // 
            labelStatusPrompt.AutoSize = true;
            labelStatusPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStatusPrompt.Location = new Point(725, 13);
            labelStatusPrompt.Name = "labelStatusPrompt";
            labelStatusPrompt.Size = new Size(60, 20);
            labelStatusPrompt.TabIndex = 8;
            labelStatusPrompt.Text = "Estado:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.Font = new Font("Segoe UI", 9.5F);
            comboBoxStatus.Location = new Point(725, 33);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(180, 29);
            comboBoxStatus.TabIndex = 9;
            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = Color.FromArgb(2, 132, 199);
            buttonFilter.FlatAppearance.BorderSize = 0;
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFilter.ForeColor = Color.White;
            buttonFilter.Location = new Point(1062, 13);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Padding = new Padding(24, 0, 0, 0);
            buttonFilter.Size = new Size(198, 49);
            buttonFilter.TabIndex = 10;
            buttonFilter.Text = "FILTRAR TURNOS";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // panelSearchAndCount
            // 
            panelSearchAndCount.BackColor = Color.FromArgb(248, 250, 252);
            panelSearchAndCount.Controls.Add(labelSearchPrompt);
            panelSearchAndCount.Controls.Add(textBoxSearch);
            panelSearchAndCount.Controls.Add(labelTotalCount);
            panelSearchAndCount.Dock = DockStyle.Top;
            panelSearchAndCount.Location = new Point(0, 164);
            panelSearchAndCount.Name = "panelSearchAndCount";
            panelSearchAndCount.Padding = new Padding(16, 6, 16, 6);
            panelSearchAndCount.Size = new Size(1280, 46);
            panelSearchAndCount.TabIndex = 2;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSearchPrompt.ForeColor = Color.FromArgb(15, 23, 42);
            labelSearchPrompt.Location = new Point(16, 12);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(61, 20);
            labelSearchPrompt.TabIndex = 0;
            labelSearchPrompt.Text = "Buscar:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(83, 8);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Escriba nombre, apellido o DNI del paciente...";
            textBoxSearch.Size = new Size(420, 30);
            textBoxSearch.TabIndex = 1;
            // 
            // labelTotalCount
            // 
            labelTotalCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTotalCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalCount.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalCount.Location = new Point(1050, 12);
            labelTotalCount.Name = "labelTotalCount";
            labelTotalCount.Size = new Size(185, 21);
            labelTotalCount.TabIndex = 2;
            labelTotalCount.Text = "Turnos encontrados: 0";
            labelTotalCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelActionsCard
            // 
            panelActionsCard.BackColor = Color.White;
            panelActionsCard.Controls.Add(labelSelectedInfo);
            panelActionsCard.Controls.Add(picIconConfirm);
            panelActionsCard.Controls.Add(buttonConfirm);
            panelActionsCard.Controls.Add(picIconWaitingRoom);
            panelActionsCard.Controls.Add(buttonWaitingRoom);
            panelActionsCard.Controls.Add(picIconAttended);
            panelActionsCard.Controls.Add(buttonMarkAttended);
            panelActionsCard.Controls.Add(picIconCancel);
            panelActionsCard.Controls.Add(buttonCancel);
            panelActionsCard.Dock = DockStyle.Bottom;
            panelActionsCard.Location = new Point(0, 703);
            panelActionsCard.Name = "panelActionsCard";
            panelActionsCard.Padding = new Padding(16, 8, 16, 8);
            panelActionsCard.Size = new Size(1280, 77);
            panelActionsCard.TabIndex = 3;
            // 
            // labelSelectedInfo
            // 
            labelSelectedInfo.AutoEllipsis = true;
            labelSelectedInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSelectedInfo.ForeColor = Color.FromArgb(15, 23, 42);
            labelSelectedInfo.Location = new Point(19, 29);
            labelSelectedInfo.Name = "labelSelectedInfo";
            labelSelectedInfo.Size = new Size(357, 24);
            labelSelectedInfo.TabIndex = 0;
            labelSelectedInfo.Text = "Haga clic en un turno de la lista para operar.";
            // 
            // buttonConfirm
            // 
            buttonConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonConfirm.BackColor = Color.FromArgb(16, 185, 129);
            buttonConfirm.Cursor = Cursors.Hand;
            buttonConfirm.Enabled = false;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.Location = new Point(589, 16);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Padding = new Padding(22, 0, 0, 0);
            buttonConfirm.Size = new Size(153, 49);
            buttonConfirm.TabIndex = 1;
            buttonConfirm.Text = "CONFIRMAR";
            buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // buttonWaitingRoom
            // 
            buttonWaitingRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonWaitingRoom.BackColor = Color.FromArgb(2, 132, 199);
            buttonWaitingRoom.Cursor = Cursors.Hand;
            buttonWaitingRoom.Enabled = false;
            buttonWaitingRoom.FlatAppearance.BorderSize = 0;
            buttonWaitingRoom.FlatStyle = FlatStyle.Flat;
            buttonWaitingRoom.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonWaitingRoom.ForeColor = Color.White;
            buttonWaitingRoom.Location = new Point(752, 16);
            buttonWaitingRoom.Name = "buttonWaitingRoom";
            buttonWaitingRoom.Padding = new Padding(22, 0, 0, 0);
            buttonWaitingRoom.Size = new Size(145, 49);
            buttonWaitingRoom.TabIndex = 2;
            buttonWaitingRoom.Text = "EN ESPERA";
            buttonWaitingRoom.UseVisualStyleBackColor = false;
            // 
            // buttonMarkAttended
            // 
            buttonMarkAttended.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMarkAttended.BackColor = Color.FromArgb(15, 23, 42);
            buttonMarkAttended.Cursor = Cursors.Hand;
            buttonMarkAttended.Enabled = false;
            buttonMarkAttended.FlatAppearance.BorderSize = 0;
            buttonMarkAttended.FlatStyle = FlatStyle.Flat;
            buttonMarkAttended.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonMarkAttended.ForeColor = Color.White;
            buttonMarkAttended.Location = new Point(907, 16);
            buttonMarkAttended.Name = "buttonMarkAttended";
            buttonMarkAttended.Padding = new Padding(22, 0, 0, 0);
            buttonMarkAttended.Size = new Size(145, 49);
            buttonMarkAttended.TabIndex = 3;
            buttonMarkAttended.Text = "ATENDIDO";
            buttonMarkAttended.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.BackColor = Color.FromArgb(239, 68, 68);
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.Enabled = false;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(1062, 16);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(22, 0, 0, 0);
            buttonCancel.Size = new Size(202, 49);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.BackgroundColor = Color.White;
            dataGridViewAppointments.BorderStyle = BorderStyle.None;
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(0, 214);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.RowHeadersWidth = 51;
            dataGridViewAppointments.Size = new Size(1280, 483);
            dataGridViewAppointments.TabIndex = 4;
            // 
            // FormAppointments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 780);
            Controls.Add(dataGridViewAppointments);
            Controls.Add(panelActionsCard);
            Controls.Add(panelSearchAndCount);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormAppointments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión General de Turnos - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconWaitingRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconAttended).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            panelSearchAndCount.ResumeLayout(false);
            panelSearchAndCount.PerformLayout();
            panelActionsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button buttonExportPdf;
        private Button buttonExportExcel;
        private Panel panelFiltersCard;
        private Label labelStartPrompt;
        private DateTimePicker dateTimePickerStart;
        private Label labelEndPrompt;
        private DateTimePicker dateTimePickerEnd;
        private Label labelProfPrompt;
        private ComboBox comboBoxProfessional;
        private Label labelSpecPrompt;
        private ComboBox comboBoxSpecialty;
        private Label labelStatusPrompt;
        private ComboBox comboBoxStatus;
        private Button buttonFilter;
        private Panel panelSearchAndCount;
        private Label labelSearchPrompt;
        private TextBox textBoxSearch;
        private Label labelTotalCount;
        private Panel panelActionsCard;
        private Label labelSelectedInfo;
        private Button buttonConfirm;
        private Button buttonWaitingRoom;
        private Button buttonMarkAttended;
        private Button buttonCancel;
        private DataGridView dataGridViewAppointments;
        private PictureBox picIconFilter;
        private PictureBox picIconExportPdf;
        private PictureBox picIconExportExcel;
        private PictureBox picIconConfirm;
        private PictureBox picIconWaitingRoom;
        private PictureBox picIconAttended;
        private PictureBox picIconCancel;
    }
}