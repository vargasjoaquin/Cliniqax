namespace CliniqaxSystem.WinFormsUI
{
    partial class FormMedicalRecord
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
            panelPatientSelectorCard = new Panel();
            labelSelectPatientPrompt = new Label();
            comboBoxPatients = new ComboBox();
            labelPatientNameDisplay = new Label();
            labelPatientDetailsDisplay = new Label();
            picIconDocumentHub = new PictureBox();
            buttonDocumentHub = new Button();
            picIconDownloadBlankTemplate = new PictureBox();
            buttonDownloadBlankTemplate = new Button();
            labelRecordNumberBadge = new Label();
            tabControlRecord = new TabControl();
            tabPageAntecedentes = new TabPage();
            panelAntecedentesCard = new Panel();
            labelBloodType = new Label();
            textBoxBloodType = new TextBox();
            labelAllergies = new Label();
            textBoxAllergies = new TextBox();
            labelPathological = new Label();
            textBoxPathological = new TextBox();
            labelNonPathological = new Label();
            textBoxNonPathological = new TextBox();
            labelSurgical = new Label();
            textBoxSurgical = new TextBox();
            labelFamily = new Label();
            textBoxFamily = new TextBox();
            labelGeneralObs = new Label();
            textBoxGeneralObservations = new TextBox();
            picIconSaveAntecedentes = new PictureBox();
            buttonSaveAntecedentes = new Button();
            tabPageConsultas = new TabPage();
            dataGridViewConsultations = new DataGridView();
            panelConsultasActions = new Panel();
            picIconNewConsultation = new PictureBox();
            buttonNewConsultation = new Button();
            picIconViewConsultation = new PictureBox();
            buttonViewConsultation = new Button();
            tabPageAdjuntos = new TabPage();
            dataGridViewAttachments = new DataGridView();
            panelAdjuntosActions = new Panel();
            picIconUploadAttachment = new PictureBox();
            buttonUploadAttachment = new Button();
            picIconDownloadAttachment = new PictureBox();
            buttonDownloadAttachment = new Button();
            picIconDeleteAttachment = new PictureBox();
            buttonDeleteAttachment = new Button();
            panelHeader.SuspendLayout();
            panelPatientSelectorCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconDocumentHub).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDownloadBlankTemplate).BeginInit();
            tabControlRecord.SuspendLayout();
            tabPageAntecedentes.SuspendLayout();
            panelAntecedentesCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconSaveAntecedentes).BeginInit();
            tabPageConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsultations).BeginInit();
            panelConsultasActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconNewConsultation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconViewConsultation).BeginInit();
            tabPageAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttachments).BeginInit();
            panelAdjuntosActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconUploadAttachment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDownloadAttachment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDeleteAttachment).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1382, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(423, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "EXPEDIENTE E HISTORIA CLÍNICA (HCE)";
            // 
            // panelPatientSelectorCard
            // 
            panelPatientSelectorCard.BackColor = Color.White;
            panelPatientSelectorCard.Controls.Add(labelSelectPatientPrompt);
            panelPatientSelectorCard.Controls.Add(comboBoxPatients);
            panelPatientSelectorCard.Controls.Add(labelPatientNameDisplay);
            panelPatientSelectorCard.Controls.Add(labelPatientDetailsDisplay);
            panelPatientSelectorCard.Controls.Add(picIconDocumentHub);
            panelPatientSelectorCard.Controls.Add(buttonDocumentHub);
            panelPatientSelectorCard.Controls.Add(picIconDownloadBlankTemplate);
            panelPatientSelectorCard.Controls.Add(buttonDownloadBlankTemplate);
            panelPatientSelectorCard.Controls.Add(labelRecordNumberBadge);
            panelPatientSelectorCard.Dock = DockStyle.Top;
            panelPatientSelectorCard.Location = new Point(0, 56);
            panelPatientSelectorCard.Name = "panelPatientSelectorCard";
            panelPatientSelectorCard.Padding = new Padding(16, 10, 16, 10);
            panelPatientSelectorCard.Size = new Size(1382, 80);
            panelPatientSelectorCard.TabIndex = 1;
            // 
            // labelSelectPatientPrompt
            // 
            labelSelectPatientPrompt.AutoSize = true;
            labelSelectPatientPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSelectPatientPrompt.Location = new Point(16, 10);
            labelSelectPatientPrompt.Name = "labelSelectPatientPrompt";
            labelSelectPatientPrompt.Size = new Size(154, 20);
            labelSelectPatientPrompt.TabIndex = 0;
            labelSelectPatientPrompt.Text = "Seleccionar Paciente:";
            // 
            // comboBoxPatients
            // 
            comboBoxPatients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPatients.Font = new Font("Segoe UI", 9.5F);
            comboBoxPatients.Location = new Point(16, 33);
            comboBoxPatients.Name = "comboBoxPatients";
            comboBoxPatients.Size = new Size(300, 29);
            comboBoxPatients.TabIndex = 1;
            // 
            // labelPatientNameDisplay
            // 
            labelPatientNameDisplay.AutoEllipsis = true;
            labelPatientNameDisplay.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelPatientNameDisplay.ForeColor = Color.FromArgb(15, 23, 42);
            labelPatientNameDisplay.Location = new Point(330, 15);
            labelPatientNameDisplay.Name = "labelPatientNameDisplay";
            labelPatientNameDisplay.Size = new Size(320, 26);
            labelPatientNameDisplay.TabIndex = 2;
            labelPatientNameDisplay.Text = "SELECCIONE UN PACIENTE";
            // 
            // labelPatientDetailsDisplay
            // 
            labelPatientDetailsDisplay.AutoEllipsis = true;
            labelPatientDetailsDisplay.Font = new Font("Segoe UI", 8.5F);
            labelPatientDetailsDisplay.ForeColor = Color.FromArgb(100, 116, 139);
            labelPatientDetailsDisplay.Location = new Point(330, 43);
            labelPatientDetailsDisplay.Name = "labelPatientDetailsDisplay";
            labelPatientDetailsDisplay.Size = new Size(320, 22);
            labelPatientDetailsDisplay.TabIndex = 3;
            labelPatientDetailsDisplay.Text = "DNI: -  |  Edad: -  |  Cobertura: -";
            // 
            // picIconDocumentHub
            // 
            picIconDocumentHub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picIconDocumentHub.BackColor = Color.FromArgb(2, 132, 199);
            picIconDocumentHub.Cursor = Cursors.Hand;
            picIconDocumentHub.Image = Icons.action_exportar_pdf;
            picIconDocumentHub.Location = new Point(660, 22);
            picIconDocumentHub.Name = "picIconDocumentHub";
            picIconDocumentHub.Size = new Size(32, 38);
            picIconDocumentHub.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDocumentHub.TabIndex = 99;
            picIconDocumentHub.TabStop = false;
            // 
            // buttonDocumentHub
            // 
            buttonDocumentHub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDocumentHub.BackColor = Color.FromArgb(2, 132, 199);
            buttonDocumentHub.Cursor = Cursors.Hand;
            buttonDocumentHub.FlatAppearance.BorderSize = 0;
            buttonDocumentHub.FlatStyle = FlatStyle.Flat;
            buttonDocumentHub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDocumentHub.ForeColor = Color.White;
            buttonDocumentHub.Location = new Point(660, 20);
            buttonDocumentHub.Name = "buttonDocumentHub";
            buttonDocumentHub.Padding = new Padding(26, 0, 0, 0);
            buttonDocumentHub.Size = new Size(185, 42);
            buttonDocumentHub.TabIndex = 4;
            buttonDocumentHub.Text = "EXPEDIENTE PDF ▾";
            buttonDocumentHub.UseVisualStyleBackColor = false;
            // 
            // picIconDownloadBlankTemplate
            // 
            picIconDownloadBlankTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picIconDownloadBlankTemplate.BackColor = Color.FromArgb(15, 23, 42);
            picIconDownloadBlankTemplate.Cursor = Cursors.Hand;
            picIconDownloadBlankTemplate.Image = Icons.action_guardar;
            picIconDownloadBlankTemplate.Location = new Point(860, 22);
            picIconDownloadBlankTemplate.Name = "picIconDownloadBlankTemplate";
            picIconDownloadBlankTemplate.Size = new Size(32, 38);
            picIconDownloadBlankTemplate.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDownloadBlankTemplate.TabIndex = 99;
            picIconDownloadBlankTemplate.TabStop = false;
            // 
            // buttonDownloadBlankTemplate
            // 
            buttonDownloadBlankTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDownloadBlankTemplate.BackColor = Color.FromArgb(15, 23, 42);
            buttonDownloadBlankTemplate.Cursor = Cursors.Hand;
            buttonDownloadBlankTemplate.FlatAppearance.BorderSize = 0;
            buttonDownloadBlankTemplate.FlatStyle = FlatStyle.Flat;
            buttonDownloadBlankTemplate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDownloadBlankTemplate.ForeColor = Color.White;
            buttonDownloadBlankTemplate.Location = new Point(860, 20);
            buttonDownloadBlankTemplate.Name = "buttonDownloadBlankTemplate";
            buttonDownloadBlankTemplate.Padding = new Padding(26, 0, 0, 0);
            buttonDownloadBlankTemplate.Size = new Size(195, 42);
            buttonDownloadBlankTemplate.TabIndex = 5;
            buttonDownloadBlankTemplate.Text = "PLANTILLA VACÍA";
            buttonDownloadBlankTemplate.UseVisualStyleBackColor = false;
            // 
            // labelRecordNumberBadge
            // 
            labelRecordNumberBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelRecordNumberBadge.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelRecordNumberBadge.ForeColor = Color.FromArgb(2, 132, 199);
            labelRecordNumberBadge.Location = new Point(1160, 25);
            labelRecordNumberBadge.Name = "labelRecordNumberBadge";
            labelRecordNumberBadge.Size = new Size(210, 28);
            labelRecordNumberBadge.TabIndex = 6;
            labelRecordNumberBadge.Text = "[HC-00000000]";
            labelRecordNumberBadge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabControlRecord
            // 
            tabControlRecord.Controls.Add(tabPageAntecedentes);
            tabControlRecord.Controls.Add(tabPageConsultas);
            tabControlRecord.Controls.Add(tabPageAdjuntos);
            tabControlRecord.Dock = DockStyle.Fill;
            tabControlRecord.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabControlRecord.Location = new Point(0, 136);
            tabControlRecord.Name = "tabControlRecord";
            tabControlRecord.SelectedIndex = 0;
            tabControlRecord.Size = new Size(1382, 664);
            tabControlRecord.TabIndex = 2;
            // 
            // tabPageAntecedentes
            // 
            tabPageAntecedentes.BackColor = Color.FromArgb(248, 250, 252);
            tabPageAntecedentes.Controls.Add(panelAntecedentesCard);
            tabPageAntecedentes.Location = new Point(4, 30);
            tabPageAntecedentes.Name = "tabPageAntecedentes";
            tabPageAntecedentes.Padding = new Padding(16);
            tabPageAntecedentes.Size = new Size(1374, 630);
            tabPageAntecedentes.TabIndex = 0;
            tabPageAntecedentes.Text = "  Antecedentes Clínicos  ";
            // 
            // panelAntecedentesCard
            // 
            panelAntecedentesCard.BackColor = Color.White;
            panelAntecedentesCard.Controls.Add(labelBloodType);
            panelAntecedentesCard.Controls.Add(textBoxBloodType);
            panelAntecedentesCard.Controls.Add(labelAllergies);
            panelAntecedentesCard.Controls.Add(textBoxAllergies);
            panelAntecedentesCard.Controls.Add(labelPathological);
            panelAntecedentesCard.Controls.Add(textBoxPathological);
            panelAntecedentesCard.Controls.Add(labelNonPathological);
            panelAntecedentesCard.Controls.Add(textBoxNonPathological);
            panelAntecedentesCard.Controls.Add(labelSurgical);
            panelAntecedentesCard.Controls.Add(textBoxSurgical);
            panelAntecedentesCard.Controls.Add(labelFamily);
            panelAntecedentesCard.Controls.Add(textBoxFamily);
            panelAntecedentesCard.Controls.Add(labelGeneralObs);
            panelAntecedentesCard.Controls.Add(textBoxGeneralObservations);
            panelAntecedentesCard.Controls.Add(picIconSaveAntecedentes);
            panelAntecedentesCard.Controls.Add(buttonSaveAntecedentes);
            panelAntecedentesCard.Dock = DockStyle.Fill;
            panelAntecedentesCard.Location = new Point(16, 16);
            panelAntecedentesCard.Name = "panelAntecedentesCard";
            panelAntecedentesCard.Padding = new Padding(20);
            panelAntecedentesCard.Size = new Size(1342, 598);
            panelAntecedentesCard.TabIndex = 0;
            // 
            // labelBloodType
            // 
            labelBloodType.AutoSize = true;
            labelBloodType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBloodType.Location = new Point(20, 15);
            labelBloodType.Name = "labelBloodType";
            labelBloodType.Size = new Size(134, 20);
            labelBloodType.TabIndex = 0;
            labelBloodType.Text = "Grupo Sanguíneo:";
            // 
            // textBoxBloodType
            // 
            textBoxBloodType.BorderStyle = BorderStyle.FixedSingle;
            textBoxBloodType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBoxBloodType.Location = new Point(20, 38);
            textBoxBloodType.MaxLength = 10;
            textBoxBloodType.Name = "textBoxBloodType";
            textBoxBloodType.PlaceholderText = "Ej: 0+, A-";
            textBoxBloodType.Size = new Size(150, 30);
            textBoxBloodType.TabIndex = 1;
            // 
            // labelAllergies
            // 
            labelAllergies.AutoSize = true;
            labelAllergies.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAllergies.ForeColor = Color.FromArgb(239, 68, 68);
            labelAllergies.Location = new Point(190, 15);
            labelAllergies.Name = "labelAllergies";
            labelAllergies.Size = new Size(145, 20);
            labelAllergies.TabIndex = 2;
            labelAllergies.Text = "Alergias Conocidas:";
            // 
            // textBoxAllergies
            // 
            textBoxAllergies.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAllergies.BorderStyle = BorderStyle.FixedSingle;
            textBoxAllergies.Font = new Font("Segoe UI", 10F);
            textBoxAllergies.Location = new Point(190, 38);
            textBoxAllergies.Name = "textBoxAllergies";
            textBoxAllergies.PlaceholderText = "Medicamentosas, alimentarias, ambientales...";
            textBoxAllergies.Size = new Size(1132, 30);
            textBoxAllergies.TabIndex = 3;
            // 
            // labelPathological
            // 
            labelPathological.AutoSize = true;
            labelPathological.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPathological.Location = new Point(20, 80);
            labelPathological.Name = "labelPathological";
            labelPathological.Size = new Size(310, 20);
            labelPathological.TabIndex = 4;
            labelPathological.Text = "Antecedentes Patológicos (Enfermedades):";
            // 
            // textBoxPathological
            // 
            textBoxPathological.BorderStyle = BorderStyle.FixedSingle;
            textBoxPathological.Font = new Font("Segoe UI", 9.5F);
            textBoxPathological.Location = new Point(20, 103);
            textBoxPathological.Multiline = true;
            textBoxPathological.Name = "textBoxPathological";
            textBoxPathological.Size = new Size(600, 75);
            textBoxPathological.TabIndex = 5;
            // 
            // labelNonPathological
            // 
            labelNonPathological.AutoSize = true;
            labelNonPathological.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNonPathological.Location = new Point(640, 80);
            labelNonPathological.Name = "labelNonPathological";
            labelNonPathological.Size = new Size(289, 20);
            labelNonPathological.TabIndex = 6;
            labelNonPathological.Text = "Antecedentes No Patológicos (Hábitos):";
            // 
            // textBoxNonPathological
            // 
            textBoxNonPathological.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNonPathological.BorderStyle = BorderStyle.FixedSingle;
            textBoxNonPathological.Font = new Font("Segoe UI", 9.5F);
            textBoxNonPathological.Location = new Point(640, 103);
            textBoxNonPathological.Multiline = true;
            textBoxNonPathological.Name = "textBoxNonPathological";
            textBoxNonPathological.Size = new Size(682, 75);
            textBoxNonPathological.TabIndex = 7;
            // 
            // labelSurgical
            // 
            labelSurgical.AutoSize = true;
            labelSurgical.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSurgical.Location = new Point(20, 190);
            labelSurgical.Name = "labelSurgical";
            labelSurgical.Size = new Size(266, 20);
            labelSurgical.TabIndex = 8;
            labelSurgical.Text = "Antecedentes Quirúrgicos (Cirugías):";
            // 
            // textBoxSurgical
            // 
            textBoxSurgical.BorderStyle = BorderStyle.FixedSingle;
            textBoxSurgical.Font = new Font("Segoe UI", 9.5F);
            textBoxSurgical.Location = new Point(20, 213);
            textBoxSurgical.Multiline = true;
            textBoxSurgical.Name = "textBoxSurgical";
            textBoxSurgical.Size = new Size(600, 75);
            textBoxSurgical.TabIndex = 9;
            // 
            // labelFamily
            // 
            labelFamily.AutoSize = true;
            labelFamily.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFamily.Location = new Point(640, 190);
            labelFamily.Name = "labelFamily";
            labelFamily.Size = new Size(241, 20);
            labelFamily.TabIndex = 10;
            labelFamily.Text = "Antecedentes Heredo-Familiares:";
            // 
            // textBoxFamily
            // 
            textBoxFamily.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFamily.BorderStyle = BorderStyle.FixedSingle;
            textBoxFamily.Font = new Font("Segoe UI", 9.5F);
            textBoxFamily.Location = new Point(640, 213);
            textBoxFamily.Multiline = true;
            textBoxFamily.Name = "textBoxFamily";
            textBoxFamily.Size = new Size(682, 75);
            textBoxFamily.TabIndex = 11;
            // 
            // labelGeneralObs
            // 
            labelGeneralObs.AutoSize = true;
            labelGeneralObs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelGeneralObs.Location = new Point(20, 300);
            labelGeneralObs.Name = "labelGeneralObs";
            labelGeneralObs.Size = new Size(244, 20);
            labelGeneralObs.TabIndex = 12;
            labelGeneralObs.Text = "Observaciones Clínicas Generales:";
            // 
            // textBoxGeneralObservations
            // 
            textBoxGeneralObservations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxGeneralObservations.BorderStyle = BorderStyle.FixedSingle;
            textBoxGeneralObservations.Font = new Font("Segoe UI", 9.5F);
            textBoxGeneralObservations.Location = new Point(20, 323);
            textBoxGeneralObservations.Multiline = true;
            textBoxGeneralObservations.Name = "textBoxGeneralObservations";
            textBoxGeneralObservations.Size = new Size(1302, 180);
            textBoxGeneralObservations.TabIndex = 13;
            // 
            // picIconSaveAntecedentes
            // 
            picIconSaveAntecedentes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIconSaveAntecedentes.BackColor = Color.FromArgb(16, 185, 129);
            picIconSaveAntecedentes.Cursor = Cursors.Hand;
            picIconSaveAntecedentes.Image = Icons.action_guardar;
            picIconSaveAntecedentes.Location = new Point(1022, 525);
            picIconSaveAntecedentes.Name = "picIconSaveAntecedentes";
            picIconSaveAntecedentes.Size = new Size(48, 48);
            picIconSaveAntecedentes.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveAntecedentes.TabIndex = 99;
            picIconSaveAntecedentes.TabStop = false;
            // 
            // buttonSaveAntecedentes
            // 
            buttonSaveAntecedentes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveAntecedentes.BackColor = Color.FromArgb(16, 185, 129);
            buttonSaveAntecedentes.Cursor = Cursors.Hand;
            buttonSaveAntecedentes.FlatAppearance.BorderSize = 0;
            buttonSaveAntecedentes.FlatStyle = FlatStyle.Flat;
            buttonSaveAntecedentes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSaveAntecedentes.ForeColor = Color.White;
            buttonSaveAntecedentes.Location = new Point(1022, 525);
            buttonSaveAntecedentes.Name = "buttonSaveAntecedentes";
            buttonSaveAntecedentes.Padding = new Padding(28, 0, 0, 0);
            buttonSaveAntecedentes.Size = new Size(300, 48);
            buttonSaveAntecedentes.TabIndex = 14;
            buttonSaveAntecedentes.Text = "GUARDAR ANTECEDENTES";
            buttonSaveAntecedentes.UseVisualStyleBackColor = false;
            // 
            // tabPageConsultas
            // 
            tabPageConsultas.BackColor = Color.FromArgb(248, 250, 252);
            tabPageConsultas.Controls.Add(dataGridViewConsultations);
            tabPageConsultas.Controls.Add(panelConsultasActions);
            tabPageConsultas.Location = new Point(4, 30);
            tabPageConsultas.Name = "tabPageConsultas";
            tabPageConsultas.Padding = new Padding(16);
            tabPageConsultas.Size = new Size(1292, 630);
            tabPageConsultas.TabIndex = 1;
            tabPageConsultas.Text = "  Historial de Consultas Médicas  ";
            // 
            // dataGridViewConsultations
            // 
            dataGridViewConsultations.BackgroundColor = Color.White;
            dataGridViewConsultations.BorderStyle = BorderStyle.None;
            dataGridViewConsultations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConsultations.Dock = DockStyle.Fill;
            dataGridViewConsultations.Location = new Point(16, 76);
            dataGridViewConsultations.Name = "dataGridViewConsultations";
            dataGridViewConsultations.RowHeadersWidth = 51;
            dataGridViewConsultations.Size = new Size(1260, 538);
            dataGridViewConsultations.TabIndex = 1;
            // 
            // panelConsultasActions
            // 
            panelConsultasActions.BackColor = Color.White;
            panelConsultasActions.Controls.Add(picIconNewConsultation);
            panelConsultasActions.Controls.Add(buttonNewConsultation);
            panelConsultasActions.Controls.Add(picIconViewConsultation);
            panelConsultasActions.Controls.Add(buttonViewConsultation);
            panelConsultasActions.Dock = DockStyle.Top;
            panelConsultasActions.Location = new Point(16, 16);
            panelConsultasActions.Name = "panelConsultasActions";
            panelConsultasActions.Padding = new Padding(8);
            panelConsultasActions.Size = new Size(1260, 60);
            panelConsultasActions.TabIndex = 0;
            // 
            // picIconNewConsultation
            // 
            picIconNewConsultation.BackColor = Color.FromArgb(16, 185, 129);
            picIconNewConsultation.Cursor = Cursors.Hand;
            picIconNewConsultation.Image = Icons.action_guardar;
            picIconNewConsultation.Location = new Point(12, 10);
            picIconNewConsultation.Name = "picIconNewConsultation";
            picIconNewConsultation.Size = new Size(32, 40);
            picIconNewConsultation.SizeMode = PictureBoxSizeMode.Zoom;
            picIconNewConsultation.TabIndex = 99;
            picIconNewConsultation.TabStop = false;
            // 
            // buttonNewConsultation
            // 
            buttonNewConsultation.BackColor = Color.FromArgb(16, 185, 129);
            buttonNewConsultation.Cursor = Cursors.Hand;
            buttonNewConsultation.FlatAppearance.BorderSize = 0;
            buttonNewConsultation.FlatStyle = FlatStyle.Flat;
            buttonNewConsultation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonNewConsultation.ForeColor = Color.White;
            buttonNewConsultation.Location = new Point(12, 10);
            buttonNewConsultation.Name = "buttonNewConsultation";
            buttonNewConsultation.Padding = new Padding(24, 0, 0, 0);
            buttonNewConsultation.Size = new Size(220, 40);
            buttonNewConsultation.TabIndex = 0;
            buttonNewConsultation.Text = "NUEVA CONSULTA";
            buttonNewConsultation.UseVisualStyleBackColor = false;
            // 
            // picIconViewConsultation
            // 
            picIconViewConsultation.BackColor = Color.FromArgb(2, 132, 199);
            picIconViewConsultation.Cursor = Cursors.Hand;
            picIconViewConsultation.Image = Icons.action_buscar_filtrar;
            picIconViewConsultation.Location = new Point(245, 10);
            picIconViewConsultation.Name = "picIconViewConsultation";
            picIconViewConsultation.Size = new Size(32, 40);
            picIconViewConsultation.SizeMode = PictureBoxSizeMode.Zoom;
            picIconViewConsultation.TabIndex = 99;
            picIconViewConsultation.TabStop = false;
            // 
            // buttonViewConsultation
            // 
            buttonViewConsultation.BackColor = Color.FromArgb(2, 132, 199);
            buttonViewConsultation.Cursor = Cursors.Hand;
            buttonViewConsultation.FlatAppearance.BorderSize = 0;
            buttonViewConsultation.FlatStyle = FlatStyle.Flat;
            buttonViewConsultation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonViewConsultation.ForeColor = Color.White;
            buttonViewConsultation.Location = new Point(245, 10);
            buttonViewConsultation.Name = "buttonViewConsultation";
            buttonViewConsultation.Padding = new Padding(24, 0, 0, 0);
            buttonViewConsultation.Size = new Size(210, 40);
            buttonViewConsultation.TabIndex = 1;
            buttonViewConsultation.Text = "VER DETALLE";
            buttonViewConsultation.UseVisualStyleBackColor = false;
            // 
            // tabPageAdjuntos
            // 
            tabPageAdjuntos.BackColor = Color.FromArgb(248, 250, 252);
            tabPageAdjuntos.Controls.Add(dataGridViewAttachments);
            tabPageAdjuntos.Controls.Add(panelAdjuntosActions);
            tabPageAdjuntos.Location = new Point(4, 30);
            tabPageAdjuntos.Name = "tabPageAdjuntos";
            tabPageAdjuntos.Padding = new Padding(16);
            tabPageAdjuntos.Size = new Size(1292, 630);
            tabPageAdjuntos.TabIndex = 2;
            tabPageAdjuntos.Text = "  Estudios y Archivos Adjuntos  ";
            // 
            // dataGridViewAttachments
            // 
            dataGridViewAttachments.BackgroundColor = Color.White;
            dataGridViewAttachments.BorderStyle = BorderStyle.None;
            dataGridViewAttachments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAttachments.Dock = DockStyle.Fill;
            dataGridViewAttachments.Location = new Point(16, 76);
            dataGridViewAttachments.Name = "dataGridViewAttachments";
            dataGridViewAttachments.RowHeadersWidth = 51;
            dataGridViewAttachments.Size = new Size(1260, 538);
            dataGridViewAttachments.TabIndex = 1;
            // 
            // panelAdjuntosActions
            // 
            panelAdjuntosActions.BackColor = Color.White;
            panelAdjuntosActions.Controls.Add(picIconUploadAttachment);
            panelAdjuntosActions.Controls.Add(buttonUploadAttachment);
            panelAdjuntosActions.Controls.Add(picIconDownloadAttachment);
            panelAdjuntosActions.Controls.Add(buttonDownloadAttachment);
            panelAdjuntosActions.Controls.Add(picIconDeleteAttachment);
            panelAdjuntosActions.Controls.Add(buttonDeleteAttachment);
            panelAdjuntosActions.Dock = DockStyle.Top;
            panelAdjuntosActions.Location = new Point(16, 16);
            panelAdjuntosActions.Name = "panelAdjuntosActions";
            panelAdjuntosActions.Padding = new Padding(8);
            panelAdjuntosActions.Size = new Size(1260, 60);
            panelAdjuntosActions.TabIndex = 0;
            // 
            // picIconUploadAttachment
            // 
            picIconUploadAttachment.BackColor = Color.FromArgb(16, 185, 129);
            picIconUploadAttachment.Cursor = Cursors.Hand;
            picIconUploadAttachment.Image = Icons.action_guardar;
            picIconUploadAttachment.Location = new Point(12, 10);
            picIconUploadAttachment.Name = "picIconUploadAttachment";
            picIconUploadAttachment.Size = new Size(32, 40);
            picIconUploadAttachment.SizeMode = PictureBoxSizeMode.Zoom;
            picIconUploadAttachment.TabIndex = 99;
            picIconUploadAttachment.TabStop = false;
            // 
            // buttonUploadAttachment
            // 
            buttonUploadAttachment.BackColor = Color.FromArgb(16, 185, 129);
            buttonUploadAttachment.Cursor = Cursors.Hand;
            buttonUploadAttachment.FlatAppearance.BorderSize = 0;
            buttonUploadAttachment.FlatStyle = FlatStyle.Flat;
            buttonUploadAttachment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonUploadAttachment.ForeColor = Color.White;
            buttonUploadAttachment.Location = new Point(12, 10);
            buttonUploadAttachment.Name = "buttonUploadAttachment";
            buttonUploadAttachment.Padding = new Padding(24, 0, 0, 0);
            buttonUploadAttachment.Size = new Size(210, 40);
            buttonUploadAttachment.TabIndex = 0;
            buttonUploadAttachment.Text = "ADJUNTAR ESTUDIO";
            buttonUploadAttachment.UseVisualStyleBackColor = false;
            // 
            // picIconDownloadAttachment
            // 
            picIconDownloadAttachment.BackColor = Color.FromArgb(2, 132, 199);
            picIconDownloadAttachment.Cursor = Cursors.Hand;
            picIconDownloadAttachment.Image = Icons.action_imprimir_recibo;
            picIconDownloadAttachment.Location = new Point(235, 10);
            picIconDownloadAttachment.Name = "picIconDownloadAttachment";
            picIconDownloadAttachment.Size = new Size(32, 40);
            picIconDownloadAttachment.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDownloadAttachment.TabIndex = 99;
            picIconDownloadAttachment.TabStop = false;
            // 
            // buttonDownloadAttachment
            // 
            buttonDownloadAttachment.BackColor = Color.FromArgb(2, 132, 199);
            buttonDownloadAttachment.Cursor = Cursors.Hand;
            buttonDownloadAttachment.FlatAppearance.BorderSize = 0;
            buttonDownloadAttachment.FlatStyle = FlatStyle.Flat;
            buttonDownloadAttachment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDownloadAttachment.ForeColor = Color.White;
            buttonDownloadAttachment.Location = new Point(235, 10);
            buttonDownloadAttachment.Name = "buttonDownloadAttachment";
            buttonDownloadAttachment.Padding = new Padding(24, 0, 0, 0);
            buttonDownloadAttachment.Size = new Size(210, 40);
            buttonDownloadAttachment.TabIndex = 1;
            buttonDownloadAttachment.Text = "DESCARGAR / ABRIR";
            buttonDownloadAttachment.UseVisualStyleBackColor = false;
            // 
            // picIconDeleteAttachment
            // 
            picIconDeleteAttachment.BackColor = Color.FromArgb(239, 68, 68);
            picIconDeleteAttachment.Cursor = Cursors.Hand;
            picIconDeleteAttachment.Image = Icons.action_eliminar;
            picIconDeleteAttachment.Location = new Point(460, 10);
            picIconDeleteAttachment.Name = "picIconDeleteAttachment";
            picIconDeleteAttachment.Size = new Size(32, 40);
            picIconDeleteAttachment.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDeleteAttachment.TabIndex = 99;
            picIconDeleteAttachment.TabStop = false;
            // 
            // buttonDeleteAttachment
            // 
            buttonDeleteAttachment.BackColor = Color.FromArgb(239, 68, 68);
            buttonDeleteAttachment.Cursor = Cursors.Hand;
            buttonDeleteAttachment.FlatAppearance.BorderSize = 0;
            buttonDeleteAttachment.FlatStyle = FlatStyle.Flat;
            buttonDeleteAttachment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDeleteAttachment.ForeColor = Color.White;
            buttonDeleteAttachment.Location = new Point(460, 10);
            buttonDeleteAttachment.Name = "buttonDeleteAttachment";
            buttonDeleteAttachment.Padding = new Padding(24, 0, 0, 0);
            buttonDeleteAttachment.Size = new Size(160, 40);
            buttonDeleteAttachment.TabIndex = 2;
            buttonDeleteAttachment.Text = "ELIMINAR";
            buttonDeleteAttachment.UseVisualStyleBackColor = false;
            // 
            // FormMedicalRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1382, 800);
            Controls.Add(tabControlRecord);
            Controls.Add(panelPatientSelectorCard);
            Controls.Add(panelHeader);
            Name = "FormMedicalRecord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historia Clínica Electrónica - Cliniqax";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPatientSelectorCard.ResumeLayout(false);
            panelPatientSelectorCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconDocumentHub).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDownloadBlankTemplate).EndInit();
            tabControlRecord.ResumeLayout(false);
            tabPageAntecedentes.ResumeLayout(false);
            panelAntecedentesCard.ResumeLayout(false);
            panelAntecedentesCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconSaveAntecedentes).EndInit();
            tabPageConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewConsultations).EndInit();
            panelConsultasActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconNewConsultation).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconViewConsultation).EndInit();
            tabPageAdjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAttachments).EndInit();
            panelAdjuntosActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconUploadAttachment).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDownloadAttachment).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDeleteAttachment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelPatientSelectorCard;
        private Label labelSelectPatientPrompt;
        private ComboBox comboBoxPatients;
        private Label labelPatientNameDisplay;
        private Label labelPatientDetailsDisplay;
        private Button buttonDocumentHub;
        private PictureBox picIconDocumentHub;
        private Button buttonDownloadBlankTemplate;
        private PictureBox picIconDownloadBlankTemplate;
        private Label labelRecordNumberBadge;
        private TabControl tabControlRecord;
        private TabPage tabPageAntecedentes;
        private Panel panelAntecedentesCard;
        private Label labelBloodType;
        private TextBox textBoxBloodType;
        private Label labelAllergies;
        private TextBox textBoxAllergies;
        private Label labelPathological;
        private TextBox textBoxPathological;
        private Label labelNonPathological;
        private TextBox textBoxNonPathological;
        private Label labelSurgical;
        private TextBox textBoxSurgical;
        private Label labelFamily;
        private TextBox textBoxFamily;
        private Label labelGeneralObs;
        private TextBox textBoxGeneralObservations;
        private Button buttonSaveAntecedentes;
        private PictureBox picIconSaveAntecedentes;
        private TabPage tabPageConsultas;
        private DataGridView dataGridViewConsultations;
        private Panel panelConsultasActions;
        private Button buttonNewConsultation;
        private PictureBox picIconNewConsultation;
        private Button buttonViewConsultation;
        private PictureBox picIconViewConsultation;
        private TabPage tabPageAdjuntos;
        private DataGridView dataGridViewAttachments;
        private Panel panelAdjuntosActions;
        private Button buttonUploadAttachment;
        private PictureBox picIconUploadAttachment;
        private Button buttonDownloadAttachment;
        private PictureBox picIconDownloadAttachment;
        private Button buttonDeleteAttachment;
        private PictureBox picIconDeleteAttachment;
    }
}