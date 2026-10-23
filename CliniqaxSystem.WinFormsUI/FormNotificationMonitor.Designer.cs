namespace CliniqaxSystem.WinFormsUI
{
    partial class FormNotificationMonitor
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
            labelTitle = new Label();
            panelFiltersCard = new Panel();
            labelStartPrompt = new Label();
            dateTimePickerStart = new DateTimePicker();
            labelEndPrompt = new Label();
            dateTimePickerEnd = new DateTimePicker();
            picIconFilter = new PictureBox();
            buttonFilter = new Button();
            picIconProcessQueue = new PictureBox();
            buttonProcessQueueNow = new Button();
            labelTotalCount = new Label();
            panelActionsCard = new Panel();
            labelSelectedInfo = new Label();
            picIconRetry = new PictureBox();
            buttonRetry = new Button();
            dataGridViewNotifications = new DataGridView();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconProcessQueue).BeginInit();
            panelActionsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconRetry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotifications).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1150, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(439, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MONITOR CENTRAL DE NOTIFICACIONES";
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStartPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerStart);
            panelFiltersCard.Controls.Add(labelEndPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerEnd);
            panelFiltersCard.Controls.Add(picIconFilter);
            panelFiltersCard.Controls.Add(buttonFilter);
            panelFiltersCard.Controls.Add(picIconProcessQueue);
            panelFiltersCard.Controls.Add(buttonProcessQueueNow);
            panelFiltersCard.Controls.Add(labelTotalCount);
            panelFiltersCard.Dock = DockStyle.Top;
            panelFiltersCard.Location = new Point(0, 56);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Padding = new Padding(16, 10, 16, 10);
            panelFiltersCard.Size = new Size(1150, 80);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelStartPrompt
            // 
            labelStartPrompt.AutoSize = true;
            labelStartPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStartPrompt.Location = new Point(16, 10);
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
            dateTimePickerStart.Size = new Size(120, 29);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelEndPrompt
            // 
            labelEndPrompt.AutoSize = true;
            labelEndPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelEndPrompt.Location = new Point(150, 10);
            labelEndPrompt.Name = "labelEndPrompt";
            labelEndPrompt.Size = new Size(53, 20);
            labelEndPrompt.TabIndex = 2;
            labelEndPrompt.Text = "Hasta:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(150, 33);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(120, 29);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // picIconFilter
            // 
            picIconFilter.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilter.Cursor = Cursors.Hand;
            picIconFilter.Image = Icons.action_buscar_filtrar;
            picIconFilter.Location = new Point(285, 27);
            picIconFilter.Name = "picIconFilter";
            picIconFilter.Size = new Size(46, 40);
            picIconFilter.SizeMode = PictureBoxSizeMode.Zoom;
            picIconFilter.TabIndex = 99;
            picIconFilter.TabStop = false;
            // 
            // buttonFilter
            // 
            buttonFilter.BackColor = Color.FromArgb(2, 132, 199);
            buttonFilter.Cursor = Cursors.Hand;
            buttonFilter.FlatAppearance.BorderSize = 0;
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFilter.ForeColor = Color.White;
            buttonFilter.Location = new Point(285, 27);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Padding = new Padding(26, 0, 0, 0);
            buttonFilter.Size = new Size(140, 40);
            buttonFilter.TabIndex = 4;
            buttonFilter.Text = "FILTRAR";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // picIconProcessQueue
            // 
            picIconProcessQueue.BackColor = Color.FromArgb(16, 185, 129);
            picIconProcessQueue.Cursor = Cursors.Hand;
            picIconProcessQueue.Image = Icons.action_guardar;
            picIconProcessQueue.Location = new Point(464, 27);
            picIconProcessQueue.Name = "picIconProcessQueue";
            picIconProcessQueue.Size = new Size(49, 40);
            picIconProcessQueue.SizeMode = PictureBoxSizeMode.Zoom;
            picIconProcessQueue.TabIndex = 99;
            picIconProcessQueue.TabStop = false;
            // 
            // buttonProcessQueueNow
            // 
            buttonProcessQueueNow.BackColor = Color.FromArgb(16, 185, 129);
            buttonProcessQueueNow.Cursor = Cursors.Hand;
            buttonProcessQueueNow.FlatAppearance.BorderSize = 0;
            buttonProcessQueueNow.FlatStyle = FlatStyle.Flat;
            buttonProcessQueueNow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonProcessQueueNow.ForeColor = Color.White;
            buttonProcessQueueNow.Location = new Point(440, 27);
            buttonProcessQueueNow.Name = "buttonProcessQueueNow";
            buttonProcessQueueNow.Padding = new Padding(26, 0, 0, 0);
            buttonProcessQueueNow.Size = new Size(240, 40);
            buttonProcessQueueNow.TabIndex = 5;
            buttonProcessQueueNow.Text = "PROCESAR COLA";
            buttonProcessQueueNow.UseVisualStyleBackColor = false;
            // 
            // labelTotalCount
            // 
            labelTotalCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTotalCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalCount.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalCount.Location = new Point(838, 33);
            labelTotalCount.Name = "labelTotalCount";
            labelTotalCount.Size = new Size(240, 25);
            labelTotalCount.TabIndex = 6;
            labelTotalCount.Text = "Notificaciones Registradas: 0";
            labelTotalCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelActionsCard
            // 
            panelActionsCard.BackColor = Color.White;
            panelActionsCard.Controls.Add(labelSelectedInfo);
            panelActionsCard.Controls.Add(picIconRetry);
            panelActionsCard.Controls.Add(buttonRetry);
            panelActionsCard.Dock = DockStyle.Bottom;
            panelActionsCard.Location = new Point(0, 675);
            panelActionsCard.Name = "panelActionsCard";
            panelActionsCard.Padding = new Padding(16, 10, 16, 10);
            panelActionsCard.Size = new Size(1150, 65);
            panelActionsCard.TabIndex = 2;
            // 
            // labelSelectedInfo
            // 
            labelSelectedInfo.AutoEllipsis = true;
            labelSelectedInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSelectedInfo.ForeColor = Color.FromArgb(100, 116, 139);
            labelSelectedInfo.Location = new Point(16, 20);
            labelSelectedInfo.Name = "labelSelectedInfo";
            labelSelectedInfo.Size = new Size(800, 25);
            labelSelectedInfo.TabIndex = 0;
            labelSelectedInfo.Text = "Haga clic en una notificación para ver opciones.";
            // 
            // picIconRetry
            // 
            picIconRetry.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picIconRetry.BackColor = Color.FromArgb(245, 158, 11);
            picIconRetry.Cursor = Cursors.Hand;
            picIconRetry.Image = Icons.action_activar_desactivar;
            picIconRetry.Location = new Point(910, 12);
            picIconRetry.Name = "picIconRetry";
            picIconRetry.Size = new Size(32, 40);
            picIconRetry.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRetry.TabIndex = 99;
            picIconRetry.TabStop = false;
            // 
            // buttonRetry
            // 
            buttonRetry.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRetry.BackColor = Color.FromArgb(245, 158, 11);
            buttonRetry.Cursor = Cursors.Hand;
            buttonRetry.Enabled = false;
            buttonRetry.FlatAppearance.BorderSize = 0;
            buttonRetry.FlatStyle = FlatStyle.Flat;
            buttonRetry.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRetry.ForeColor = Color.White;
            buttonRetry.Location = new Point(910, 12);
            buttonRetry.Name = "buttonRetry";
            buttonRetry.Padding = new Padding(26, 0, 0, 0);
            buttonRetry.Size = new Size(220, 42);
            buttonRetry.TabIndex = 1;
            buttonRetry.Text = "REINTENTAR ENVÍO";
            buttonRetry.UseVisualStyleBackColor = false;
            // 
            // dataGridViewNotifications
            // 
            dataGridViewNotifications.BackgroundColor = Color.White;
            dataGridViewNotifications.BorderStyle = BorderStyle.None;
            dataGridViewNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotifications.Dock = DockStyle.Fill;
            dataGridViewNotifications.Location = new Point(0, 136);
            dataGridViewNotifications.Name = "dataGridViewNotifications";
            dataGridViewNotifications.RowHeadersWidth = 51;
            dataGridViewNotifications.Size = new Size(1150, 539);
            dataGridViewNotifications.TabIndex = 3;
            // 
            // FormNotificationMonitor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1150, 740);
            Controls.Add(dataGridViewNotifications);
            Controls.Add(panelActionsCard);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormNotificationMonitor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monitor de Notificaciones - Cliniqax";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconProcessQueue).EndInit();
            panelActionsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconRetry).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotifications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelFiltersCard;
        private Label labelStartPrompt;
        private DateTimePicker dateTimePickerStart;
        private Label labelEndPrompt;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonFilter;
        private PictureBox picIconFilter;
        private Button buttonProcessQueueNow;
        private PictureBox picIconProcessQueue;
        private Label labelTotalCount;
        private Panel panelActionsCard;
        private Label labelSelectedInfo;
        private Button buttonRetry;
        private PictureBox picIconRetry;
        private DataGridView dataGridViewNotifications;
    }
}