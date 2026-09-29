namespace CliniqaxSystem.WinFormsUI
{
    partial class FormHome
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
            tableLayoutPanelKpis = new TableLayoutPanel();
            panelCardAppointments = new Panel();
            labelAppointmentsTitle = new Label();
            labelTodayAppointmentsCount = new Label();
            panelCardWaiting = new Panel();
            labelWaitingTitle = new Label();
            labelWaitingAndConfirmedCount = new Label();
            panelCardAttended = new Panel();
            labelAttendedTitle = new Label();
            labelAttendedCount = new Label();
            panelCardIncome = new Panel();
            labelIncomeTitle = new Label();
            labelTodayIncome = new Label();
            panelCenterContent = new Panel();
            dataGridViewUpcomingAppointments = new DataGridView();
            panelGridHeader = new Panel();
            labelUpcomingTitle = new Label();
            tableLayoutPanelKpis.SuspendLayout();
            panelCardAppointments.SuspendLayout();
            panelCardWaiting.SuspendLayout();
            panelCardAttended.SuspendLayout();
            panelCardIncome.SuspendLayout();
            panelCenterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingAppointments).BeginInit();
            panelGridHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelKpis
            // 
            tableLayoutPanelKpis.ColumnCount = 4;
            tableLayoutPanelKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelKpis.Controls.Add(panelCardAppointments, 0, 0);
            tableLayoutPanelKpis.Controls.Add(panelCardWaiting, 1, 0);
            tableLayoutPanelKpis.Controls.Add(panelCardAttended, 2, 0);
            tableLayoutPanelKpis.Controls.Add(panelCardIncome, 3, 0);
            tableLayoutPanelKpis.Dock = DockStyle.Top;
            tableLayoutPanelKpis.Location = new Point(0, 0);
            tableLayoutPanelKpis.Name = "tableLayoutPanelKpis";
            tableLayoutPanelKpis.Padding = new Padding(16, 12, 16, 8);
            tableLayoutPanelKpis.RowCount = 1;
            tableLayoutPanelKpis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelKpis.Size = new Size(1200, 115);
            tableLayoutPanelKpis.TabIndex = 0;
            // 
            // panelCardAppointments
            // 
            panelCardAppointments.BackColor = Color.White;
            panelCardAppointments.Controls.Add(labelAppointmentsTitle);
            panelCardAppointments.Controls.Add(labelTodayAppointmentsCount);
            panelCardAppointments.Dock = DockStyle.Fill;
            panelCardAppointments.Location = new Point(19, 15);
            panelCardAppointments.Name = "panelCardAppointments";
            panelCardAppointments.Padding = new Padding(12);
            panelCardAppointments.Size = new Size(286, 89);
            panelCardAppointments.TabIndex = 0;
            // 
            // labelAppointmentsTitle
            // 
            labelAppointmentsTitle.AutoSize = true;
            labelAppointmentsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAppointmentsTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelAppointmentsTitle.Location = new Point(12, 10);
            labelAppointmentsTitle.Name = "labelAppointmentsTitle";
            labelAppointmentsTitle.Size = new Size(128, 20);
            labelAppointmentsTitle.TabIndex = 0;
            labelAppointmentsTitle.Text = "TURNOS DE HOY";
            // 
            // labelTodayAppointmentsCount
            // 
            labelTodayAppointmentsCount.AutoSize = true;
            labelTodayAppointmentsCount.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTodayAppointmentsCount.ForeColor = Color.FromArgb(2, 132, 199);
            labelTodayAppointmentsCount.Location = new Point(10, 32);
            labelTodayAppointmentsCount.Name = "labelTodayAppointmentsCount";
            labelTodayAppointmentsCount.Size = new Size(40, 46);
            labelTodayAppointmentsCount.TabIndex = 1;
            labelTodayAppointmentsCount.Text = "0";
            // 
            // panelCardWaiting
            // 
            panelCardWaiting.BackColor = Color.White;
            panelCardWaiting.Controls.Add(labelWaitingTitle);
            panelCardWaiting.Controls.Add(labelWaitingAndConfirmedCount);
            panelCardWaiting.Dock = DockStyle.Fill;
            panelCardWaiting.Location = new Point(311, 15);
            panelCardWaiting.Name = "panelCardWaiting";
            panelCardWaiting.Padding = new Padding(12);
            panelCardWaiting.Size = new Size(286, 89);
            panelCardWaiting.TabIndex = 1;
            // 
            // labelWaitingTitle
            // 
            labelWaitingTitle.AutoSize = true;
            labelWaitingTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelWaitingTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelWaitingTitle.Location = new Point(12, 10);
            labelWaitingTitle.Name = "labelWaitingTitle";
            labelWaitingTitle.Size = new Size(188, 20);
            labelWaitingTitle.TabIndex = 0;
            labelWaitingTitle.Text = "CONFIRMADOS / ESPERA";
            // 
            // labelWaitingAndConfirmedCount
            // 
            labelWaitingAndConfirmedCount.AutoSize = true;
            labelWaitingAndConfirmedCount.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelWaitingAndConfirmedCount.ForeColor = Color.FromArgb(245, 158, 11);
            labelWaitingAndConfirmedCount.Location = new Point(10, 32);
            labelWaitingAndConfirmedCount.Name = "labelWaitingAndConfirmedCount";
            labelWaitingAndConfirmedCount.Size = new Size(40, 46);
            labelWaitingAndConfirmedCount.TabIndex = 1;
            labelWaitingAndConfirmedCount.Text = "0";
            // 
            // panelCardAttended
            // 
            panelCardAttended.BackColor = Color.White;
            panelCardAttended.Controls.Add(labelAttendedTitle);
            panelCardAttended.Controls.Add(labelAttendedCount);
            panelCardAttended.Dock = DockStyle.Fill;
            panelCardAttended.Location = new Point(603, 15);
            panelCardAttended.Name = "panelCardAttended";
            panelCardAttended.Padding = new Padding(12);
            panelCardAttended.Size = new Size(286, 89);
            panelCardAttended.TabIndex = 2;
            // 
            // labelAttendedTitle
            // 
            labelAttendedTitle.AutoSize = true;
            labelAttendedTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAttendedTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelAttendedTitle.Location = new Point(12, 10);
            labelAttendedTitle.Name = "labelAttendedTitle";
            labelAttendedTitle.Size = new Size(176, 20);
            labelAttendedTitle.TabIndex = 0;
            labelAttendedTitle.Text = "PACIENTES ATENDIDOS";
            // 
            // labelAttendedCount
            // 
            labelAttendedCount.AutoSize = true;
            labelAttendedCount.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelAttendedCount.ForeColor = Color.FromArgb(16, 185, 129);
            labelAttendedCount.Location = new Point(10, 32);
            labelAttendedCount.Name = "labelAttendedCount";
            labelAttendedCount.Size = new Size(40, 46);
            labelAttendedCount.TabIndex = 1;
            labelAttendedCount.Text = "0";
            // 
            // panelCardIncome
            // 
            panelCardIncome.BackColor = Color.White;
            panelCardIncome.Controls.Add(labelIncomeTitle);
            panelCardIncome.Controls.Add(labelTodayIncome);
            panelCardIncome.Dock = DockStyle.Fill;
            panelCardIncome.Location = new Point(895, 15);
            panelCardIncome.Name = "panelCardIncome";
            panelCardIncome.Padding = new Padding(12);
            panelCardIncome.Size = new Size(286, 89);
            panelCardIncome.TabIndex = 3;
            // 
            // labelIncomeTitle
            // 
            labelIncomeTitle.AutoSize = true;
            labelIncomeTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelIncomeTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelIncomeTitle.Location = new Point(12, 10);
            labelIncomeTitle.Name = "labelIncomeTitle";
            labelIncomeTitle.Size = new Size(183, 20);
            labelIncomeTitle.TabIndex = 0;
            labelIncomeTitle.Text = "RECAUDACIÓN DE CAJA";
            // 
            // labelTodayIncome
            // 
            labelTodayIncome.AutoSize = true;
            labelTodayIncome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTodayIncome.ForeColor = Color.FromArgb(15, 23, 42);
            labelTodayIncome.Location = new Point(10, 35);
            labelTodayIncome.Name = "labelTodayIncome";
            labelTodayIncome.Size = new Size(102, 41);
            labelTodayIncome.TabIndex = 1;
            labelTodayIncome.Text = "$ 0,00";
            // 
            // panelCenterContent
            // 
            panelCenterContent.BackColor = Color.White;
            panelCenterContent.Controls.Add(dataGridViewUpcomingAppointments);
            panelCenterContent.Controls.Add(panelGridHeader);
            panelCenterContent.Dock = DockStyle.Fill;
            panelCenterContent.Location = new Point(0, 115);
            panelCenterContent.Name = "panelCenterContent";
            panelCenterContent.Padding = new Padding(16);
            panelCenterContent.Size = new Size(1200, 585);
            panelCenterContent.TabIndex = 1;
            // 
            // dataGridViewUpcomingAppointments
            // 
            dataGridViewUpcomingAppointments.BackgroundColor = Color.White;
            dataGridViewUpcomingAppointments.BorderStyle = BorderStyle.None;
            dataGridViewUpcomingAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUpcomingAppointments.Dock = DockStyle.Fill;
            dataGridViewUpcomingAppointments.Location = new Point(16, 56);
            dataGridViewUpcomingAppointments.Name = "dataGridViewUpcomingAppointments";
            dataGridViewUpcomingAppointments.RowHeadersWidth = 51;
            dataGridViewUpcomingAppointments.Size = new Size(1168, 513);
            dataGridViewUpcomingAppointments.TabIndex = 1;
            // 
            // panelGridHeader
            // 
            panelGridHeader.Controls.Add(labelUpcomingTitle);
            panelGridHeader.Dock = DockStyle.Top;
            panelGridHeader.Location = new Point(16, 16);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Size = new Size(1168, 40);
            panelGridHeader.TabIndex = 0;
            // 
            // labelUpcomingTitle
            // 
            labelUpcomingTitle.AutoSize = true;
            labelUpcomingTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelUpcomingTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelUpcomingTitle.Location = new Point(0, 6);
            labelUpcomingTitle.Name = "labelUpcomingTitle";
            labelUpcomingTitle.Size = new Size(328, 25);
            labelUpcomingTitle.TabIndex = 0;
            labelUpcomingTitle.Text = "Próximos Turnos del Día (En Curso)";
            labelUpcomingTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1200, 700);
            Controls.Add(panelCenterContent);
            Controls.Add(tableLayoutPanelKpis);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHome";
            Text = "Dashboard";
            tableLayoutPanelKpis.ResumeLayout(false);
            panelCardAppointments.ResumeLayout(false);
            panelCardAppointments.PerformLayout();
            panelCardWaiting.ResumeLayout(false);
            panelCardWaiting.PerformLayout();
            panelCardAttended.ResumeLayout(false);
            panelCardAttended.PerformLayout();
            panelCardIncome.ResumeLayout(false);
            panelCardIncome.PerformLayout();
            panelCenterContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpcomingAppointments).EndInit();
            panelGridHeader.ResumeLayout(false);
            panelGridHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelKpis;
        private Panel panelCardAppointments;
        private Label labelAppointmentsTitle;
        private Label labelTodayAppointmentsCount;
        private Panel panelCardWaiting;
        private Label labelWaitingTitle;
        private Label labelWaitingAndConfirmedCount;
        private Panel panelCardAttended;
        private Label labelAttendedTitle;
        private Label labelAttendedCount;
        private Panel panelCardIncome;
        private Label labelIncomeTitle;
        private Label labelTodayIncome;
        private Panel panelCenterContent;
        private Panel panelGridHeader;
        private Label labelUpcomingTitle;
        private DataGridView dataGridViewUpcomingAppointments;
    }
}