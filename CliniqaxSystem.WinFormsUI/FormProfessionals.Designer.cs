namespace CliniqaxSystem.WinFormsUI
{
    partial class FormProfessionals
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
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconToggleStatus = new PictureBox();
            picIconDelete = new PictureBox();
            picIconCancel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelMain = new Panel();
            dataGridViewProfessionals = new DataGridView();
            panelSearchAndCount = new Panel();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            labelTotalProfessionals = new Label();
            panelProfessionalForm = new Panel();
            labelDocumentNumber = new Label();
            textBoxDocumentNumber = new TextBox();
            labelLicenseNumber = new Label();
            textBoxLicenseNumber = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelDuration = new Label();
            numericUpDownDuration = new NumericUpDown();
            labelSpecialties = new Label();
            checkedListBoxSpecialties = new CheckedListBox();
            groupBoxSchedules = new GroupBox();
            labelDay = new Label();
            comboBoxDayOfWeek = new ComboBox();
            labelStartTime = new Label();
            dateTimePickerStartTime = new DateTimePicker();
            labelEndTime = new Label();
            dateTimePickerEndTime = new DateTimePicker();
            buttonAddSchedule = new Button();
            buttonRemoveSchedule = new Button();
            dataGridViewSchedules = new DataGridView();
            labelObservations = new Label();
            textBoxObservations = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonToggleStatus = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfessionals).BeginInit();
            panelSearchAndCount.SuspendLayout();
            panelProfessionalForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).BeginInit();
            groupBoxSchedules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).BeginInit();
            SuspendLayout();
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(1268, 10);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(39, 53);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(2, 132, 199);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Icons.action_editar;
            picIconEdit.Location = new Point(1280, 73);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(40, 52);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconToggleStatus
            // 
            picIconToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            picIconToggleStatus.Cursor = Cursors.Hand;
            picIconToggleStatus.Image = Icons.action_activar_desactivar;
            picIconToggleStatus.Location = new Point(1229, 132);
            picIconToggleStatus.Name = "picIconToggleStatus";
            picIconToggleStatus.Size = new Size(51, 54);
            picIconToggleStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleStatus.TabIndex = 99;
            picIconToggleStatus.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Icons.action_eliminar;
            picIconDelete.Location = new Point(1261, 192);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(46, 50);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(1229, 248);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(48, 49);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1542, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 17);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(456, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE PROFESIONALES Y HORARIOS";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dataGridViewProfessionals);
            panelMain.Controls.Add(panelSearchAndCount);
            panelMain.Controls.Add(panelProfessionalForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 12, 16, 16);
            panelMain.Size = new Size(1542, 836);
            panelMain.TabIndex = 1;
            // 
            // dataGridViewProfessionals
            // 
            dataGridViewProfessionals.BackgroundColor = Color.White;
            dataGridViewProfessionals.BorderStyle = BorderStyle.None;
            dataGridViewProfessionals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProfessionals.Dock = DockStyle.Fill;
            dataGridViewProfessionals.Location = new Point(16, 400);
            dataGridViewProfessionals.Name = "dataGridViewProfessionals";
            dataGridViewProfessionals.RowHeadersWidth = 51;
            dataGridViewProfessionals.Size = new Size(1510, 420);
            dataGridViewProfessionals.TabIndex = 2;
            // 
            // panelSearchAndCount
            // 
            panelSearchAndCount.BackColor = Color.Transparent;
            panelSearchAndCount.Controls.Add(labelSearchPrompt);
            panelSearchAndCount.Controls.Add(textBoxSearch);
            panelSearchAndCount.Controls.Add(labelTotalProfessionals);
            panelSearchAndCount.Dock = DockStyle.Top;
            panelSearchAndCount.Location = new Point(16, 332);
            panelSearchAndCount.Name = "panelSearchAndCount";
            panelSearchAndCount.Size = new Size(1510, 68);
            panelSearchAndCount.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.ForeColor = Color.FromArgb(15, 23, 42);
            labelSearchPrompt.Location = new Point(3, 21);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(65, 21);
            labelSearchPrompt.TabIndex = 0;
            labelSearchPrompt.Text = "Buscar:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(74, 18);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Escriba apellido, nombre, DNI, matrícula o especialidad...";
            textBoxSearch.Size = new Size(420, 30);
            textBoxSearch.TabIndex = 1;
            // 
            // labelTotalProfessionals
            // 
            labelTotalProfessionals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTotalProfessionals.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalProfessionals.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalProfessionals.Location = new Point(1192, 21);
            labelTotalProfessionals.Name = "labelTotalProfessionals";
            labelTotalProfessionals.Size = new Size(300, 21);
            labelTotalProfessionals.TabIndex = 2;
            labelTotalProfessionals.Text = "Profesionales Registrados: 0";
            labelTotalProfessionals.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelProfessionalForm
            // 
            panelProfessionalForm.BackColor = Color.White;
            panelProfessionalForm.Controls.Add(labelDocumentNumber);
            panelProfessionalForm.Controls.Add(textBoxDocumentNumber);
            panelProfessionalForm.Controls.Add(labelLicenseNumber);
            panelProfessionalForm.Controls.Add(textBoxLicenseNumber);
            panelProfessionalForm.Controls.Add(labelFirstName);
            panelProfessionalForm.Controls.Add(textBoxFirstName);
            panelProfessionalForm.Controls.Add(labelLastName);
            panelProfessionalForm.Controls.Add(textBoxLastName);
            panelProfessionalForm.Controls.Add(labelPhone);
            panelProfessionalForm.Controls.Add(textBoxPhone);
            panelProfessionalForm.Controls.Add(labelEmail);
            panelProfessionalForm.Controls.Add(textBoxEmail);
            panelProfessionalForm.Controls.Add(labelDuration);
            panelProfessionalForm.Controls.Add(numericUpDownDuration);
            panelProfessionalForm.Controls.Add(labelSpecialties);
            panelProfessionalForm.Controls.Add(checkedListBoxSpecialties);
            panelProfessionalForm.Controls.Add(groupBoxSchedules);
            panelProfessionalForm.Controls.Add(labelObservations);
            panelProfessionalForm.Controls.Add(textBoxObservations);
            panelProfessionalForm.Controls.Add(picIconSave);
            panelProfessionalForm.Controls.Add(buttonSave);
            panelProfessionalForm.Controls.Add(picIconEdit);
            panelProfessionalForm.Controls.Add(buttonEdit);
            panelProfessionalForm.Controls.Add(picIconToggleStatus);
            panelProfessionalForm.Controls.Add(buttonToggleStatus);
            panelProfessionalForm.Controls.Add(picIconDelete);
            panelProfessionalForm.Controls.Add(buttonDelete);
            panelProfessionalForm.Controls.Add(picIconCancel);
            panelProfessionalForm.Controls.Add(buttonCancel);
            panelProfessionalForm.Dock = DockStyle.Top;
            panelProfessionalForm.Location = new Point(16, 12);
            panelProfessionalForm.Name = "panelProfessionalForm";
            panelProfessionalForm.Size = new Size(1510, 320);
            panelProfessionalForm.TabIndex = 0;
            // 
            // labelDocumentNumber
            // 
            labelDocumentNumber.AutoSize = true;
            labelDocumentNumber.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDocumentNumber.Location = new Point(14, 8);
            labelDocumentNumber.Name = "labelDocumentNumber";
            labelDocumentNumber.Size = new Size(41, 20);
            labelDocumentNumber.TabIndex = 0;
            labelDocumentNumber.Text = "DNI:";
            // 
            // textBoxDocumentNumber
            // 
            textBoxDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            textBoxDocumentNumber.Location = new Point(14, 30);
            textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            textBoxDocumentNumber.Size = new Size(137, 29);
            textBoxDocumentNumber.TabIndex = 1;
            // 
            // labelLicenseNumber
            // 
            labelLicenseNumber.AutoSize = true;
            labelLicenseNumber.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelLicenseNumber.Location = new Point(180, 7);
            labelLicenseNumber.Name = "labelLicenseNumber";
            labelLicenseNumber.Size = new Size(79, 20);
            labelLicenseNumber.TabIndex = 2;
            labelLicenseNumber.Text = "Matrícula:";
            // 
            // textBoxLicenseNumber
            // 
            textBoxLicenseNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            textBoxLicenseNumber.Location = new Point(180, 30);
            textBoxLicenseNumber.Name = "textBoxLicenseNumber";
            textBoxLicenseNumber.Size = new Size(159, 29);
            textBoxLicenseNumber.TabIndex = 3;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelFirstName.Location = new Point(14, 73);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(71, 20);
            labelFirstName.TabIndex = 4;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 9.5F);
            textBoxFirstName.Location = new Point(14, 96);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(137, 29);
            textBoxFirstName.TabIndex = 5;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelLastName.Location = new Point(180, 73);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(71, 20);
            labelLastName.TabIndex = 6;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 9.5F);
            textBoxLastName.Location = new Point(180, 96);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(159, 29);
            textBoxLastName.TabIndex = 7;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelPhone.Location = new Point(14, 140);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(74, 20);
            labelPhone.TabIndex = 8;
            labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 9.5F);
            textBoxPhone.Location = new Point(14, 163);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(137, 29);
            textBoxPhone.TabIndex = 9;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelEmail.Location = new Point(180, 140);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(51, 20);
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 9.5F);
            textBoxEmail.Location = new Point(180, 163);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(159, 29);
            textBoxEmail.TabIndex = 11;
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelDuration.Location = new Point(14, 213);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(119, 20);
            labelDuration.TabIndex = 12;
            labelDuration.Text = "Duración (min):";
            // 
            // numericUpDownDuration
            // 
            numericUpDownDuration.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            numericUpDownDuration.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownDuration.Location = new Point(15, 236);
            numericUpDownDuration.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numericUpDownDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDuration.Name = "numericUpDownDuration";
            numericUpDownDuration.Size = new Size(110, 29);
            numericUpDownDuration.TabIndex = 13;
            numericUpDownDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // labelSpecialties
            // 
            labelSpecialties.AutoSize = true;
            labelSpecialties.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelSpecialties.Location = new Point(375, 7);
            labelSpecialties.Name = "labelSpecialties";
            labelSpecialties.Size = new Size(174, 20);
            labelSpecialties.TabIndex = 14;
            labelSpecialties.Text = "Especialidades Médicas:";
            // 
            // checkedListBoxSpecialties
            // 
            checkedListBoxSpecialties.CheckOnClick = true;
            checkedListBoxSpecialties.Font = new Font("Segoe UI", 9F);
            checkedListBoxSpecialties.FormattingEnabled = true;
            checkedListBoxSpecialties.Location = new Point(375, 30);
            checkedListBoxSpecialties.Name = "checkedListBoxSpecialties";
            checkedListBoxSpecialties.Size = new Size(218, 224);
            checkedListBoxSpecialties.TabIndex = 15;
            // 
            // groupBoxSchedules
            // 
            groupBoxSchedules.Controls.Add(labelDay);
            groupBoxSchedules.Controls.Add(comboBoxDayOfWeek);
            groupBoxSchedules.Controls.Add(labelStartTime);
            groupBoxSchedules.Controls.Add(dateTimePickerStartTime);
            groupBoxSchedules.Controls.Add(labelEndTime);
            groupBoxSchedules.Controls.Add(dateTimePickerEndTime);
            groupBoxSchedules.Controls.Add(buttonAddSchedule);
            groupBoxSchedules.Controls.Add(buttonRemoveSchedule);
            groupBoxSchedules.Controls.Add(dataGridViewSchedules);
            groupBoxSchedules.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            groupBoxSchedules.Location = new Point(611, 10);
            groupBoxSchedules.Name = "groupBoxSchedules";
            groupBoxSchedules.Size = new Size(534, 287);
            groupBoxSchedules.TabIndex = 16;
            groupBoxSchedules.TabStop = false;
            groupBoxSchedules.Text = "Disponibilidad Horaria Semanal";
            // 
            // labelDay
            // 
            labelDay.AutoSize = true;
            labelDay.Location = new Point(6, 23);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(36, 20);
            labelDay.TabIndex = 0;
            labelDay.Text = "Día:";
            // 
            // comboBoxDayOfWeek
            // 
            comboBoxDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDayOfWeek.Font = new Font("Segoe UI", 9F);
            comboBoxDayOfWeek.Location = new Point(48, 18);
            comboBoxDayOfWeek.Name = "comboBoxDayOfWeek";
            comboBoxDayOfWeek.Size = new Size(95, 28);
            comboBoxDayOfWeek.TabIndex = 1;
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Location = new Point(149, 24);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(32, 20);
            labelStartTime.TabIndex = 2;
            labelStartTime.Text = "De:";
            // 
            // dateTimePickerStartTime
            // 
            dateTimePickerStartTime.Font = new Font("Segoe UI", 9F);
            dateTimePickerStartTime.Location = new Point(184, 20);
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.Size = new Size(85, 27);
            dateTimePickerStartTime.TabIndex = 3;
            // 
            // labelEndTime
            // 
            labelEndTime.AutoSize = true;
            labelEndTime.Location = new Point(275, 22);
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Size = new Size(24, 20);
            labelEndTime.TabIndex = 4;
            labelEndTime.Text = "A:";
            // 
            // dateTimePickerEndTime
            // 
            dateTimePickerEndTime.Font = new Font("Segoe UI", 9F);
            dateTimePickerEndTime.Location = new Point(305, 20);
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.Size = new Size(89, 27);
            dateTimePickerEndTime.TabIndex = 5;
            // 
            // buttonAddSchedule
            // 
            buttonAddSchedule.BackColor = Color.FromArgb(2, 132, 199);
            buttonAddSchedule.FlatAppearance.BorderSize = 0;
            buttonAddSchedule.FlatStyle = FlatStyle.Flat;
            buttonAddSchedule.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonAddSchedule.ForeColor = Color.White;
            buttonAddSchedule.Location = new Point(400, 18);
            buttonAddSchedule.Name = "buttonAddSchedule";
            buttonAddSchedule.Size = new Size(54, 29);
            buttonAddSchedule.TabIndex = 6;
            buttonAddSchedule.Text = "+";
            buttonAddSchedule.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveSchedule
            // 
            buttonRemoveSchedule.BackColor = Color.FromArgb(239, 68, 68);
            buttonRemoveSchedule.FlatAppearance.BorderSize = 0;
            buttonRemoveSchedule.FlatStyle = FlatStyle.Flat;
            buttonRemoveSchedule.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonRemoveSchedule.ForeColor = Color.White;
            buttonRemoveSchedule.Location = new Point(460, 18);
            buttonRemoveSchedule.Name = "buttonRemoveSchedule";
            buttonRemoveSchedule.Size = new Size(59, 29);
            buttonRemoveSchedule.TabIndex = 7;
            buttonRemoveSchedule.Text = "✕";
            buttonRemoveSchedule.UseVisualStyleBackColor = false;
            // 
            // dataGridViewSchedules
            // 
            dataGridViewSchedules.BackgroundColor = Color.White;
            dataGridViewSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedules.Location = new Point(10, 52);
            dataGridViewSchedules.Name = "dataGridViewSchedules";
            dataGridViewSchedules.RowHeadersWidth = 24;
            dataGridViewSchedules.Size = new Size(508, 218);
            dataGridViewSchedules.TabIndex = 8;
            // 
            // labelObservations
            // 
            labelObservations.AutoSize = true;
            labelObservations.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelObservations.Location = new Point(15, 277);
            labelObservations.Name = "labelObservations";
            labelObservations.Size = new Size(115, 20);
            labelObservations.TabIndex = 17;
            labelObservations.Text = "Observaciones:";
            // 
            // textBoxObservations
            // 
            textBoxObservations.BorderStyle = BorderStyle.FixedSingle;
            textBoxObservations.Font = new Font("Segoe UI", 9F);
            textBoxObservations.Location = new Point(135, 275);
            textBoxObservations.Name = "textBoxObservations";
            textBoxObservations.Size = new Size(321, 27);
            textBoxObservations.TabIndex = 18;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(1177, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Padding = new Padding(30, 0, 0, 0);
            buttonSave.Size = new Size(315, 53);
            buttonSave.TabIndex = 19;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdit.BackColor = Color.FromArgb(2, 132, 199);
            buttonEdit.Cursor = Cursors.Hand;
            buttonEdit.Enabled = false;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(1177, 73);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Padding = new Padding(30, 0, 0, 0);
            buttonEdit.Size = new Size(315, 52);
            buttonEdit.TabIndex = 20;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonToggleStatus
            // 
            buttonToggleStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            buttonToggleStatus.Cursor = Cursors.Hand;
            buttonToggleStatus.Enabled = false;
            buttonToggleStatus.FlatAppearance.BorderSize = 0;
            buttonToggleStatus.FlatStyle = FlatStyle.Flat;
            buttonToggleStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleStatus.ForeColor = Color.White;
            buttonToggleStatus.Location = new Point(1177, 132);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Padding = new Padding(30, 0, 0, 0);
            buttonToggleStatus.Size = new Size(315, 54);
            buttonToggleStatus.TabIndex = 21;
            buttonToggleStatus.Text = "ACTIVAR / PAUSAR";
            buttonToggleStatus.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Enabled = false;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(1177, 192);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Padding = new Padding(30, 0, 0, 0);
            buttonDelete.Size = new Size(315, 50);
            buttonDelete.TabIndex = 22;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(1177, 248);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(30, 0, 0, 0);
            buttonCancel.Size = new Size(315, 49);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "LIMPIAR CAMPOS";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormProfessionals
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1542, 896);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Name = "FormProfessionals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Profesionales - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfessionals).EndInit();
            panelSearchAndCount.ResumeLayout(false);
            panelSearchAndCount.PerformLayout();
            panelProfessionalForm.ResumeLayout(false);
            panelProfessionalForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).EndInit();
            groupBoxSchedules.ResumeLayout(false);
            groupBoxSchedules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedules).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelMain;
        private Panel panelProfessionalForm;
        private Label labelDocumentNumber;
        private TextBox textBoxDocumentNumber;
        private Label labelLicenseNumber;
        private TextBox textBoxLicenseNumber;
        private Label labelFirstName;
        private TextBox textBoxFirstName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelDuration;
        private NumericUpDown numericUpDownDuration;
        private Label labelSpecialties;
        private CheckedListBox checkedListBoxSpecialties;
        private GroupBox groupBoxSchedules;
        private Label labelDay;
        private ComboBox comboBoxDayOfWeek;
        private Label labelStartTime;
        private DateTimePicker dateTimePickerStartTime;
        private Label labelEndTime;
        private DateTimePicker dateTimePickerEndTime;
        private Button buttonAddSchedule;
        private Button buttonRemoveSchedule;
        private DataGridView dataGridViewSchedules;
        private Label labelObservations;
        private TextBox textBoxObservations;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonToggleStatus;
        private Button buttonDelete;
        private Button buttonCancel;
        private Panel panelSearchAndCount;
        private Label labelSearchPrompt;
        private TextBox textBoxSearch;
        private Label labelTotalProfessionals;
        private DataGridView dataGridViewProfessionals;
        private PictureBox picIconSave;
        private PictureBox picIconEdit;
        private PictureBox picIconToggleStatus;
        private PictureBox picIconDelete;
        private PictureBox picIconCancel;
        
    }
}