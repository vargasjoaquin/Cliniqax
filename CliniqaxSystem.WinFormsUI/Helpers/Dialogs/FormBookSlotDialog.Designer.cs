namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormBookSlotDialog
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
            panelCard = new Panel();
            labelProfessionalDisplay = new Label();
            labelSearchPrompt = new Label();
            textBoxSearchPatient = new TextBox();
            labelPatientPrompt = new Label();
            comboBoxPatients = new ComboBox();
            labelSpecialtyPrompt = new Label();
            comboBoxSpecialties = new ComboBox();
            labelObservationsPrompt = new Label();
            textBoxObservations = new TextBox();
            picIconConfirm = new PictureBox();
            buttonConfirm = new Button();
            picIconCancel = new PictureBox();
            buttonCancel = new Button();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).BeginInit();
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
            panelHeader.Size = new Size(533, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(205, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "RESERVA DE TURNO";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelProfessionalDisplay);
            panelCard.Controls.Add(labelSearchPrompt);
            panelCard.Controls.Add(textBoxSearchPatient);
            panelCard.Controls.Add(labelPatientPrompt);
            panelCard.Controls.Add(comboBoxPatients);
            panelCard.Controls.Add(labelSpecialtyPrompt);
            panelCard.Controls.Add(comboBoxSpecialties);
            panelCard.Controls.Add(labelObservationsPrompt);
            panelCard.Controls.Add(textBoxObservations);
            panelCard.Controls.Add(picIconConfirm);
            panelCard.Controls.Add(buttonConfirm);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 62);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(505, 441);
            panelCard.TabIndex = 1;
            // 
            // labelProfessionalDisplay
            // 
            labelProfessionalDisplay.AutoEllipsis = true;
            labelProfessionalDisplay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelProfessionalDisplay.ForeColor = Color.FromArgb(2, 132, 199);
            labelProfessionalDisplay.Location = new Point(16, 12);
            labelProfessionalDisplay.Name = "labelProfessionalDisplay";
            labelProfessionalDisplay.Size = new Size(416, 22);
            labelProfessionalDisplay.TabIndex = 0;
            labelProfessionalDisplay.Text = "Profesional: Cargando...";
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(16, 44);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(240, 20);
            labelSearchPrompt.TabIndex = 1;
            labelSearchPrompt.Text = "Buscar Paciente (DNI / Nombre):";
            // 
            // textBoxSearchPatient
            // 
            textBoxSearchPatient.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchPatient.Font = new Font("Segoe UI", 10F);
            textBoxSearchPatient.Location = new Point(16, 66);
            textBoxSearchPatient.Name = "textBoxSearchPatient";
            textBoxSearchPatient.PlaceholderText = "Escriba DNI o apellido para filtrar...";
            textBoxSearchPatient.Size = new Size(447, 30);
            textBoxSearchPatient.TabIndex = 2;
            // 
            // labelPatientPrompt
            // 
            labelPatientPrompt.AutoSize = true;
            labelPatientPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelPatientPrompt.Location = new Point(16, 111);
            labelPatientPrompt.Name = "labelPatientPrompt";
            labelPatientPrompt.Size = new Size(154, 20);
            labelPatientPrompt.TabIndex = 3;
            labelPatientPrompt.Text = "Seleccionar Paciente:";
            // 
            // comboBoxPatients
            // 
            comboBoxPatients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPatients.Font = new Font("Segoe UI", 9.5F);
            comboBoxPatients.Location = new Point(16, 133);
            comboBoxPatients.Name = "comboBoxPatients";
            comboBoxPatients.Size = new Size(447, 29);
            comboBoxPatients.TabIndex = 4;
            // 
            // labelSpecialtyPrompt
            // 
            labelSpecialtyPrompt.AutoSize = true;
            labelSpecialtyPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSpecialtyPrompt.Location = new Point(16, 177);
            labelSpecialtyPrompt.Name = "labelSpecialtyPrompt";
            labelSpecialtyPrompt.Size = new Size(200, 20);
            labelSpecialtyPrompt.TabIndex = 5;
            labelSpecialtyPrompt.Text = "Especialidad de la Consulta:";
            // 
            // comboBoxSpecialties
            // 
            comboBoxSpecialties.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialties.Font = new Font("Segoe UI", 9.5F);
            comboBoxSpecialties.Location = new Point(16, 199);
            comboBoxSpecialties.Name = "comboBoxSpecialties";
            comboBoxSpecialties.Size = new Size(447, 29);
            comboBoxSpecialties.TabIndex = 6;
            // 
            // labelObservationsPrompt
            // 
            labelObservationsPrompt.AutoSize = true;
            labelObservationsPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelObservationsPrompt.Location = new Point(16, 251);
            labelObservationsPrompt.Name = "labelObservationsPrompt";
            labelObservationsPrompt.Size = new Size(180, 20);
            labelObservationsPrompt.TabIndex = 7;
            labelObservationsPrompt.Text = "Motivo / Observaciones:";
            // 
            // textBoxObservations
            // 
            textBoxObservations.BorderStyle = BorderStyle.FixedSingle;
            textBoxObservations.Font = new Font("Segoe UI", 9.5F);
            textBoxObservations.Location = new Point(16, 273);
            textBoxObservations.MaxLength = 500;
            textBoxObservations.Multiline = true;
            textBoxObservations.Name = "textBoxObservations";
            textBoxObservations.Size = new Size(470, 59);
            textBoxObservations.TabIndex = 8;
            // 
            // picIconConfirm
            // 
            picIconConfirm.BackColor = Color.FromArgb(16, 185, 129);
            picIconConfirm.Cursor = Cursors.Hand;
            picIconConfirm.Image = Icons.action_guardar;
            picIconConfirm.Location = new Point(301, 376);
            picIconConfirm.Name = "picIconConfirm";
            picIconConfirm.Size = new Size(36, 46);
            picIconConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirm.TabIndex = 99;
            picIconConfirm.TabStop = false;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.FromArgb(16, 185, 129);
            buttonConfirm.Cursor = Cursors.Hand;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.Location = new Point(301, 376);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Padding = new Padding(24, 0, 0, 0);
            buttonConfirm.Size = new Size(196, 46);
            buttonConfirm.TabIndex = 9;
            buttonConfirm.Text = "CONFIRMAR TURNO";
            buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(141, 376);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(41, 46);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(141, 376);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(144, 46);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormBookSlotDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(533, 515);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBookSlotDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reserva de Turno";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelCard;
        private Label labelProfessionalDisplay;
        private Label labelSearchPrompt;
        private TextBox textBoxSearchPatient;
        private Label labelPatientPrompt;
        private ComboBox comboBoxPatients;
        private Label labelSpecialtyPrompt;
        private ComboBox comboBoxSpecialties;
        private Label labelObservationsPrompt;
        private TextBox textBoxObservations;
        private Button buttonConfirm;
        private Button buttonCancel;
        private PictureBox picIconConfirm;
        private PictureBox picIconCancel;
    }
}