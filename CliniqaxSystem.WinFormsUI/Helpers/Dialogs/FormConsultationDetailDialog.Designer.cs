namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormConsultationDetailDialog
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
            panelHeaderSummaryCard = new Panel();
            labelPatientName = new Label();
            labelPatientDocument = new Label();
            labelProfessionalInfo = new Label();
            labelConsultationDate = new Label();
            labelStatusBadge = new Label();
            panelDetailsContainer = new Panel();
            tabControlDetails = new TabControl();
            tabPageAnamnesis = new TabPage();
            labelReasonTitle = new Label();
            textBoxReason = new TextBox();
            labelPhysicalTitle = new Label();
            textBoxPhysicalExam = new TextBox();
            labelEvolutionTitle = new Label();
            textBoxEvolution = new TextBox();
            tabPageDiagnoses = new TabPage();
            dataGridViewDiagnoses = new DataGridView();
            tabPageTreatment = new TabPage();
            labelInstructionsTitle = new Label();
            textBoxInstructions = new TextBox();
            labelMedicationTitle = new Label();
            textBoxMedication = new TextBox();
            labelFollowUpTitle = new Label();
            textBoxFollowUp = new TextBox();
            panelFooter = new Panel();
            picIconClose = new PictureBox();
            buttonClose = new Button();
            panelHeader.SuspendLayout();
            panelHeaderSummaryCard.SuspendLayout();
            panelDetailsContainer.SuspendLayout();
            tabControlDetails.SuspendLayout();
            tabPageAnamnesis.SuspendLayout();
            tabPageDiagnoses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiagnoses).BeginInit();
            tabPageTreatment.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconClose).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(980, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(316, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "DETALLE DE ATENCIÓN MÉDICA";
            // 
            // panelHeaderSummaryCard
            // 
            panelHeaderSummaryCard.BackColor = Color.White;
            panelHeaderSummaryCard.Controls.Add(labelPatientName);
            panelHeaderSummaryCard.Controls.Add(labelPatientDocument);
            panelHeaderSummaryCard.Controls.Add(labelProfessionalInfo);
            panelHeaderSummaryCard.Controls.Add(labelConsultationDate);
            panelHeaderSummaryCard.Controls.Add(labelStatusBadge);
            panelHeaderSummaryCard.Dock = DockStyle.Top;
            panelHeaderSummaryCard.Location = new Point(0, 50);
            panelHeaderSummaryCard.Name = "panelHeaderSummaryCard";
            panelHeaderSummaryCard.Padding = new Padding(16, 10, 16, 10);
            panelHeaderSummaryCard.Size = new Size(980, 80);
            panelHeaderSummaryCard.TabIndex = 1;
            // 
            // labelPatientName
            // 
            labelPatientName.AutoEllipsis = true;
            labelPatientName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            labelPatientName.Location = new Point(16, 12);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(400, 25);
            labelPatientName.TabIndex = 0;
            labelPatientName.Text = "PACIENTE: CARGANDO...";
            // 
            // labelPatientDocument
            // 
            labelPatientDocument.AutoSize = true;
            labelPatientDocument.Font = new Font("Segoe UI", 9F);
            labelPatientDocument.ForeColor = Color.FromArgb(100, 116, 139);
            labelPatientDocument.Location = new Point(16, 40);
            labelPatientDocument.Name = "labelPatientDocument";
            labelPatientDocument.Size = new Size(52, 20);
            labelPatientDocument.TabIndex = 1;
            labelPatientDocument.Text = "DNI: - ";
            // 
            // labelProfessionalInfo
            // 
            labelProfessionalInfo.AutoEllipsis = true;
            labelProfessionalInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelProfessionalInfo.ForeColor = Color.FromArgb(2, 132, 199);
            labelProfessionalInfo.Location = new Point(430, 12);
            labelProfessionalInfo.Name = "labelProfessionalInfo";
            labelProfessionalInfo.Size = new Size(380, 25);
            labelProfessionalInfo.TabIndex = 2;
            labelProfessionalInfo.Text = "Médico: Cargando...";
            // 
            // labelConsultationDate
            // 
            labelConsultationDate.AutoSize = true;
            labelConsultationDate.Font = new Font("Segoe UI", 9F);
            labelConsultationDate.ForeColor = Color.FromArgb(100, 116, 139);
            labelConsultationDate.Location = new Point(430, 40);
            labelConsultationDate.Name = "labelConsultationDate";
            labelConsultationDate.Size = new Size(130, 20);
            labelConsultationDate.TabIndex = 3;
            labelConsultationDate.Text = "Fecha: 00/00/0000";
            // 
            // labelStatusBadge
            // 
            labelStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelStatusBadge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelStatusBadge.ForeColor = Color.FromArgb(16, 185, 129);
            labelStatusBadge.Location = new Point(820, 25);
            labelStatusBadge.Name = "labelStatusBadge";
            labelStatusBadge.Size = new Size(144, 25);
            labelStatusBadge.TabIndex = 4;
            labelStatusBadge.Text = "[FINALIZADA]";
            labelStatusBadge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelDetailsContainer
            // 
            panelDetailsContainer.Controls.Add(tabControlDetails);
            panelDetailsContainer.Dock = DockStyle.Fill;
            panelDetailsContainer.Location = new Point(0, 130);
            panelDetailsContainer.Name = "panelDetailsContainer";
            panelDetailsContainer.Padding = new Padding(16, 10, 16, 10);
            panelDetailsContainer.Size = new Size(980, 480);
            panelDetailsContainer.TabIndex = 2;
            // 
            // tabControlDetails
            // 
            tabControlDetails.Controls.Add(tabPageAnamnesis);
            tabControlDetails.Controls.Add(tabPageDiagnoses);
            tabControlDetails.Controls.Add(tabPageTreatment);
            tabControlDetails.Dock = DockStyle.Fill;
            tabControlDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabControlDetails.Location = new Point(16, 10);
            tabControlDetails.Name = "tabControlDetails";
            tabControlDetails.SelectedIndex = 0;
            tabControlDetails.Size = new Size(948, 460);
            tabControlDetails.TabIndex = 0;
            // 
            // tabPageAnamnesis
            // 
            tabPageAnamnesis.BackColor = Color.White;
            tabPageAnamnesis.Controls.Add(labelReasonTitle);
            tabPageAnamnesis.Controls.Add(textBoxReason);
            tabPageAnamnesis.Controls.Add(labelPhysicalTitle);
            tabPageAnamnesis.Controls.Add(textBoxPhysicalExam);
            tabPageAnamnesis.Controls.Add(labelEvolutionTitle);
            tabPageAnamnesis.Controls.Add(textBoxEvolution);
            tabPageAnamnesis.Location = new Point(4, 30);
            tabPageAnamnesis.Name = "tabPageAnamnesis";
            tabPageAnamnesis.Padding = new Padding(16);
            tabPageAnamnesis.Size = new Size(940, 426);
            tabPageAnamnesis.TabIndex = 0;
            tabPageAnamnesis.Text = "  Anamnesis y Examen  ";
            // 
            // labelReasonTitle
            // 
            labelReasonTitle.AutoSize = true;
            labelReasonTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelReasonTitle.Location = new Point(16, 12);
            labelReasonTitle.Name = "labelReasonTitle";
            labelReasonTitle.Size = new Size(149, 20);
            labelReasonTitle.TabIndex = 0;
            labelReasonTitle.Text = "Motivo de Consulta:";
            // 
            // textBoxReason
            // 
            textBoxReason.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxReason.BackColor = Color.FromArgb(248, 250, 252);
            textBoxReason.BorderStyle = BorderStyle.FixedSingle;
            textBoxReason.Font = new Font("Segoe UI", 9.5F);
            textBoxReason.Location = new Point(16, 35);
            textBoxReason.Multiline = true;
            textBoxReason.Name = "textBoxReason";
            textBoxReason.ReadOnly = true;
            textBoxReason.Size = new Size(908, 60);
            textBoxReason.TabIndex = 1;
            // 
            // labelPhysicalTitle
            // 
            labelPhysicalTitle.AutoSize = true;
            labelPhysicalTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPhysicalTitle.Location = new Point(16, 105);
            labelPhysicalTitle.Name = "labelPhysicalTitle";
            labelPhysicalTitle.Size = new Size(224, 20);
            labelPhysicalTitle.TabIndex = 2;
            labelPhysicalTitle.Text = "Examen Físico y Signos Vitales:";
            // 
            // textBoxPhysicalExam
            // 
            textBoxPhysicalExam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPhysicalExam.BackColor = Color.FromArgb(248, 250, 252);
            textBoxPhysicalExam.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhysicalExam.Font = new Font("Segoe UI", 9.5F);
            textBoxPhysicalExam.Location = new Point(16, 128);
            textBoxPhysicalExam.Multiline = true;
            textBoxPhysicalExam.Name = "textBoxPhysicalExam";
            textBoxPhysicalExam.ReadOnly = true;
            textBoxPhysicalExam.Size = new Size(908, 90);
            textBoxPhysicalExam.TabIndex = 3;
            // 
            // labelEvolutionTitle
            // 
            labelEvolutionTitle.AutoSize = true;
            labelEvolutionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEvolutionTitle.Location = new Point(16, 230);
            labelEvolutionTitle.Name = "labelEvolutionTitle";
            labelEvolutionTitle.Size = new Size(186, 20);
            labelEvolutionTitle.TabIndex = 4;
            labelEvolutionTitle.Text = "Evolución y Juicio Clínico:";
            // 
            // textBoxEvolution
            // 
            textBoxEvolution.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEvolution.BackColor = Color.FromArgb(248, 250, 252);
            textBoxEvolution.BorderStyle = BorderStyle.FixedSingle;
            textBoxEvolution.Font = new Font("Segoe UI", 9.5F);
            textBoxEvolution.Location = new Point(16, 253);
            textBoxEvolution.Multiline = true;
            textBoxEvolution.Name = "textBoxEvolution";
            textBoxEvolution.ReadOnly = true;
            textBoxEvolution.Size = new Size(908, 150);
            textBoxEvolution.TabIndex = 5;
            // 
            // tabPageDiagnoses
            // 
            tabPageDiagnoses.BackColor = Color.White;
            tabPageDiagnoses.Controls.Add(dataGridViewDiagnoses);
            tabPageDiagnoses.Location = new Point(4, 30);
            tabPageDiagnoses.Name = "tabPageDiagnoses";
            tabPageDiagnoses.Padding = new Padding(16);
            tabPageDiagnoses.Size = new Size(940, 426);
            tabPageDiagnoses.TabIndex = 1;
            tabPageDiagnoses.Text = "  Diagnósticos Registrados  ";
            // 
            // dataGridViewDiagnoses
            // 
            dataGridViewDiagnoses.BackgroundColor = Color.White;
            dataGridViewDiagnoses.BorderStyle = BorderStyle.None;
            dataGridViewDiagnoses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiagnoses.Dock = DockStyle.Fill;
            dataGridViewDiagnoses.Location = new Point(16, 16);
            dataGridViewDiagnoses.Name = "dataGridViewDiagnoses";
            dataGridViewDiagnoses.RowHeadersWidth = 51;
            dataGridViewDiagnoses.Size = new Size(908, 394);
            dataGridViewDiagnoses.TabIndex = 0;
            // 
            // tabPageTreatment
            // 
            tabPageTreatment.BackColor = Color.White;
            tabPageTreatment.Controls.Add(labelInstructionsTitle);
            tabPageTreatment.Controls.Add(textBoxInstructions);
            tabPageTreatment.Controls.Add(labelMedicationTitle);
            tabPageTreatment.Controls.Add(textBoxMedication);
            tabPageTreatment.Controls.Add(labelFollowUpTitle);
            tabPageTreatment.Controls.Add(textBoxFollowUp);
            tabPageTreatment.Location = new Point(4, 30);
            tabPageTreatment.Name = "tabPageTreatment";
            tabPageTreatment.Padding = new Padding(16);
            tabPageTreatment.Size = new Size(940, 426);
            tabPageTreatment.TabIndex = 2;
            tabPageTreatment.Text = "  Indicaciones y Tratamiento  ";
            // 
            // labelInstructionsTitle
            // 
            labelInstructionsTitle.AutoSize = true;
            labelInstructionsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelInstructionsTitle.Location = new Point(16, 12);
            labelInstructionsTitle.Name = "labelInstructionsTitle";
            labelInstructionsTitle.Size = new Size(249, 20);
            labelInstructionsTitle.TabIndex = 0;
            labelInstructionsTitle.Text = "Indicaciones de Cuidado y Reposo:";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInstructions.BackColor = Color.FromArgb(248, 250, 252);
            textBoxInstructions.BorderStyle = BorderStyle.FixedSingle;
            textBoxInstructions.Font = new Font("Segoe UI", 9.5F);
            textBoxInstructions.Location = new Point(16, 35);
            textBoxInstructions.Multiline = true;
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.ReadOnly = true;
            textBoxInstructions.Size = new Size(908, 100);
            textBoxInstructions.TabIndex = 1;
            // 
            // labelMedicationTitle
            // 
            labelMedicationTitle.AutoSize = true;
            labelMedicationTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMedicationTitle.Location = new Point(16, 148);
            labelMedicationTitle.Name = "labelMedicationTitle";
            labelMedicationTitle.Size = new Size(239, 20);
            labelMedicationTitle.TabIndex = 2;
            labelMedicationTitle.Text = "Medicación Indicada y Posología:";
            // 
            // textBoxMedication
            // 
            textBoxMedication.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMedication.BackColor = Color.FromArgb(248, 250, 252);
            textBoxMedication.BorderStyle = BorderStyle.FixedSingle;
            textBoxMedication.Font = new Font("Segoe UI", 9.5F);
            textBoxMedication.Location = new Point(16, 171);
            textBoxMedication.Multiline = true;
            textBoxMedication.Name = "textBoxMedication";
            textBoxMedication.ReadOnly = true;
            textBoxMedication.Size = new Size(908, 110);
            textBoxMedication.TabIndex = 3;
            // 
            // labelFollowUpTitle
            // 
            labelFollowUpTitle.AutoSize = true;
            labelFollowUpTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFollowUpTitle.Location = new Point(16, 295);
            labelFollowUpTitle.Name = "labelFollowUpTitle";
            labelFollowUpTitle.Size = new Size(266, 20);
            labelFollowUpTitle.TabIndex = 4;
            labelFollowUpTitle.Text = "Próximo Control / Pautas de Alarma:";
            // 
            // textBoxFollowUp
            // 
            textBoxFollowUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFollowUp.BackColor = Color.FromArgb(248, 250, 252);
            textBoxFollowUp.BorderStyle = BorderStyle.FixedSingle;
            textBoxFollowUp.Font = new Font("Segoe UI", 9.5F);
            textBoxFollowUp.Location = new Point(16, 318);
            textBoxFollowUp.Multiline = true;
            textBoxFollowUp.Name = "textBoxFollowUp";
            textBoxFollowUp.ReadOnly = true;
            textBoxFollowUp.Size = new Size(908, 85);
            textBoxFollowUp.TabIndex = 5;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(picIconClose);
            panelFooter.Controls.Add(buttonClose);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 610);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(16, 10, 16, 10);
            panelFooter.Size = new Size(980, 65);
            panelFooter.TabIndex = 3;
            // 
            // picIconClose
            // 
            picIconClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIconClose.BackColor = Color.White;
            picIconClose.Cursor = Cursors.Hand;
            picIconClose.Image = Icons.action_cancelar_volver;
            picIconClose.Location = new Point(831, 10);
            picIconClose.Name = "picIconClose";
            picIconClose.Size = new Size(43, 44);
            picIconClose.SizeMode = PictureBoxSizeMode.Zoom;
            picIconClose.TabIndex = 99;
            picIconClose.TabStop = false;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.BackColor = Color.White;
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClose.ForeColor = Color.FromArgb(100, 116, 139);
            buttonClose.Location = new Point(818, 10);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new Padding(24, 0, 0, 0);
            buttonClose.Size = new Size(146, 44);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "CERRAR";
            buttonClose.UseVisualStyleBackColor = false;
            // 
            // FormConsultationDetailDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(980, 675);
            Controls.Add(panelDetailsContainer);
            Controls.Add(panelFooter);
            Controls.Add(panelHeaderSummaryCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConsultationDetailDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Auditoría de Consulta Médica";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelHeaderSummaryCard.ResumeLayout(false);
            panelHeaderSummaryCard.PerformLayout();
            panelDetailsContainer.ResumeLayout(false);
            tabControlDetails.ResumeLayout(false);
            tabPageAnamnesis.ResumeLayout(false);
            tabPageAnamnesis.PerformLayout();
            tabPageDiagnoses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiagnoses).EndInit();
            tabPageTreatment.ResumeLayout(false);
            tabPageTreatment.PerformLayout();
            panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelHeaderSummaryCard;
        private Label labelPatientName;
        private Label labelPatientDocument;
        private Label labelProfessionalInfo;
        private Label labelConsultationDate;
        private Label labelStatusBadge;
        private Panel panelDetailsContainer;
        private TabControl tabControlDetails;
        private TabPage tabPageAnamnesis;
        private Label labelReasonTitle;
        private TextBox textBoxReason;
        private Label labelPhysicalTitle;
        private TextBox textBoxPhysicalExam;
        private Label labelEvolutionTitle;
        private TextBox textBoxEvolution;
        private TabPage tabPageDiagnoses;
        private DataGridView dataGridViewDiagnoses;
        private TabPage tabPageTreatment;
        private Label labelInstructionsTitle;
        private TextBox textBoxInstructions;
        private Label labelMedicationTitle;
        private TextBox textBoxMedication;
        private Label labelFollowUpTitle;
        private TextBox textBoxFollowUp;
        private Panel panelFooter;
        private Button buttonClose;
        private PictureBox picIconClose;
    }
}