namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormRescheduleDialog
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
            labelCurrentInfoTitle = new Label();
            labelPatientDisplay = new Label();
            labelProfessionalDisplay = new Label();
            labelCurrentSlotDisplay = new Label();
            labelNewDatePrompt = new Label();
            dateTimePickerNewDate = new DateTimePicker();
            labelStartPrompt = new Label();
            dateTimePickerStartTime = new DateTimePicker();
            labelEndPrompt = new Label();
            dateTimePickerEndTime = new DateTimePicker();
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
            panelHeader.Size = new Size(490, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(239, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "REPROGRAMAR TURNO";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelCurrentInfoTitle);
            panelCard.Controls.Add(labelPatientDisplay);
            panelCard.Controls.Add(labelProfessionalDisplay);
            panelCard.Controls.Add(labelCurrentSlotDisplay);
            panelCard.Controls.Add(labelNewDatePrompt);
            panelCard.Controls.Add(dateTimePickerNewDate);
            panelCard.Controls.Add(labelStartPrompt);
            panelCard.Controls.Add(dateTimePickerStartTime);
            panelCard.Controls.Add(labelEndPrompt);
            panelCard.Controls.Add(dateTimePickerEndTime);
            panelCard.Controls.Add(picIconConfirm);
            panelCard.Controls.Add(buttonConfirm);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 62);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(458, 305);
            panelCard.TabIndex = 1;
            // 
            // labelCurrentInfoTitle
            // 
            labelCurrentInfoTitle.AutoSize = true;
            labelCurrentInfoTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCurrentInfoTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelCurrentInfoTitle.Location = new Point(16, 12);
            labelCurrentInfoTitle.Name = "labelCurrentInfoTitle";
            labelCurrentInfoTitle.Size = new Size(184, 21);
            labelCurrentInfoTitle.TabIndex = 0;
            labelCurrentInfoTitle.Text = "Información del Turno:";
            // 
            // labelPatientDisplay
            // 
            labelPatientDisplay.AutoEllipsis = true;
            labelPatientDisplay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPatientDisplay.ForeColor = Color.FromArgb(15, 23, 42);
            labelPatientDisplay.Location = new Point(16, 36);
            labelPatientDisplay.Name = "labelPatientDisplay";
            labelPatientDisplay.Size = new Size(426, 20);
            labelPatientDisplay.TabIndex = 1;
            labelPatientDisplay.Text = "Paciente: Cargando...";
            // 
            // labelProfessionalDisplay
            // 
            labelProfessionalDisplay.AutoEllipsis = true;
            labelProfessionalDisplay.Font = new Font("Segoe UI", 9F);
            labelProfessionalDisplay.ForeColor = Color.FromArgb(100, 116, 139);
            labelProfessionalDisplay.Location = new Point(16, 58);
            labelProfessionalDisplay.Name = "labelProfessionalDisplay";
            labelProfessionalDisplay.Size = new Size(426, 20);
            labelProfessionalDisplay.TabIndex = 2;
            labelProfessionalDisplay.Text = "Médico: Cargando...";
            // 
            // labelCurrentSlotDisplay
            // 
            labelCurrentSlotDisplay.AutoEllipsis = true;
            labelCurrentSlotDisplay.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            labelCurrentSlotDisplay.ForeColor = Color.FromArgb(100, 116, 139);
            labelCurrentSlotDisplay.Location = new Point(16, 80);
            labelCurrentSlotDisplay.Name = "labelCurrentSlotDisplay";
            labelCurrentSlotDisplay.Size = new Size(426, 20);
            labelCurrentSlotDisplay.TabIndex = 3;
            labelCurrentSlotDisplay.Text = "Turno actual: 00/00/0000 (00:00 - 00:00)";
            // 
            // labelNewDatePrompt
            // 
            labelNewDatePrompt.AutoSize = true;
            labelNewDatePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNewDatePrompt.Location = new Point(16, 120);
            labelNewDatePrompt.Name = "labelNewDatePrompt";
            labelNewDatePrompt.Size = new Size(102, 20);
            labelNewDatePrompt.TabIndex = 4;
            labelNewDatePrompt.Text = "Nueva Fecha:";
            // 
            // dateTimePickerNewDate
            // 
            dateTimePickerNewDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerNewDate.Format = DateTimePickerFormat.Short;
            dateTimePickerNewDate.Location = new Point(16, 143);
            dateTimePickerNewDate.Name = "dateTimePickerNewDate";
            dateTimePickerNewDate.Size = new Size(150, 30);
            dateTimePickerNewDate.TabIndex = 5;
            // 
            // labelStartPrompt
            // 
            labelStartPrompt.AutoSize = true;
            labelStartPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStartPrompt.Location = new Point(186, 120);
            labelStartPrompt.Name = "labelStartPrompt";
            labelStartPrompt.Size = new Size(56, 20);
            labelStartPrompt.TabIndex = 6;
            labelStartPrompt.Text = "Desde:";
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.CustomFormat = "HH:mm";
            dateTimePickerStartTime.Font = new Font("Segoe UI", 10F);
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.Location = new Point(186, 143);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.ShowUpDown = true;
            dateTimePickerStartTime.Size = new Size(110, 30);
            dateTimePickerStartTime.TabIndex = 7;
            // 
            // labelEndPrompt
            // 
            labelEndPrompt.AutoSize = true;
            labelEndPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEndPrompt.Location = new Point(316, 120);
            labelEndPrompt.Name = "labelEndPrompt";
            labelEndPrompt.Size = new Size(53, 20);
            labelEndPrompt.TabIndex = 8;
            labelEndPrompt.Text = "Hasta:";
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.CustomFormat = "HH:mm";
            dateTimePickerEndTime.Font = new Font("Segoe UI", 10F);
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.Location = new Point(316, 143);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.Size = new Size(110, 30);
            dateTimePickerEndTime.TabIndex = 9;
            // 
            // picIconConfirm
            // 
            picIconConfirm.BackColor = Color.FromArgb(2, 132, 199);
            picIconConfirm.Cursor = Cursors.Hand;
            picIconConfirm.Image = Icons.clinical_reprogramar_turno;
            picIconConfirm.Location = new Point(236, 230);
            picIconConfirm.Name = "picIconConfirm";
            picIconConfirm.Size = new Size(51, 46);
            picIconConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirm.TabIndex = 99;
            picIconConfirm.TabStop = false;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.FromArgb(2, 132, 199);
            buttonConfirm.Cursor = Cursors.Hand;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.Location = new Point(236, 230);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Padding = new Padding(24, 0, 0, 0);
            buttonConfirm.Size = new Size(206, 46);
            buttonConfirm.TabIndex = 10;
            buttonConfirm.Text = "REPROGRAMAR";
            buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(66, 230);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(43, 46);
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
            buttonCancel.Location = new Point(66, 230);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(154, 46);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormRescheduleDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(490, 385);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRescheduleDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reprogramación de Cita";
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
        private Label labelCurrentInfoTitle;
        private Label labelPatientDisplay;
        private Label labelProfessionalDisplay;
        private Label labelCurrentSlotDisplay;
        private Label labelNewDatePrompt;
        private DateTimePicker dateTimePickerNewDate;
        private Label labelStartPrompt;
        private DateTimePicker dateTimePickerStartTime;
        private Label labelEndPrompt;
        private DateTimePicker dateTimePickerEndTime;
        private Button buttonConfirm;
        private Button buttonCancel;
        private PictureBox picIconConfirm;
        private PictureBox picIconCancel;
    }
}