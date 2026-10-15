namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormClinicalDocumentHubDialog
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
            panelContainerCard = new Panel();
            labelPatientName = new Label();
            labelRecordNumber = new Label();
            labelSeparator = new Label();
            picIconOfficialPdf = new PictureBox();
            buttonOfficialPdf = new Button();
            picIconUploadTemplate = new PictureBox();
            buttonUploadTemplate = new Button();
            picIconImportExternal = new PictureBox();
            buttonImportExternal = new Button();
            panelHeader.SuspendLayout();
            panelContainerCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconOfficialPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconUploadTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconImportExternal).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(620, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(322, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "GESTIÓN DOCUMENTAL CLÍNICA";
            // 
            // panelContainerCard
            // 
            panelContainerCard.BackColor = Color.White;
            panelContainerCard.Controls.Add(labelPatientName);
            panelContainerCard.Controls.Add(labelRecordNumber);
            panelContainerCard.Controls.Add(labelSeparator);
            panelContainerCard.Controls.Add(picIconOfficialPdf);
            panelContainerCard.Controls.Add(buttonOfficialPdf);
            panelContainerCard.Controls.Add(picIconUploadTemplate);
            panelContainerCard.Controls.Add(buttonUploadTemplate);
            panelContainerCard.Controls.Add(picIconImportExternal);
            panelContainerCard.Controls.Add(buttonImportExternal);
            panelContainerCard.Location = new Point(16, 62);
            panelContainerCard.Name = "panelContainerCard";
            panelContainerCard.Padding = new Padding(20);
            panelContainerCard.Size = new Size(588, 395);
            panelContainerCard.TabIndex = 1;
            // 
            // labelPatientName
            // 
            labelPatientName.AutoEllipsis = true;
            labelPatientName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            labelPatientName.Location = new Point(20, 15);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(548, 25);
            labelPatientName.TabIndex = 0;
            labelPatientName.Text = "PACIENTE: SELECCIONADO";
            // 
            // labelRecordNumber
            // 
            labelRecordNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRecordNumber.ForeColor = Color.FromArgb(2, 132, 199);
            labelRecordNumber.Location = new Point(20, 42);
            labelRecordNumber.Name = "labelRecordNumber";
            labelRecordNumber.Size = new Size(548, 20);
            labelRecordNumber.TabIndex = 1;
            labelRecordNumber.Text = "Expediente N.°: HC-00000000";
            // 
            // labelSeparator
            // 
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator.Location = new Point(20, 70);
            labelSeparator.Name = "labelSeparator";
            labelSeparator.Size = new Size(548, 2);
            labelSeparator.TabIndex = 2;
            // 
            // picIconOfficialPdf
            // 
            picIconOfficialPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconOfficialPdf.Cursor = Cursors.Hand;
            picIconOfficialPdf.Image = Icons.action_exportar_pdf;
            picIconOfficialPdf.Location = new Point(20, 137);
            picIconOfficialPdf.Name = "picIconOfficialPdf";
            picIconOfficialPdf.Size = new Size(36, 50);
            picIconOfficialPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconOfficialPdf.TabIndex = 99;
            picIconOfficialPdf.TabStop = false;
            // 
            // buttonOfficialPdf
            // 
            buttonOfficialPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonOfficialPdf.Cursor = Cursors.Hand;
            buttonOfficialPdf.FlatAppearance.BorderSize = 0;
            buttonOfficialPdf.FlatStyle = FlatStyle.Flat;
            buttonOfficialPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonOfficialPdf.ForeColor = Color.White;
            buttonOfficialPdf.Location = new Point(20, 137);
            buttonOfficialPdf.Name = "buttonOfficialPdf";
            buttonOfficialPdf.Padding = new Padding(30, 0, 0, 0);
            buttonOfficialPdf.Size = new Size(548, 52);
            buttonOfficialPdf.TabIndex = 3;
            buttonOfficialPdf.Text = "1. EMITIR Y ABRIR EL EXPEDIENTE OFICIAL (PDF)";
            buttonOfficialPdf.UseVisualStyleBackColor = false;
            // 
            // picIconUploadTemplate
            // 
            picIconUploadTemplate.BackColor = Color.FromArgb(16, 185, 129);
            picIconUploadTemplate.Cursor = Cursors.Hand;
            picIconUploadTemplate.Image = Icons.action_guardar;
            picIconUploadTemplate.Location = new Point(20, 202);
            picIconUploadTemplate.Name = "picIconUploadTemplate";
            picIconUploadTemplate.Size = new Size(36, 50);
            picIconUploadTemplate.SizeMode = PictureBoxSizeMode.Zoom;
            picIconUploadTemplate.TabIndex = 99;
            picIconUploadTemplate.TabStop = false;
            // 
            // buttonUploadTemplate
            // 
            buttonUploadTemplate.BackColor = Color.FromArgb(16, 185, 129);
            buttonUploadTemplate.Cursor = Cursors.Hand;
            buttonUploadTemplate.FlatAppearance.BorderSize = 0;
            buttonUploadTemplate.FlatStyle = FlatStyle.Flat;
            buttonUploadTemplate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonUploadTemplate.ForeColor = Color.White;
            buttonUploadTemplate.Location = new Point(20, 202);
            buttonUploadTemplate.Name = "buttonUploadTemplate";
            buttonUploadTemplate.Padding = new Padding(30, 0, 0, 0);
            buttonUploadTemplate.Size = new Size(548, 52);
            buttonUploadTemplate.TabIndex = 4;
            buttonUploadTemplate.Text = "2. CARGAR PLANTILLA COMPLETA";
            buttonUploadTemplate.UseVisualStyleBackColor = false;
            // 
            // picIconImportExternal
            // 
            picIconImportExternal.BackColor = Color.FromArgb(245, 158, 11);
            picIconImportExternal.Cursor = Cursors.Hand;
            picIconImportExternal.Image = Icons.action_buscar_filtrar;
            picIconImportExternal.Location = new Point(20, 267);
            picIconImportExternal.Name = "picIconImportExternal";
            picIconImportExternal.Size = new Size(36, 50);
            picIconImportExternal.SizeMode = PictureBoxSizeMode.Zoom;
            picIconImportExternal.TabIndex = 99;
            picIconImportExternal.TabStop = false;
            // 
            // buttonImportExternal
            // 
            buttonImportExternal.BackColor = Color.FromArgb(245, 158, 11);
            buttonImportExternal.Cursor = Cursors.Hand;
            buttonImportExternal.FlatAppearance.BorderSize = 0;
            buttonImportExternal.FlatStyle = FlatStyle.Flat;
            buttonImportExternal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonImportExternal.ForeColor = Color.White;
            buttonImportExternal.Location = new Point(20, 267);
            buttonImportExternal.Name = "buttonImportExternal";
            buttonImportExternal.Padding = new Padding(30, 0, 0, 0);
            buttonImportExternal.Size = new Size(548, 52);
            buttonImportExternal.TabIndex = 5;
            buttonImportExternal.Text = "3. IMPORTAR HISTORIA CLÍNICA DE OTRO SISTEMA EXTERNO";
            buttonImportExternal.UseVisualStyleBackColor = false;
            // 
            // FormClinicalDocumentHubDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(620, 475);
            Controls.Add(panelContainerCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormClinicalDocumentHubDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión Documental Clínica";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContainerCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconOfficialPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconUploadTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconImportExternal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelContainerCard;
        private Label labelPatientName;
        private Label labelRecordNumber;
        private Label labelSeparator;
        private Button buttonOfficialPdf;
        private PictureBox picIconOfficialPdf;
        private Button buttonUploadTemplate;
        private PictureBox picIconUploadTemplate;
        private Button buttonImportExternal;
        private PictureBox picIconImportExternal;
    }
}