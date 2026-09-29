namespace CliniqaxSystem.WinFormsUI
{
    partial class FormAppointmentsReport
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
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportPdf = new Button();
            buttonExportExcel = new Button();
            panelFiltersCard = new Panel();
            labelStart = new Label();
            dateTimePickerStart = new DateTimePicker();
            labelEnd = new Label();
            dateTimePickerEnd = new DateTimePicker();
            labelProf = new Label();
            comboBoxProfessional = new ComboBox();
            labelSpec = new Label();
            comboBoxSpecialty = new ComboBox();
            buttonFilter = new Button();
            panelKpisSummary = new Panel();
            labelTotalCount = new Label();
            labelAttendedCount = new Label();
            labelCancelledCount = new Label();
            labelAbsentCount = new Label();
            dataGridViewReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            panelKpisSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // picIconFilter
            // 
            picIconFilter.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilter.Cursor = Cursors.Hand;
            picIconFilter.Image = Icons.action_buscar_filtrar;
            picIconFilter.Location = new Point(835, 13);
            picIconFilter.Name = "picIconFilter";
            picIconFilter.Size = new Size(42, 72);
            picIconFilter.SizeMode = PictureBoxSizeMode.Zoom;
            picIconFilter.TabIndex = 99;
            picIconFilter.TabStop = false;
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Icons.action_exportar_pdf;
            picIconExportPdf.Location = new Point(896, 12);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(43, 61);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconExportExcel
            // 
            picIconExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            picIconExportExcel.Cursor = Cursors.Hand;
            picIconExportExcel.Image = Icons.action_exportar_excel;
            picIconExportExcel.Location = new Point(1089, 12);
            picIconExportExcel.Name = "picIconExportExcel";
            picIconExportExcel.Size = new Size(39, 61);
            picIconExportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportExcel.TabIndex = 99;
            picIconExportExcel.TabStop = false;
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
            panelHeader.Size = new Size(1280, 83);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 24);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(380, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "REPORTE ESTADÍSTICO DE TURNOS";
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(896, 12);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Padding = new Padding(30, 0, 0, 0);
            buttonExportPdf.Size = new Size(174, 61);
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
            buttonExportExcel.Location = new Point(1089, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Padding = new Padding(30, 0, 0, 0);
            buttonExportExcel.Size = new Size(178, 61);
            buttonExportExcel.TabIndex = 2;
            buttonExportExcel.Text = "EXPORTAR EXCEL";
            buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStart);
            panelFiltersCard.Controls.Add(dateTimePickerStart);
            panelFiltersCard.Controls.Add(labelEnd);
            panelFiltersCard.Controls.Add(dateTimePickerEnd);
            panelFiltersCard.Controls.Add(labelProf);
            panelFiltersCard.Controls.Add(comboBoxProfessional);
            panelFiltersCard.Controls.Add(labelSpec);
            panelFiltersCard.Controls.Add(comboBoxSpecialty);
            panelFiltersCard.Controls.Add(picIconFilter);
            panelFiltersCard.Controls.Add(buttonFilter);
            panelFiltersCard.Dock = DockStyle.Top;
            panelFiltersCard.Location = new Point(0, 83);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Padding = new Padding(16, 10, 16, 10);
            panelFiltersCard.Size = new Size(1280, 98);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStart.Location = new Point(19, 21);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(56, 20);
            labelStart.TabIndex = 0;
            labelStart.Text = "Desde:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(19, 41);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(115, 29);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelEnd.Location = new Point(148, 21);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new Size(53, 20);
            labelEnd.TabIndex = 2;
            labelEnd.Text = "Hasta:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(148, 41);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(115, 29);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // labelProf
            // 
            labelProf.AutoSize = true;
            labelProf.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelProf.Location = new Point(278, 21);
            labelProf.Name = "labelProf";
            labelProf.Size = new Size(92, 20);
            labelProf.TabIndex = 4;
            labelProf.Text = "Profesional:";
            // 
            // comboBoxProfessional
            // 
            comboBoxProfessional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfessional.Font = new Font("Segoe UI", 9.5F);
            comboBoxProfessional.Location = new Point(278, 41);
            comboBoxProfessional.Name = "comboBoxProfessional";
            comboBoxProfessional.Size = new Size(250, 29);
            comboBoxProfessional.TabIndex = 5;
            // 
            // labelSpec
            // 
            labelSpec.AutoSize = true;
            labelSpec.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSpec.Location = new Point(543, 21);
            labelSpec.Name = "labelSpec";
            labelSpec.Size = new Size(98, 20);
            labelSpec.TabIndex = 6;
            labelSpec.Text = "Especialidad:";
            // 
            // comboBoxSpecialty
            // 
            comboBoxSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialty.Font = new Font("Segoe UI", 9.5F);
            comboBoxSpecialty.Location = new Point(543, 41);
            comboBoxSpecialty.Name = "comboBoxSpecialty";
            comboBoxSpecialty.Size = new Size(240, 29);
            comboBoxSpecialty.TabIndex = 7;
            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = Color.FromArgb(2, 132, 199);
            buttonFilter.FlatAppearance.BorderSize = 0;
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFilter.ForeColor = Color.White;
            buttonFilter.Location = new Point(823, 13);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Padding = new Padding(22, 0, 0, 0);
            buttonFilter.Size = new Size(201, 72);
            buttonFilter.TabIndex = 8;
            buttonFilter.Text = "FILTRAR DATOS";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // panelKpisSummary
            // 
            panelKpisSummary.BackColor = Color.FromArgb(248, 250, 252);
            panelKpisSummary.Controls.Add(labelTotalCount);
            panelKpisSummary.Controls.Add(labelAttendedCount);
            panelKpisSummary.Controls.Add(labelCancelledCount);
            panelKpisSummary.Controls.Add(labelAbsentCount);
            panelKpisSummary.Dock = DockStyle.Top;
            panelKpisSummary.Location = new Point(0, 181);
            panelKpisSummary.Name = "panelKpisSummary";
            panelKpisSummary.Padding = new Padding(16, 8, 16, 8);
            panelKpisSummary.Size = new Size(1280, 56);
            panelKpisSummary.TabIndex = 2;
            // 
            // labelTotalCount
            // 
            labelTotalCount.AutoSize = true;
            labelTotalCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalCount.ForeColor = Color.FromArgb(15, 23, 42);
            labelTotalCount.Location = new Point(16, 18);
            labelTotalCount.Name = "labelTotalCount";
            labelTotalCount.Size = new Size(65, 21);
            labelTotalCount.TabIndex = 0;
            labelTotalCount.Text = "Total: 0";
            // 
            // labelAttendedCount
            // 
            labelAttendedCount.AutoSize = true;
            labelAttendedCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAttendedCount.ForeColor = Color.FromArgb(16, 185, 129);
            labelAttendedCount.Location = new Point(150, 18);
            labelAttendedCount.Name = "labelAttendedCount";
            labelAttendedCount.Size = new Size(105, 21);
            labelAttendedCount.TabIndex = 1;
            labelAttendedCount.Text = "Atendidos: 0";
            // 
            // labelCancelledCount
            // 
            labelCancelledCount.AutoSize = true;
            labelCancelledCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCancelledCount.ForeColor = Color.FromArgb(239, 68, 68);
            labelCancelledCount.Location = new Point(320, 18);
            labelCancelledCount.Name = "labelCancelledCount";
            labelCancelledCount.Size = new Size(114, 21);
            labelCancelledCount.TabIndex = 2;
            labelCancelledCount.Text = "Cancelados: 0";
            // 
            // labelAbsentCount
            // 
            labelAbsentCount.AutoSize = true;
            labelAbsentCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAbsentCount.ForeColor = Color.FromArgb(100, 116, 139);
            labelAbsentCount.Location = new Point(500, 18);
            labelAbsentCount.Name = "labelAbsentCount";
            labelAbsentCount.Size = new Size(96, 21);
            labelAbsentCount.TabIndex = 3;
            labelAbsentCount.Text = "Ausentes: 0";
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.BackgroundColor = Color.White;
            dataGridViewReport.BorderStyle = BorderStyle.None;
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(0, 243);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.RowHeadersWidth = 51;
            dataGridViewReport.Size = new Size(1280, 537);
            dataGridViewReport.TabIndex = 3;
            // 
            // FormAppointmentsReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 780);
            Controls.Add(dataGridViewReport);
            Controls.Add(panelKpisSummary);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormAppointmentsReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte Estadístico de Turnos - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            panelKpisSummary.ResumeLayout(false);
            panelKpisSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button buttonExportPdf;
        private Button buttonExportExcel;
        private Panel panelFiltersCard;
        private Label labelStart;
        private DateTimePicker dateTimePickerStart;
        private Label labelEnd;
        private DateTimePicker dateTimePickerEnd;
        private Label labelProf;
        private ComboBox comboBoxProfessional;
        private Label labelSpec;
        private ComboBox comboBoxSpecialty;
        private Button buttonFilter;
        private Panel panelKpisSummary;
        private Label labelTotalCount;
        private Label labelAttendedCount;
        private Label labelCancelledCount;
        private Label labelAbsentCount;
        private DataGridView dataGridViewReport;
        private PictureBox picIconFilter;
        private PictureBox picIconExportPdf;
        private PictureBox picIconExportExcel;
    }
}