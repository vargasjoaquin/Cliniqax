namespace CliniqaxSystem.WinFormsUI
{
    partial class FormPatients
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
            picIconExportPdf = new PictureBox();
            picIconExportExcel = new PictureBox();
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconDelete = new PictureBox();
            picIconCancel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportPdf = new Button();
            buttonExportExcel = new Button();
            panelMain = new Panel();
            dataGridViewPatients = new DataGridView();
            panelSearchAndCount = new Panel();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            labelTotalPatients = new Label();
            panelPatientForm = new Panel();
            labelDocumentNumber = new Label();
            textBoxDocumentNumber = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelBirthDate = new Label();
            dateTimePickerBirthDate = new DateTimePicker();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelCity = new Label();
            textBoxCity = new TextBox();
            labelHealthInsurance = new Label();
            comboBoxHealthInsurance = new ComboBox();
            labelAffiliateNumber = new Label();
            textBoxAffiliateNumber = new TextBox();
            labelAdministrativeNotes = new Label();
            textBoxAdministrativeNotes = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).BeginInit();
            panelSearchAndCount.SuspendLayout();
            panelPatientForm.SuspendLayout();
            SuspendLayout();
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Icons.action_exportar_pdf;
            picIconExportPdf.Location = new Point(892, 12);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(47, 63);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconExportExcel
            // 
            picIconExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            picIconExportExcel.Cursor = Cursors.Hand;
            picIconExportExcel.Image = Icons.action_exportar_excel;
            picIconExportExcel.Location = new Point(1083, 12);
            picIconExportExcel.Name = "picIconExportExcel";
            picIconExportExcel.Size = new Size(42, 63);
            picIconExportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportExcel.TabIndex = 99;
            picIconExportExcel.TabStop = false;
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(990, 16);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(56, 42);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(2, 132, 199);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Icons.action_editar;
            picIconEdit.Location = new Point(1011, 70);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(46, 42);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Icons.action_eliminar;
            picIconDelete.Location = new Point(998, 124);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(48, 42);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(981, 178);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(40, 42);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Controls.Add(picIconExportExcel);
            panelHeader.Controls.Add(buttonExportExcel);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1283, 87);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(262, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE PACIENTES";
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(892, 12);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Padding = new Padding(30, 0, 0, 0);
            buttonExportPdf.Size = new Size(181, 63);
            buttonExportPdf.TabIndex = 1;
            buttonExportPdf.Text = "EXPORTAR PDF";
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            buttonExportExcel.FlatAppearance.BorderSize = 0;
            buttonExportExcel.FlatStyle = FlatStyle.Flat;
            buttonExportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.White;
            buttonExportExcel.Location = new Point(1083, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Padding = new Padding(30, 0, 0, 0);
            buttonExportExcel.Size = new Size(185, 63);
            buttonExportExcel.TabIndex = 2;
            buttonExportExcel.Text = "EXPORTAR EXCEL";
            buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dataGridViewPatients);
            panelMain.Controls.Add(panelSearchAndCount);
            panelMain.Controls.Add(panelPatientForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 87);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 12, 16, 16);
            panelMain.Size = new Size(1283, 713);
            panelMain.TabIndex = 1;
            // 
            // dataGridViewPatients
            // 
            dataGridViewPatients.BackgroundColor = Color.White;
            dataGridViewPatients.BorderStyle = BorderStyle.None;
            dataGridViewPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPatients.Dock = DockStyle.Fill;
            dataGridViewPatients.Location = new Point(16, 298);
            dataGridViewPatients.Name = "dataGridViewPatients";
            dataGridViewPatients.RowHeadersWidth = 51;
            dataGridViewPatients.Size = new Size(1251, 399);
            dataGridViewPatients.TabIndex = 2;
            // 
            // panelSearchAndCount
            // 
            panelSearchAndCount.BackColor = Color.Transparent;
            panelSearchAndCount.Controls.Add(labelSearchPrompt);
            panelSearchAndCount.Controls.Add(textBoxSearch);
            panelSearchAndCount.Controls.Add(labelTotalPatients);
            panelSearchAndCount.Dock = DockStyle.Top;
            panelSearchAndCount.Location = new Point(16, 252);
            panelSearchAndCount.Name = "panelSearchAndCount";
            panelSearchAndCount.Size = new Size(1251, 46);
            panelSearchAndCount.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.ForeColor = Color.FromArgb(15, 23, 42);
            labelSearchPrompt.Location = new Point(6, 12);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(65, 21);
            labelSearchPrompt.TabIndex = 0;
            labelSearchPrompt.Text = "Buscar:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(77, 9);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Escriba DNI, apellido, nombre o teléfono...";
            textBoxSearch.Size = new Size(380, 30);
            textBoxSearch.TabIndex = 1;
            // 
            // labelTotalPatients
            // 
            labelTotalPatients.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTotalPatients.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalPatients.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalPatients.Location = new Point(933, 12);
            labelTotalPatients.Name = "labelTotalPatients";
            labelTotalPatients.Size = new Size(300, 21);
            labelTotalPatients.TabIndex = 2;
            labelTotalPatients.Text = "Pacientes Registrados: 0";
            labelTotalPatients.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelPatientForm
            // 
            panelPatientForm.BackColor = Color.White;
            panelPatientForm.Controls.Add(labelDocumentNumber);
            panelPatientForm.Controls.Add(textBoxDocumentNumber);
            panelPatientForm.Controls.Add(labelFirstName);
            panelPatientForm.Controls.Add(textBoxFirstName);
            panelPatientForm.Controls.Add(labelLastName);
            panelPatientForm.Controls.Add(textBoxLastName);
            panelPatientForm.Controls.Add(labelBirthDate);
            panelPatientForm.Controls.Add(dateTimePickerBirthDate);
            panelPatientForm.Controls.Add(labelPhone);
            panelPatientForm.Controls.Add(textBoxPhone);
            panelPatientForm.Controls.Add(labelEmail);
            panelPatientForm.Controls.Add(textBoxEmail);
            panelPatientForm.Controls.Add(labelAddress);
            panelPatientForm.Controls.Add(textBoxAddress);
            panelPatientForm.Controls.Add(labelCity);
            panelPatientForm.Controls.Add(textBoxCity);
            panelPatientForm.Controls.Add(labelHealthInsurance);
            panelPatientForm.Controls.Add(comboBoxHealthInsurance);
            panelPatientForm.Controls.Add(labelAffiliateNumber);
            panelPatientForm.Controls.Add(textBoxAffiliateNumber);
            panelPatientForm.Controls.Add(labelAdministrativeNotes);
            panelPatientForm.Controls.Add(textBoxAdministrativeNotes);
            panelPatientForm.Controls.Add(picIconSave);
            panelPatientForm.Controls.Add(buttonSave);
            panelPatientForm.Controls.Add(picIconEdit);
            panelPatientForm.Controls.Add(buttonEdit);
            panelPatientForm.Controls.Add(picIconDelete);
            panelPatientForm.Controls.Add(buttonDelete);
            panelPatientForm.Controls.Add(picIconCancel);
            panelPatientForm.Controls.Add(buttonCancel);
            panelPatientForm.Dock = DockStyle.Top;
            panelPatientForm.Location = new Point(16, 12);
            panelPatientForm.Name = "panelPatientForm";
            panelPatientForm.Size = new Size(1251, 240);
            panelPatientForm.TabIndex = 0;
            // 
            // labelDocumentNumber
            // 
            labelDocumentNumber.AutoSize = true;
            labelDocumentNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDocumentNumber.Location = new Point(16, 12);
            labelDocumentNumber.Name = "labelDocumentNumber";
            labelDocumentNumber.Size = new Size(130, 20);
            labelDocumentNumber.TabIndex = 0;
            labelDocumentNumber.Text = "DNI/Documento:";
            // 
            // textBoxDocumentNumber
            // 
            textBoxDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBoxDocumentNumber.Location = new Point(16, 34);
            textBoxDocumentNumber.Name = "textBoxDocumentNumber";
            textBoxDocumentNumber.Size = new Size(140, 30);
            textBoxDocumentNumber.TabIndex = 1;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFirstName.Location = new Point(170, 12);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(71, 20);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(170, 34);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(170, 30);
            textBoxFirstName.TabIndex = 3;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLastName.Location = new Point(355, 12);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(71, 20);
            labelLastName.TabIndex = 4;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(355, 34);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(170, 30);
            textBoxLastName.TabIndex = 5;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBirthDate.Location = new Point(540, 12);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(138, 20);
            labelBirthDate.TabIndex = 6;
            labelBirthDate.Text = "Fecha Nacimiento:";
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBirthDate.Location = new Point(542, 34);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(149, 30);
            dateTimePickerBirthDate.TabIndex = 7;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPhone.Location = new Point(710, 12);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(74, 20);
            labelPhone.TabIndex = 8;
            labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(710, 35);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(160, 30);
            textBoxPhone.TabIndex = 9;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(16, 76);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(141, 20);
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(16, 98);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(220, 30);
            textBoxEmail.TabIndex = 11;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAddress.Location = new Point(250, 76);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(78, 20);
            labelAddress.TabIndex = 12;
            labelAddress.Text = "Dirección:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10F);
            textBoxAddress.Location = new Point(250, 98);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(240, 30);
            textBoxAddress.TabIndex = 13;
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCity.Location = new Point(505, 76);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(61, 20);
            labelCity.TabIndex = 14;
            labelCity.Text = "Ciudad:";
            // 
            // textBoxCity
            // 
            textBoxCity.BorderStyle = BorderStyle.FixedSingle;
            textBoxCity.Font = new Font("Segoe UI", 10F);
            textBoxCity.Location = new Point(505, 98);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(150, 30);
            textBoxCity.TabIndex = 15;
            // 
            // labelHealthInsurance
            // 
            labelHealthInsurance.AutoSize = true;
            labelHealthInsurance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHealthInsurance.Location = new Point(670, 76);
            labelHealthInsurance.Name = "labelHealthInsurance";
            labelHealthInsurance.Size = new Size(91, 20);
            labelHealthInsurance.TabIndex = 16;
            labelHealthInsurance.Text = "Obra Social:";
            // 
            // comboBoxHealthInsurance
            // 
            comboBoxHealthInsurance.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHealthInsurance.Font = new Font("Segoe UI", 10F);
            comboBoxHealthInsurance.Location = new Point(670, 98);
            comboBoxHealthInsurance.Name = "comboBoxHealthInsurance";
            comboBoxHealthInsurance.Size = new Size(200, 31);
            comboBoxHealthInsurance.TabIndex = 17;
            // 
            // labelAffiliateNumber
            // 
            labelAffiliateNumber.AutoSize = true;
            labelAffiliateNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAffiliateNumber.Location = new Point(16, 140);
            labelAffiliateNumber.Name = "labelAffiliateNumber";
            labelAffiliateNumber.Size = new Size(147, 20);
            labelAffiliateNumber.TabIndex = 18;
            labelAffiliateNumber.Text = "N.° Afiliado/Carnet:";
            // 
            // textBoxAffiliateNumber
            // 
            textBoxAffiliateNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxAffiliateNumber.Font = new Font("Segoe UI", 10F);
            textBoxAffiliateNumber.Location = new Point(16, 162);
            textBoxAffiliateNumber.Name = "textBoxAffiliateNumber";
            textBoxAffiliateNumber.Size = new Size(220, 30);
            textBoxAffiliateNumber.TabIndex = 19;
            // 
            // labelAdministrativeNotes
            // 
            labelAdministrativeNotes.AutoSize = true;
            labelAdministrativeNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAdministrativeNotes.Location = new Point(250, 140);
            labelAdministrativeNotes.Name = "labelAdministrativeNotes";
            labelAdministrativeNotes.Size = new Size(230, 20);
            labelAdministrativeNotes.TabIndex = 20;
            labelAdministrativeNotes.Text = "Observaciones Administrativas:";
            // 
            // textBoxAdministrativeNotes
            // 
            textBoxAdministrativeNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxAdministrativeNotes.Font = new Font("Segoe UI", 10F);
            textBoxAdministrativeNotes.Location = new Point(250, 162);
            textBoxAdministrativeNotes.Multiline = true;
            textBoxAdministrativeNotes.Name = "textBoxAdministrativeNotes";
            textBoxAdministrativeNotes.Size = new Size(620, 60);
            textBoxAdministrativeNotes.TabIndex = 21;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(918, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Padding = new Padding(30, 0, 0, 0);
            buttonSave.Size = new Size(315, 42);
            buttonSave.TabIndex = 22;
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
            buttonEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(918, 70);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Padding = new Padding(30, 0, 0, 0);
            buttonEdit.Size = new Size(315, 42);
            buttonEdit.TabIndex = 23;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Enabled = false;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(918, 124);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Padding = new Padding(30, 0, 0, 0);
            buttonDelete.Size = new Size(315, 42);
            buttonDelete.TabIndex = 24;
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
            buttonCancel.Location = new Point(918, 178);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(30, 0, 0, 0);
            buttonCancel.Size = new Size(315, 42);
            buttonCancel.TabIndex = 25;
            buttonCancel.Text = "LIMPIAR CAMPOS";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormPatients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1283, 800);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Name = "FormPatients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Padrón de Pacientes - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatients).EndInit();
            panelSearchAndCount.ResumeLayout(false);
            panelSearchAndCount.PerformLayout();
            panelPatientForm.ResumeLayout(false);
            panelPatientForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button buttonExportPdf;
        private Button buttonExportExcel;
        private Panel panelMain;
        private Panel panelPatientForm;
        private Label labelDocumentNumber;
        private TextBox textBoxDocumentNumber;
        private Label labelFirstName;
        private TextBox textBoxFirstName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelBirthDate;
        private DateTimePicker dateTimePickerBirthDate;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelCity;
        private TextBox textBoxCity;
        private Label labelHealthInsurance;
        private ComboBox comboBoxHealthInsurance;
        private Label labelAffiliateNumber;
        private TextBox textBoxAffiliateNumber;
        private Label labelAdministrativeNotes;
        private TextBox textBoxAdministrativeNotes;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonCancel;
        private Panel panelSearchAndCount;
        private Label labelSearchPrompt;
        private TextBox textBoxSearch;
        private Label labelTotalPatients;
        private DataGridView dataGridViewPatients;
        private PictureBox picIconExportPdf;
        private PictureBox picIconExportExcel;
        private PictureBox picIconSave;
        private PictureBox picIconEdit;
        private PictureBox picIconDelete;
        private PictureBox picIconCancel;
    }
}