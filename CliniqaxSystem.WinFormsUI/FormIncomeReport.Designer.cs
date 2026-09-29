namespace CliniqaxSystem.WinFormsUI
{
    partial class FormIncomeReport
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
            picIconExportExcel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportExcel = new Button();
            panelFiltersCard = new Panel();
            labelStart = new Label();
            dateTimePickerStart = new DateTimePicker();
            labelEnd = new Label();
            dateTimePickerEnd = new DateTimePicker();
            buttonFilter = new Button();
            panelSummaryBar = new Panel();
            labelTotalRevenueTitle = new Label();
            labelTotalRevenue = new Label();
            labelCopayTotal = new Label();
            labelCashTotal = new Label();
            labelDigitalTotal = new Label();
            dataGridViewIncome = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            panelSummaryBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIncome).BeginInit();
            SuspendLayout();
            // 
            // picIconFilter
            // 
            picIconFilter.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilter.Cursor = Cursors.Hand;
            picIconFilter.Image = Icons.action_buscar_filtrar;
            picIconFilter.Location = new Point(276, 13);
            picIconFilter.Name = "picIconFilter";
            picIconFilter.Size = new Size(42, 49);
            picIconFilter.SizeMode = PictureBoxSizeMode.Zoom;
            picIconFilter.TabIndex = 99;
            picIconFilter.TabStop = false;
            // 
            // picIconExportExcel
            // 
            picIconExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            picIconExportExcel.Cursor = Cursors.Hand;
            picIconExportExcel.Image = Icons.action_exportar_excel;
            picIconExportExcel.Location = new Point(1077, 12);
            picIconExportExcel.Name = "picIconExportExcel";
            picIconExportExcel.Size = new Size(40, 62);
            picIconExportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportExcel.TabIndex = 99;
            picIconExportExcel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconExportExcel);
            panelHeader.Controls.Add(buttonExportExcel);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1280, 81);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(524, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "REPORTE DE INGRESOS Y FACTURACIÓN MÉDICA";
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            buttonExportExcel.FlatAppearance.BorderSize = 0;
            buttonExportExcel.FlatStyle = FlatStyle.Flat;
            buttonExportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.White;
            buttonExportExcel.Location = new Point(1066, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Padding = new Padding(30, 0, 0, 0);
            buttonExportExcel.Size = new Size(199, 62);
            buttonExportExcel.TabIndex = 1;
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
            panelFiltersCard.Controls.Add(picIconFilter);
            panelFiltersCard.Controls.Add(buttonFilter);
            panelFiltersCard.Dock = DockStyle.Top;
            panelFiltersCard.Location = new Point(0, 81);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Padding = new Padding(16, 10, 16, 10);
            panelFiltersCard.Size = new Size(1280, 75);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStart.Location = new Point(16, 6);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(56, 20);
            labelStart.TabIndex = 0;
            labelStart.Text = "Desde:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(16, 26);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(115, 29);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelEnd.Location = new Point(145, 6);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new Size(53, 20);
            labelEnd.TabIndex = 2;
            labelEnd.Text = "Hasta:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(145, 26);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(115, 29);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = Color.FromArgb(2, 132, 199);
            buttonFilter.FlatAppearance.BorderSize = 0;
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFilter.ForeColor = Color.White;
            buttonFilter.Location = new Point(276, 13);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Padding = new Padding(22, 0, 0, 0);
            buttonFilter.Size = new Size(182, 49);
            buttonFilter.TabIndex = 4;
            buttonFilter.Text = "FILTRAR FECHAS";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // panelSummaryBar
            // 
            panelSummaryBar.BackColor = Color.FromArgb(248, 250, 252);
            panelSummaryBar.Controls.Add(labelTotalRevenueTitle);
            panelSummaryBar.Controls.Add(labelTotalRevenue);
            panelSummaryBar.Controls.Add(labelCopayTotal);
            panelSummaryBar.Controls.Add(labelCashTotal);
            panelSummaryBar.Controls.Add(labelDigitalTotal);
            panelSummaryBar.Dock = DockStyle.Top;
            panelSummaryBar.Location = new Point(0, 156);
            panelSummaryBar.Name = "panelSummaryBar";
            panelSummaryBar.Padding = new Padding(16, 6, 16, 6);
            panelSummaryBar.Size = new Size(1280, 50);
            panelSummaryBar.TabIndex = 2;
            // 
            // labelTotalRevenueTitle
            // 
            labelTotalRevenueTitle.AutoSize = true;
            labelTotalRevenueTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTotalRevenueTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelTotalRevenueTitle.Location = new Point(16, 14);
            labelTotalRevenueTitle.Name = "labelTotalRevenueTitle";
            labelTotalRevenueTitle.Size = new Size(177, 23);
            labelTotalRevenueTitle.TabIndex = 0;
            labelTotalRevenueTitle.Text = "TOTAL RECAUDADO:";
            // 
            // labelTotalRevenue
            // 
            labelTotalRevenue.AutoSize = true;
            labelTotalRevenue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTotalRevenue.ForeColor = Color.FromArgb(16, 185, 129);
            labelTotalRevenue.Location = new Point(185, 11);
            labelTotalRevenue.Name = "labelTotalRevenue";
            labelTotalRevenue.Size = new Size(71, 28);
            labelTotalRevenue.TabIndex = 1;
            labelTotalRevenue.Text = "$ 0,00";
            // 
            // labelCopayTotal
            // 
            labelCopayTotal.AutoSize = true;
            labelCopayTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCopayTotal.ForeColor = Color.FromArgb(245, 158, 11);
            labelCopayTotal.Location = new Point(360, 14);
            labelCopayTotal.Name = "labelCopayTotal";
            labelCopayTotal.Size = new Size(128, 21);
            labelCopayTotal.TabIndex = 2;
            labelCopayTotal.Text = "Copagos: $ 0,00";
            // 
            // labelCashTotal
            // 
            labelCashTotal.AutoSize = true;
            labelCashTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCashTotal.ForeColor = Color.FromArgb(2, 132, 199);
            labelCashTotal.Location = new Point(600, 14);
            labelCashTotal.Name = "labelCashTotal";
            labelCashTotal.Size = new Size(124, 21);
            labelCashTotal.TabIndex = 3;
            labelCashTotal.Text = "Efectivo: $ 0,00";
            // 
            // labelDigitalTotal
            // 
            labelDigitalTotal.AutoSize = true;
            labelDigitalTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDigitalTotal.ForeColor = Color.FromArgb(100, 116, 139);
            labelDigitalTotal.Location = new Point(830, 14);
            labelDigitalTotal.Name = "labelDigitalTotal";
            labelDigitalTotal.Size = new Size(151, 21);
            labelDigitalTotal.TabIndex = 4;
            labelDigitalTotal.Text = "Digital / QR: $ 0,00";
            // 
            // dataGridViewIncome
            // 
            dataGridViewIncome.BackgroundColor = Color.White;
            dataGridViewIncome.BorderStyle = BorderStyle.None;
            dataGridViewIncome.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIncome.Dock = DockStyle.Fill;
            dataGridViewIncome.Location = new Point(0, 206);
            dataGridViewIncome.Name = "dataGridViewIncome";
            dataGridViewIncome.RowHeadersWidth = 51;
            dataGridViewIncome.Size = new Size(1280, 574);
            dataGridViewIncome.TabIndex = 3;
            // 
            // FormIncomeReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 780);
            Controls.Add(dataGridViewIncome);
            Controls.Add(panelSummaryBar);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormIncomeReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Ingresos - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            panelSummaryBar.ResumeLayout(false);
            panelSummaryBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIncome).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button buttonExportExcel;
        private Panel panelFiltersCard;
        private Label labelStart;
        private DateTimePicker dateTimePickerStart;
        private Label labelEnd;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonFilter;
        private Panel panelSummaryBar;
        private Label labelTotalRevenueTitle;
        private Label labelTotalRevenue;
        private Label labelCopayTotal;
        private Label labelCashTotal;
        private Label labelDigitalTotal;
        private DataGridView dataGridViewIncome;
        private PictureBox picIconFilter;
        private PictureBox picIconExportExcel;
    }
}