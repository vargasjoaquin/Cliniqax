namespace CliniqaxSystem.WinFormsUI
{
    partial class FormRestoreRecords
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
            picIconRestoreRecord = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelControlsCard = new Panel();
            labelEntityTypePrompt = new Label();
            comboBoxEntityType = new ComboBox();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            labelSelectedItemInfo = new Label();
            buttonRestoreRecord = new Button();
            labelRecordCount = new Label();
            dataGridViewDeletedRecords = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconRestoreRecord).BeginInit();
            panelHeader.SuspendLayout();
            panelControlsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeletedRecords).BeginInit();
            SuspendLayout();
            // 
            // picIconRestoreRecord
            // 
            picIconRestoreRecord.BackColor = Color.FromArgb(16, 185, 129);
            picIconRestoreRecord.Cursor = Cursors.Hand;
            picIconRestoreRecord.Image = Icons.action_restaurar_seleccion;
            picIconRestoreRecord.Location = new Point(801, 20);
            picIconRestoreRecord.Name = "picIconRestoreRecord";
            picIconRestoreRecord.Size = new Size(48, 48);
            picIconRestoreRecord.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRestoreRecord.TabIndex = 99;
            picIconRestoreRecord.TabStop = false;
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
            labelTitle.Size = new Size(467, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "PAPELERA Y RECUPERACIÓN DE REGISTROS";
            // 
            // panelControlsCard
            // 
            panelControlsCard.BackColor = Color.White;
            panelControlsCard.Controls.Add(labelEntityTypePrompt);
            panelControlsCard.Controls.Add(comboBoxEntityType);
            panelControlsCard.Controls.Add(labelSearchPrompt);
            panelControlsCard.Controls.Add(textBoxSearch);
            panelControlsCard.Controls.Add(labelSelectedItemInfo);
            panelControlsCard.Controls.Add(picIconRestoreRecord);
            panelControlsCard.Controls.Add(buttonRestoreRecord);
            panelControlsCard.Location = new Point(16, 72);
            panelControlsCard.Name = "panelControlsCard";
            panelControlsCard.Padding = new Padding(16);
            panelControlsCard.Size = new Size(1118, 105);
            panelControlsCard.TabIndex = 1;
            // 
            // labelEntityTypePrompt
            // 
            labelEntityTypePrompt.AutoSize = true;
            labelEntityTypePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEntityTypePrompt.Location = new Point(16, 12);
            labelEntityTypePrompt.Name = "labelEntityTypePrompt";
            labelEntityTypePrompt.Size = new Size(132, 20);
            labelEntityTypePrompt.TabIndex = 0;
            labelEntityTypePrompt.Text = "Módulo / Padrón:";
            // 
            // comboBoxEntityType
            // 
            comboBoxEntityType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEntityType.Font = new Font("Segoe UI", 10F);
            comboBoxEntityType.Location = new Point(16, 34);
            comboBoxEntityType.Name = "comboBoxEntityType";
            comboBoxEntityType.Size = new Size(220, 31);
            comboBoxEntityType.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(255, 12);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(192, 20);
            labelSearchPrompt.TabIndex = 2;
            labelSearchPrompt.Text = "Buscar registro eliminado:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(255, 35);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Escriba identificador o nombre...";
            textBoxSearch.Size = new Size(480, 30);
            textBoxSearch.TabIndex = 3;
            // 
            // labelSelectedItemInfo
            // 
            labelSelectedItemInfo.AutoEllipsis = true;
            labelSelectedItemInfo.Font = new Font("Segoe UI", 9F);
            labelSelectedItemInfo.ForeColor = Color.FromArgb(100, 116, 139);
            labelSelectedItemInfo.Location = new Point(16, 75);
            labelSelectedItemInfo.Name = "labelSelectedItemInfo";
            labelSelectedItemInfo.Size = new Size(720, 20);
            labelSelectedItemInfo.TabIndex = 4;
            labelSelectedItemInfo.Text = "Seleccione un registro de la grilla para restaurarlo.";
            // 
            // buttonRestoreRecord
            // 
            buttonRestoreRecord.BackColor = Color.FromArgb(16, 185, 129);
            buttonRestoreRecord.Cursor = Cursors.Hand;
            buttonRestoreRecord.Enabled = false;
            buttonRestoreRecord.FlatAppearance.BorderSize = 0;
            buttonRestoreRecord.FlatStyle = FlatStyle.Flat;
            buttonRestoreRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonRestoreRecord.ForeColor = Color.White;
            buttonRestoreRecord.Location = new Point(760, 20);
            buttonRestoreRecord.Name = "buttonRestoreRecord";
            buttonRestoreRecord.Padding = new Padding(30, 0, 0, 0);
            buttonRestoreRecord.Size = new Size(340, 48);
            buttonRestoreRecord.TabIndex = 5;
            buttonRestoreRecord.Text = "RESTAURAR REGISTRO";
            buttonRestoreRecord.UseVisualStyleBackColor = false;
            // 
            // labelRecordCount
            // 
            labelRecordCount.AutoSize = true;
            labelRecordCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRecordCount.ForeColor = Color.FromArgb(100, 116, 139);
            labelRecordCount.Location = new Point(16, 188);
            labelRecordCount.Name = "labelRecordCount";
            labelRecordCount.Size = new Size(191, 21);
            labelRecordCount.TabIndex = 2;
            labelRecordCount.Text = "Registros en Papelera: 0";
            // 
            // dataGridViewDeletedRecords
            // 
            dataGridViewDeletedRecords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDeletedRecords.BackgroundColor = Color.White;
            dataGridViewDeletedRecords.BorderStyle = BorderStyle.None;
            dataGridViewDeletedRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDeletedRecords.Location = new Point(16, 214);
            dataGridViewDeletedRecords.Name = "dataGridViewDeletedRecords";
            dataGridViewDeletedRecords.RowHeadersWidth = 51;
            dataGridViewDeletedRecords.Size = new Size(1118, 450);
            dataGridViewDeletedRecords.TabIndex = 3;
            // 
            // FormRestoreRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1150, 680);
            Controls.Add(dataGridViewDeletedRecords);
            Controls.Add(labelRecordCount);
            Controls.Add(panelControlsCard);
            Controls.Add(panelHeader);
            Name = "FormRestoreRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Papelera de Reciclaje - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconRestoreRecord).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelControlsCard.ResumeLayout(false);
            panelControlsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeletedRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelControlsCard;
        private Label labelEntityTypePrompt;
        private ComboBox comboBoxEntityType;
        private Label labelSearchPrompt;
        private TextBox textBoxSearch;
        private Label labelSelectedItemInfo;
        private Button buttonRestoreRecord;
        private Label labelRecordCount;
        private DataGridView dataGridViewDeletedRecords;
        private PictureBox picIconRestoreRecord;
    }
}