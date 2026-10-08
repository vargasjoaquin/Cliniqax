namespace CliniqaxSystem.WinFormsUI
{
    partial class FormConsultationEntry
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
            panelPatientSummaryCard = new Panel();
            labelPatientName = new Label();
            labelPatientInfo = new Label();
            labelProfPrompt = new Label();
            comboBoxProfessionals = new ComboBox();
            labelSpecPrompt = new Label();
            comboBoxSpecialties = new ComboBox();
            labelDatePrompt = new Label();
            dateTimePickerDate = new DateTimePicker();
            panelFormContainer = new Panel();
            tabControlConsultation = new TabControl();
            tabPageAnamnesis = new TabPage();
            labelReasonPrompt = new Label();
            textBoxReasonForConsultation = new TextBox();
            labelPhysicalPrompt = new Label();
            textBoxPhysicalExamination = new TextBox();
            labelEvolutionPrompt = new Label();
            textBoxEvolutionNotes = new TextBox();
            tabPageDiagnosticos = new TabPage();
            labelDiagTypePrompt = new Label();
            comboBoxDiagnosisType = new ComboBox();
            labelDiagDescPrompt = new Label();
            textBoxDiagnosisDescription = new TextBox();
            labelCie10Prompt = new Label();
            textBoxCie10 = new TextBox();
            labelDiagNotesPrompt = new Label();
            textBoxDiagnosisNotes = new TextBox();
            buttonAddDiagnosis = new Button();
            buttonRemoveDiagnosis = new Button();
            dataGridViewDiagnoses = new DataGridView();
            tabPageIndicaciones = new TabPage();
            labelInstructionsPrompt = new Label();
            textBoxInstructions = new TextBox();
            labelMedicationPrompt = new Label();
            textBoxMedicationDetails = new TextBox();
            labelFollowUpPrompt = new Label();
            textBoxFollowUpNotes = new TextBox();
            labelPrivateNotesPrompt = new Label();
            textBoxPrivateNotes = new TextBox();
            panelFooterActions = new Panel();
            picIconSave = new PictureBox();
            buttonSaveConsultation = new Button();
            picIconCancel = new PictureBox();
            buttonCancel = new Button();
            panelHeader.SuspendLayout();
            panelPatientSummaryCard.SuspendLayout();
            panelFormContainer.SuspendLayout();
            tabControlConsultation.SuspendLayout();
            tabPageAnamnesis.SuspendLayout();
            tabPageDiagnosticos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiagnoses).BeginInit();
            tabPageIndicaciones.SuspendLayout();
            panelFooterActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 15);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(361, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "REGISTRO DE CONSULTA MÉDICA";
            // 
            // panelPatientSummaryCard
            // 
            panelPatientSummaryCard.BackColor = Color.White;
            panelPatientSummaryCard.Controls.Add(labelPatientName);
            panelPatientSummaryCard.Controls.Add(labelPatientInfo);
            panelPatientSummaryCard.Controls.Add(labelProfPrompt);
            panelPatientSummaryCard.Controls.Add(comboBoxProfessionals);
            panelPatientSummaryCard.Controls.Add(labelSpecPrompt);
            panelPatientSummaryCard.Controls.Add(comboBoxSpecialties);
            panelPatientSummaryCard.Controls.Add(labelDatePrompt);
            panelPatientSummaryCard.Controls.Add(dateTimePickerDate);
            panelPatientSummaryCard.Dock = DockStyle.Top;
            panelPatientSummaryCard.Location = new Point(0, 56);
            panelPatientSummaryCard.Name = "panelPatientSummaryCard";
            panelPatientSummaryCard.Padding = new Padding(16, 10, 16, 10);
            panelPatientSummaryCard.Size = new Size(1100, 85);
            panelPatientSummaryCard.TabIndex = 1;
            // 
            // labelPatientName
            // 
            labelPatientName.AutoEllipsis = true;
            labelPatientName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            labelPatientName.Location = new Point(16, 12);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(420, 28);
            labelPatientName.TabIndex = 0;
            labelPatientName.Text = "PACIENTE: CARGANDO...";
            // 
            // labelPatientInfo
            // 
            labelPatientInfo.AutoEllipsis = true;
            labelPatientInfo.Font = new Font("Segoe UI", 9F);
            labelPatientInfo.ForeColor = Color.FromArgb(100, 116, 139);
            labelPatientInfo.Location = new Point(16, 42);
            labelPatientInfo.Name = "labelPatientInfo";
            labelPatientInfo.Size = new Size(420, 22);
            labelPatientInfo.TabIndex = 1;
            labelPatientInfo.Text = "DNI: -  |  Edad: -  |  Cobertura: -";
            // 
            // labelProfPrompt
            // 
            labelProfPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelProfPrompt.AutoSize = true;
            labelProfPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelProfPrompt.Location = new Point(455, 12);
            labelProfPrompt.Name = "labelProfPrompt";
            labelProfPrompt.Size = new Size(64, 20);
            labelProfPrompt.TabIndex = 2;
            labelProfPrompt.Text = "Médico:";
            // 
            // comboBoxProfessionals
            // 
            comboBoxProfessionals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxProfessionals.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfessionals.Font = new Font("Segoe UI", 9.5F);
            comboBoxProfessionals.Location = new Point(455, 35);
            comboBoxProfessionals.Name = "comboBoxProfessionals";
            comboBoxProfessionals.Size = new Size(240, 29);
            comboBoxProfessionals.TabIndex = 3;
            // 
            // labelSpecPrompt
            // 
            labelSpecPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelSpecPrompt.AutoSize = true;
            labelSpecPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSpecPrompt.Location = new Point(710, 12);
            labelSpecPrompt.Name = "labelSpecPrompt";
            labelSpecPrompt.Size = new Size(98, 20);
            labelSpecPrompt.TabIndex = 4;
            labelSpecPrompt.Text = "Especialidad:";
            // 
            // comboBoxSpecialties
            // 
            comboBoxSpecialties.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxSpecialties.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialties.Font = new Font("Segoe UI", 9.5F);
            comboBoxSpecialties.Location = new Point(710, 35);
            comboBoxSpecialties.Name = "comboBoxSpecialties";
            comboBoxSpecialties.Size = new Size(220, 29);
            comboBoxSpecialties.TabIndex = 5;
            // 
            // labelDatePrompt
            // 
            labelDatePrompt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDatePrompt.AutoSize = true;
            labelDatePrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDatePrompt.Location = new Point(945, 12);
            labelDatePrompt.Name = "labelDatePrompt";
            labelDatePrompt.Size = new Size(53, 20);
            labelDatePrompt.TabIndex = 6;
            labelDatePrompt.Text = "Fecha:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePickerDate.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(945, 35);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(135, 29);
            dateTimePickerDate.TabIndex = 7;
            // 
            // panelFormContainer
            // 
            panelFormContainer.Controls.Add(tabControlConsultation);
            panelFormContainer.Dock = DockStyle.Fill;
            panelFormContainer.Location = new Point(0, 141);
            panelFormContainer.Name = "panelFormContainer";
            panelFormContainer.Padding = new Padding(16, 12, 16, 12);
            panelFormContainer.Size = new Size(1100, 529);
            panelFormContainer.TabIndex = 2;
            // 
            // tabControlConsultation
            // 
            tabControlConsultation.Controls.Add(tabPageAnamnesis);
            tabControlConsultation.Controls.Add(tabPageDiagnosticos);
            tabControlConsultation.Controls.Add(tabPageIndicaciones);
            tabControlConsultation.Dock = DockStyle.Fill;
            tabControlConsultation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabControlConsultation.Location = new Point(16, 12);
            tabControlConsultation.Name = "tabControlConsultation";
            tabControlConsultation.SelectedIndex = 0;
            tabControlConsultation.Size = new Size(1068, 505);
            tabControlConsultation.TabIndex = 0;
            // 
            // tabPageAnamnesis
            // 
            tabPageAnamnesis.BackColor = Color.White;
            tabPageAnamnesis.Controls.Add(labelReasonPrompt);
            tabPageAnamnesis.Controls.Add(textBoxReasonForConsultation);
            tabPageAnamnesis.Controls.Add(labelPhysicalPrompt);
            tabPageAnamnesis.Controls.Add(textBoxPhysicalExamination);
            tabPageAnamnesis.Controls.Add(labelEvolutionPrompt);
            tabPageAnamnesis.Controls.Add(textBoxEvolutionNotes);
            tabPageAnamnesis.Location = new Point(4, 30);
            tabPageAnamnesis.Name = "tabPageAnamnesis";
            tabPageAnamnesis.Padding = new Padding(16);
            tabPageAnamnesis.Size = new Size(1060, 471);
            tabPageAnamnesis.TabIndex = 0;
            tabPageAnamnesis.Text = "  Anamnesis y Examen Físico  ";
            // 
            // labelReasonPrompt
            // 
            labelReasonPrompt.AutoSize = true;
            labelReasonPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelReasonPrompt.Location = new Point(16, 12);
            labelReasonPrompt.Name = "labelReasonPrompt";
            labelReasonPrompt.Size = new Size(244, 20);
            labelReasonPrompt.TabIndex = 0;
            labelReasonPrompt.Text = "Motivo de Consulta (Obligatorio):";
            // 
            // textBoxReasonForConsultation
            // 
            textBoxReasonForConsultation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxReasonForConsultation.BorderStyle = BorderStyle.FixedSingle;
            textBoxReasonForConsultation.Font = new Font("Segoe UI", 9.5F);
            textBoxReasonForConsultation.Location = new Point(16, 35);
            textBoxReasonForConsultation.MaxLength = 500;
            textBoxReasonForConsultation.Multiline = true;
            textBoxReasonForConsultation.Name = "textBoxReasonForConsultation";
            textBoxReasonForConsultation.PlaceholderText = "Describa el motivo principal de la consulta médica...";
            textBoxReasonForConsultation.Size = new Size(1028, 80);
            textBoxReasonForConsultation.TabIndex = 1;
            // 
            // labelPhysicalPrompt
            // 
            labelPhysicalPrompt.AutoSize = true;
            labelPhysicalPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPhysicalPrompt.Location = new Point(16, 125);
            labelPhysicalPrompt.Name = "labelPhysicalPrompt";
            labelPhysicalPrompt.Size = new Size(284, 20);
            labelPhysicalPrompt.TabIndex = 2;
            labelPhysicalPrompt.Text = "Examen Físico y Signos Vitales (TA, FC):";
            // 
            // textBoxPhysicalExamination
            // 
            textBoxPhysicalExamination.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPhysicalExamination.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhysicalExamination.Font = new Font("Segoe UI", 9.5F);
            textBoxPhysicalExamination.Location = new Point(16, 148);
            textBoxPhysicalExamination.Multiline = true;
            textBoxPhysicalExamination.Name = "textBoxPhysicalExamination";
            textBoxPhysicalExamination.PlaceholderText = "Signos vitales, peso, talla, tensión arterial, auscultación, examen regional...";
            textBoxPhysicalExamination.Size = new Size(1028, 120);
            textBoxPhysicalExamination.TabIndex = 3;
            // 
            // labelEvolutionPrompt
            // 
            labelEvolutionPrompt.AutoSize = true;
            labelEvolutionPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEvolutionPrompt.Location = new Point(16, 280);
            labelEvolutionPrompt.Name = "labelEvolutionPrompt";
            labelEvolutionPrompt.Size = new Size(247, 20);
            labelEvolutionPrompt.TabIndex = 4;
            labelEvolutionPrompt.Text = "Evolución y Razonamiento Clínico:";
            // 
            // textBoxEvolutionNotes
            // 
            textBoxEvolutionNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEvolutionNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxEvolutionNotes.Font = new Font("Segoe UI", 9.5F);
            textBoxEvolutionNotes.Location = new Point(16, 303);
            textBoxEvolutionNotes.Multiline = true;
            textBoxEvolutionNotes.Name = "textBoxEvolutionNotes";
            textBoxEvolutionNotes.PlaceholderText = "Notas de evolución del paciente, juicio clínico y conducta médica...";
            textBoxEvolutionNotes.Size = new Size(1028, 150);
            textBoxEvolutionNotes.TabIndex = 5;
            // 
            // tabPageDiagnosticos
            // 
            tabPageDiagnosticos.BackColor = Color.White;
            tabPageDiagnosticos.Controls.Add(labelDiagTypePrompt);
            tabPageDiagnosticos.Controls.Add(comboBoxDiagnosisType);
            tabPageDiagnosticos.Controls.Add(labelDiagDescPrompt);
            tabPageDiagnosticos.Controls.Add(textBoxDiagnosisDescription);
            tabPageDiagnosticos.Controls.Add(labelCie10Prompt);
            tabPageDiagnosticos.Controls.Add(textBoxCie10);
            tabPageDiagnosticos.Controls.Add(labelDiagNotesPrompt);
            tabPageDiagnosticos.Controls.Add(textBoxDiagnosisNotes);
            tabPageDiagnosticos.Controls.Add(buttonAddDiagnosis);
            tabPageDiagnosticos.Controls.Add(buttonRemoveDiagnosis);
            tabPageDiagnosticos.Controls.Add(dataGridViewDiagnoses);
            tabPageDiagnosticos.Location = new Point(4, 30);
            tabPageDiagnosticos.Name = "tabPageDiagnosticos";
            tabPageDiagnosticos.Padding = new Padding(16);
            tabPageDiagnosticos.Size = new Size(1060, 471);
            tabPageDiagnosticos.TabIndex = 1;
            tabPageDiagnosticos.Text = "  Diagnósticos  ";
            // 
            // labelDiagTypePrompt
            // 
            labelDiagTypePrompt.AutoSize = true;
            labelDiagTypePrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDiagTypePrompt.Location = new Point(16, 12);
            labelDiagTypePrompt.Name = "labelDiagTypePrompt";
            labelDiagTypePrompt.Size = new Size(44, 20);
            labelDiagTypePrompt.TabIndex = 0;
            labelDiagTypePrompt.Text = "Tipo:";
            // 
            // comboBoxDiagnosisType
            // 
            comboBoxDiagnosisType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDiagnosisType.Font = new Font("Segoe UI", 9.5F);
            comboBoxDiagnosisType.Location = new Point(16, 34);
            comboBoxDiagnosisType.Name = "comboBoxDiagnosisType";
            comboBoxDiagnosisType.Size = new Size(160, 29);
            comboBoxDiagnosisType.TabIndex = 1;
            // 
            // labelDiagDescPrompt
            // 
            labelDiagDescPrompt.AutoSize = true;
            labelDiagDescPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDiagDescPrompt.Location = new Point(186, 12);
            labelDiagDescPrompt.Name = "labelDiagDescPrompt";
            labelDiagDescPrompt.Size = new Size(180, 20);
            labelDiagDescPrompt.TabIndex = 2;
            labelDiagDescPrompt.Text = "Descripción Diagnóstica:";
            // 
            // textBoxDiagnosisDescription
            // 
            textBoxDiagnosisDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDiagnosisDescription.Font = new Font("Segoe UI", 9.5F);
            textBoxDiagnosisDescription.Location = new Point(186, 34);
            textBoxDiagnosisDescription.MaxLength = 250;
            textBoxDiagnosisDescription.Name = "textBoxDiagnosisDescription";
            textBoxDiagnosisDescription.PlaceholderText = "Patología o diagnóstico clínico...";
            textBoxDiagnosisDescription.Size = new Size(420, 29);
            textBoxDiagnosisDescription.TabIndex = 3;
            // 
            // labelCie10Prompt
            // 
            labelCie10Prompt.AutoSize = true;
            labelCie10Prompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelCie10Prompt.Location = new Point(616, 12);
            labelCie10Prompt.Name = "labelCie10Prompt";
            labelCie10Prompt.Size = new Size(59, 20);
            labelCie10Prompt.TabIndex = 4;
            labelCie10Prompt.Text = "CIE-10:";
            // 
            // textBoxCie10
            // 
            textBoxCie10.BorderStyle = BorderStyle.FixedSingle;
            textBoxCie10.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            textBoxCie10.Location = new Point(616, 34);
            textBoxCie10.MaxLength = 20;
            textBoxCie10.Name = "textBoxCie10";
            textBoxCie10.PlaceholderText = "Ej: I10, J00";
            textBoxCie10.Size = new Size(110, 29);
            textBoxCie10.TabIndex = 5;
            // 
            // labelDiagNotesPrompt
            // 
            labelDiagNotesPrompt.AutoSize = true;
            labelDiagNotesPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDiagNotesPrompt.Location = new Point(16, 72);
            labelDiagNotesPrompt.Name = "labelDiagNotesPrompt";
            labelDiagNotesPrompt.Size = new Size(167, 20);
            labelDiagNotesPrompt.TabIndex = 6;
            labelDiagNotesPrompt.Text = "Notas del Diagnóstico:";
            // 
            // textBoxDiagnosisNotes
            // 
            textBoxDiagnosisNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDiagnosisNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxDiagnosisNotes.Font = new Font("Segoe UI", 9.5F);
            textBoxDiagnosisNotes.Location = new Point(16, 94);
            textBoxDiagnosisNotes.MaxLength = 500;
            textBoxDiagnosisNotes.Name = "textBoxDiagnosisNotes";
            textBoxDiagnosisNotes.PlaceholderText = "Detalles, estadio o consideraciones adicionales...";
            textBoxDiagnosisNotes.Size = new Size(710, 29);
            textBoxDiagnosisNotes.TabIndex = 7;
            // 
            // buttonAddDiagnosis
            // 
            buttonAddDiagnosis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddDiagnosis.BackColor = Color.FromArgb(2, 132, 199);
            buttonAddDiagnosis.FlatAppearance.BorderSize = 0;
            buttonAddDiagnosis.FlatStyle = FlatStyle.Flat;
            buttonAddDiagnosis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonAddDiagnosis.ForeColor = Color.White;
            buttonAddDiagnosis.Location = new Point(745, 93);
            buttonAddDiagnosis.Name = "buttonAddDiagnosis";
            buttonAddDiagnosis.Size = new Size(165, 31);
            buttonAddDiagnosis.TabIndex = 8;
            buttonAddDiagnosis.Text = "+ AGREGAR";
            buttonAddDiagnosis.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveDiagnosis
            // 
            buttonRemoveDiagnosis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRemoveDiagnosis.BackColor = Color.FromArgb(239, 68, 68);
            buttonRemoveDiagnosis.FlatAppearance.BorderSize = 0;
            buttonRemoveDiagnosis.FlatStyle = FlatStyle.Flat;
            buttonRemoveDiagnosis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRemoveDiagnosis.ForeColor = Color.White;
            buttonRemoveDiagnosis.Location = new Point(925, 93);
            buttonRemoveDiagnosis.Name = "buttonRemoveDiagnosis";
            buttonRemoveDiagnosis.Size = new Size(120, 31);
            buttonRemoveDiagnosis.TabIndex = 9;
            buttonRemoveDiagnosis.Text = "QUITAR";
            buttonRemoveDiagnosis.UseVisualStyleBackColor = false;
            // 
            // dataGridViewDiagnoses
            // 
            dataGridViewDiagnoses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDiagnoses.BackgroundColor = Color.White;
            dataGridViewDiagnoses.BorderStyle = BorderStyle.None;
            dataGridViewDiagnoses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiagnoses.Location = new Point(16, 135);
            dataGridViewDiagnoses.Name = "dataGridViewDiagnoses";
            dataGridViewDiagnoses.RowHeadersWidth = 51;
            dataGridViewDiagnoses.Size = new Size(1028, 318);
            dataGridViewDiagnoses.TabIndex = 10;
            // 
            // tabPageIndicaciones
            // 
            tabPageIndicaciones.BackColor = Color.White;
            tabPageIndicaciones.Controls.Add(labelInstructionsPrompt);
            tabPageIndicaciones.Controls.Add(textBoxInstructions);
            tabPageIndicaciones.Controls.Add(labelMedicationPrompt);
            tabPageIndicaciones.Controls.Add(textBoxMedicationDetails);
            tabPageIndicaciones.Controls.Add(labelFollowUpPrompt);
            tabPageIndicaciones.Controls.Add(textBoxFollowUpNotes);
            tabPageIndicaciones.Controls.Add(labelPrivateNotesPrompt);
            tabPageIndicaciones.Controls.Add(textBoxPrivateNotes);
            tabPageIndicaciones.Location = new Point(4, 30);
            tabPageIndicaciones.Name = "tabPageIndicaciones";
            tabPageIndicaciones.Padding = new Padding(16);
            tabPageIndicaciones.Size = new Size(1060, 471);
            tabPageIndicaciones.TabIndex = 2;
            tabPageIndicaciones.Text = "  Tratamiento e Indicaciones  ";
            // 
            // labelInstructionsPrompt
            // 
            labelInstructionsPrompt.AutoSize = true;
            labelInstructionsPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelInstructionsPrompt.Location = new Point(16, 12);
            labelInstructionsPrompt.Name = "labelInstructionsPrompt";
            labelInstructionsPrompt.Size = new Size(312, 20);
            labelInstructionsPrompt.TabIndex = 0;
            labelInstructionsPrompt.Text = "Indicaciones Generales, Cuidados y Reposo:";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInstructions.BorderStyle = BorderStyle.FixedSingle;
            textBoxInstructions.Font = new Font("Segoe UI", 9.5F);
            textBoxInstructions.Location = new Point(16, 35);
            textBoxInstructions.Multiline = true;
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.PlaceholderText = "Recomendaciones higiénico-dietéticas, reposo, pautas de alarma, estudios solicitados...";
            textBoxInstructions.Size = new Size(1028, 100);
            textBoxInstructions.TabIndex = 1;
            // 
            // labelMedicationPrompt
            // 
            labelMedicationPrompt.AutoSize = true;
            labelMedicationPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMedicationPrompt.Location = new Point(16, 145);
            labelMedicationPrompt.Name = "labelMedicationPrompt";
            labelMedicationPrompt.Size = new Size(319, 20);
            labelMedicationPrompt.TabIndex = 2;
            labelMedicationPrompt.Text = "Medicación y Posología (Dosis / Frecuencia):";
            // 
            // textBoxMedicationDetails
            // 
            textBoxMedicationDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMedicationDetails.BorderStyle = BorderStyle.FixedSingle;
            textBoxMedicationDetails.Font = new Font("Segoe UI", 9.5F);
            textBoxMedicationDetails.Location = new Point(16, 168);
            textBoxMedicationDetails.Multiline = true;
            textBoxMedicationDetails.Name = "textBoxMedicationDetails";
            textBoxMedicationDetails.PlaceholderText = "Fármaco, presentación, dosis y duración del tratamiento...";
            textBoxMedicationDetails.Size = new Size(1028, 110);
            textBoxMedicationDetails.TabIndex = 3;
            // 
            // labelFollowUpPrompt
            // 
            labelFollowUpPrompt.AutoSize = true;
            labelFollowUpPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFollowUpPrompt.Location = new Point(16, 290);
            labelFollowUpPrompt.Name = "labelFollowUpPrompt";
            labelFollowUpPrompt.Size = new Size(286, 20);
            labelFollowUpPrompt.TabIndex = 4;
            labelFollowUpPrompt.Text = "Próximo Control / Seguimiento Médico:";
            // 
            // textBoxFollowUpNotes
            // 
            textBoxFollowUpNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFollowUpNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxFollowUpNotes.Font = new Font("Segoe UI", 9.5F);
            textBoxFollowUpNotes.Location = new Point(16, 313);
            textBoxFollowUpNotes.MaxLength = 500;
            textBoxFollowUpNotes.Name = "textBoxFollowUpNotes";
            textBoxFollowUpNotes.PlaceholderText = "Ej: Control en 15 días con resultados de laboratorio...";
            textBoxFollowUpNotes.Size = new Size(1028, 29);
            textBoxFollowUpNotes.TabIndex = 5;
            // 
            // labelPrivateNotesPrompt
            // 
            labelPrivateNotesPrompt.AutoSize = true;
            labelPrivateNotesPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPrivateNotesPrompt.ForeColor = Color.FromArgb(100, 116, 139);
            labelPrivateNotesPrompt.Location = new Point(16, 355);
            labelPrivateNotesPrompt.Name = "labelPrivateNotesPrompt";
            labelPrivateNotesPrompt.Size = new Size(198, 20);
            labelPrivateNotesPrompt.TabIndex = 6;
            labelPrivateNotesPrompt.Text = "Notas Privadas del Médico:";
            // 
            // textBoxPrivateNotes
            // 
            textBoxPrivateNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPrivateNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxPrivateNotes.Font = new Font("Segoe UI", 9.5F);
            textBoxPrivateNotes.Location = new Point(16, 378);
            textBoxPrivateNotes.Multiline = true;
            textBoxPrivateNotes.Name = "textBoxPrivateNotes";
            textBoxPrivateNotes.PlaceholderText = "Observaciones clínicas confidenciales internas...";
            textBoxPrivateNotes.Size = new Size(1028, 75);
            textBoxPrivateNotes.TabIndex = 7;
            // 
            // panelFooterActions
            // 
            panelFooterActions.BackColor = Color.White;
            panelFooterActions.Controls.Add(picIconSave);
            panelFooterActions.Controls.Add(buttonSaveConsultation);
            panelFooterActions.Controls.Add(picIconCancel);
            panelFooterActions.Controls.Add(buttonCancel);
            panelFooterActions.Dock = DockStyle.Bottom;
            panelFooterActions.Location = new Point(0, 670);
            panelFooterActions.Name = "panelFooterActions";
            panelFooterActions.Padding = new Padding(16, 10, 16, 10);
            panelFooterActions.Size = new Size(1100, 70);
            panelFooterActions.TabIndex = 3;
            // 
            // picIconSave
            // 
            picIconSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(748, 12);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(36, 46);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // buttonSaveConsultation
            // 
            buttonSaveConsultation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveConsultation.BackColor = Color.FromArgb(16, 185, 129);
            buttonSaveConsultation.Cursor = Cursors.Hand;
            buttonSaveConsultation.FlatAppearance.BorderSize = 0;
            buttonSaveConsultation.FlatStyle = FlatStyle.Flat;
            buttonSaveConsultation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSaveConsultation.ForeColor = Color.White;
            buttonSaveConsultation.Location = new Point(748, 12);
            buttonSaveConsultation.Name = "buttonSaveConsultation";
            buttonSaveConsultation.Padding = new Padding(28, 0, 0, 0);
            buttonSaveConsultation.Size = new Size(336, 46);
            buttonSaveConsultation.TabIndex = 0;
            buttonSaveConsultation.Text = "FINALIZAR Y GUARDAR CONSULTA";
            buttonSaveConsultation.UseVisualStyleBackColor = false;
            // 
            // picIconCancel
            // 
            picIconCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(584, 12);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(36, 46);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(568, 12);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(165, 46);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormConsultationEntry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1100, 740);
            Controls.Add(panelFormContainer);
            Controls.Add(panelFooterActions);
            Controls.Add(panelPatientSummaryCard);
            Controls.Add(panelHeader);
            Name = "FormConsultationEntry";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Atención Médica - Cliniqax";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPatientSummaryCard.ResumeLayout(false);
            panelPatientSummaryCard.PerformLayout();
            panelFormContainer.ResumeLayout(false);
            tabControlConsultation.ResumeLayout(false);
            tabPageAnamnesis.ResumeLayout(false);
            tabPageAnamnesis.PerformLayout();
            tabPageDiagnosticos.ResumeLayout(false);
            tabPageDiagnosticos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiagnoses).EndInit();
            tabPageIndicaciones.ResumeLayout(false);
            tabPageIndicaciones.PerformLayout();
            panelFooterActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelPatientSummaryCard;
        private Label labelPatientName;
        private Label labelPatientInfo;
        private Label labelProfPrompt;
        private ComboBox comboBoxProfessionals;
        private Label labelSpecPrompt;
        private ComboBox comboBoxSpecialties;
        private Label labelDatePrompt;
        private DateTimePicker dateTimePickerDate;
        private Panel panelFormContainer;
        private TabControl tabControlConsultation;
        private TabPage tabPageAnamnesis;
        private Label labelReasonPrompt;
        private TextBox textBoxReasonForConsultation;
        private Label labelPhysicalPrompt;
        private TextBox textBoxPhysicalExamination;
        private Label labelEvolutionPrompt;
        private TextBox textBoxEvolutionNotes;
        private TabPage tabPageDiagnosticos;
        private Label labelDiagTypePrompt;
        private ComboBox comboBoxDiagnosisType;
        private Label labelDiagDescPrompt;
        private TextBox textBoxDiagnosisDescription;
        private Label labelCie10Prompt;
        private TextBox textBoxCie10;
        private Label labelDiagNotesPrompt;
        private TextBox textBoxDiagnosisNotes;
        private Button buttonAddDiagnosis;
        private Button buttonRemoveDiagnosis;
        private DataGridView dataGridViewDiagnoses;
        private TabPage tabPageIndicaciones;
        private Label labelInstructionsPrompt;
        private TextBox textBoxInstructions;
        private Label labelMedicationPrompt;
        private TextBox textBoxMedicationDetails;
        private Label labelFollowUpPrompt;
        private TextBox textBoxFollowUpNotes;
        private Label labelPrivateNotesPrompt;
        private TextBox textBoxPrivateNotes;
        private Panel panelFooterActions;
        private Button buttonSaveConsultation;
        private PictureBox picIconSave;
        private Button buttonCancel;
        private PictureBox picIconCancel;
    }
}