namespace CliniqaxSystem.WinFormsUI
{
    partial class FormAuditViewer
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
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            picIconFilter = new PictureBox();
            buttonFilter = new Button();
            labelTotalCount = new Label();
            dataGridViewAudit = new DataGridView();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAudit).BeginInit();
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
            labelTitle.Size = new Size(132, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "AUDITORÍA";
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStartPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerStart);
            panelFiltersCard.Controls.Add(labelEndPrompt);
            panelFiltersCard.Controls.Add(dateTimePickerEnd);
            panelFiltersCard.Controls.Add(labelSearchPrompt);
            panelFiltersCard.Controls.Add(textBoxSearch);
            panelFiltersCard.Controls.Add(picIconFilter);
            panelFiltersCard.Controls.Add(buttonFilter);
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
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(285, 10);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(61, 20);
            labelSearchPrompt.TabIndex = 4;
            labelSearchPrompt.Text = "Buscar:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(285, 33);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Escriba usuario, acción, entidad...";
            textBoxSearch.Size = new Size(320, 30);
            textBoxSearch.TabIndex = 5;
            // 
            // picIconFilter
            // 
            picIconFilter.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilter.Cursor = Cursors.Hand;
            picIconFilter.Image = Icons.action_buscar_filtrar;
            picIconFilter.Location = new Point(620, 27);
            picIconFilter.Name = "picIconFilter";
            picIconFilter.Size = new Size(35, 40);
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
            buttonFilter.Location = new Point(620, 27);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Padding = new Padding(26, 0, 0, 0);
            buttonFilter.Size = new Size(160, 40);
            buttonFilter.TabIndex = 6;
            buttonFilter.Text = "FILTRAR";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // labelTotalCount
            // 
            labelTotalCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTotalCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalCount.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalCount.Location = new Point(819, 34);
            labelTotalCount.Name = "labelTotalCount";
            labelTotalCount.Size = new Size(267, 25);
            labelTotalCount.TabIndex = 7;
            labelTotalCount.Text = "Registros de Auditoría: 0";
            labelTotalCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataGridViewAudit
            // 
            dataGridViewAudit.BackgroundColor = Color.White;
            dataGridViewAudit.BorderStyle = BorderStyle.None;
            dataGridViewAudit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAudit.Dock = DockStyle.Fill;
            dataGridViewAudit.Location = new Point(0, 136);
            dataGridViewAudit.Name = "dataGridViewAudit";
            dataGridViewAudit.RowHeadersWidth = 51;
            dataGridViewAudit.Size = new Size(1150, 604);
            dataGridViewAudit.TabIndex = 2;
            // 
            // FormAuditViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1150, 740);
            Controls.Add(dataGridViewAudit);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormAuditViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visor de Auditoría - Cliniqax";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAudit).EndInit();
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
        private Label labelSearchPrompt;
        private TextBox textBoxSearch;
        private Button buttonFilter;
        private PictureBox picIconFilter;
        private Label labelTotalCount;
        private DataGridView dataGridViewAudit;
    }
}