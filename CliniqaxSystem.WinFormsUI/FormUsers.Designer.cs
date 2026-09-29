namespace CliniqaxSystem.WinFormsUI
{
    partial class FormUsers
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
            dataGridViewUsers = new DataGridView();
            panelUserForm = new Panel();
            pictureBoxUserPhoto = new PictureBox();
            buttonBrowsePhoto = new Button();
            buttonClearPhoto = new Button();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonTogglePasswordVisibility = new Button();
            labelRole = new Label();
            comboBoxRole = new ComboBox();
            labelProfessionalLink = new Label();
            comboBoxProfessional = new ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            panelUserForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserPhoto).BeginInit();
            SuspendLayout();
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(1011, 10);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(35, 42);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(2, 132, 199);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Icons.action_editar;
            picIconEdit.Location = new Point(1020, 62);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(38, 42);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconToggleStatus
            // 
            picIconToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            picIconToggleStatus.Cursor = Cursors.Hand;
            picIconToggleStatus.Image = Icons.action_activar_desactivar;
            picIconToggleStatus.Location = new Point(972, 114);
            picIconToggleStatus.Name = "picIconToggleStatus";
            picIconToggleStatus.Size = new Size(43, 42);
            picIconToggleStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleStatus.TabIndex = 99;
            picIconToggleStatus.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Icons.action_eliminar;
            picIconDelete.Location = new Point(1020, 166);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(38, 42);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(988, 218);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(38, 42);
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
            panelHeader.Size = new Size(1280, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 17);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(399, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE USUARIOS DEL SISTEMA";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dataGridViewUsers);
            panelMain.Controls.Add(panelUserForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 12, 16, 16);
            panelMain.Size = new Size(1280, 740);
            panelMain.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(16, 292);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(1248, 432);
            dataGridViewUsers.TabIndex = 1;
            // 
            // panelUserForm
            // 
            panelUserForm.BackColor = Color.White;
            panelUserForm.Controls.Add(pictureBoxUserPhoto);
            panelUserForm.Controls.Add(buttonBrowsePhoto);
            panelUserForm.Controls.Add(buttonClearPhoto);
            panelUserForm.Controls.Add(labelUsername);
            panelUserForm.Controls.Add(textBoxUsername);
            panelUserForm.Controls.Add(labelFirstName);
            panelUserForm.Controls.Add(textBoxFirstName);
            panelUserForm.Controls.Add(labelLastName);
            panelUserForm.Controls.Add(textBoxLastName);
            panelUserForm.Controls.Add(labelEmail);
            panelUserForm.Controls.Add(textBoxEmail);
            panelUserForm.Controls.Add(labelPassword);
            panelUserForm.Controls.Add(textBoxPassword);
            panelUserForm.Controls.Add(buttonTogglePasswordVisibility);
            panelUserForm.Controls.Add(labelRole);
            panelUserForm.Controls.Add(comboBoxRole);
            panelUserForm.Controls.Add(labelProfessionalLink);
            panelUserForm.Controls.Add(comboBoxProfessional);
            panelUserForm.Controls.Add(picIconSave);
            panelUserForm.Controls.Add(buttonSave);
            panelUserForm.Controls.Add(picIconEdit);
            panelUserForm.Controls.Add(buttonEdit);
            panelUserForm.Controls.Add(picIconToggleStatus);
            panelUserForm.Controls.Add(buttonToggleStatus);
            panelUserForm.Controls.Add(picIconDelete);
            panelUserForm.Controls.Add(buttonDelete);
            panelUserForm.Controls.Add(picIconCancel);
            panelUserForm.Controls.Add(buttonCancel);
            panelUserForm.Dock = DockStyle.Top;
            panelUserForm.Location = new Point(16, 12);
            panelUserForm.Name = "panelUserForm";
            panelUserForm.Size = new Size(1248, 280);
            panelUserForm.TabIndex = 0;
            // 
            // pictureBoxUserPhoto
            // 
            pictureBoxUserPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxUserPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxUserPhoto.Location = new Point(16, 16);
            pictureBoxUserPhoto.Name = "pictureBoxUserPhoto";
            pictureBoxUserPhoto.Size = new Size(160, 165);
            pictureBoxUserPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserPhoto.TabIndex = 0;
            pictureBoxUserPhoto.TabStop = false;
            // 
            // buttonBrowsePhoto
            // 
            buttonBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowsePhoto.FlatAppearance.BorderSize = 0;
            buttonBrowsePhoto.FlatStyle = FlatStyle.Flat;
            buttonBrowsePhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonBrowsePhoto.ForeColor = Color.White;
            buttonBrowsePhoto.Location = new Point(16, 190);
            buttonBrowsePhoto.Name = "buttonBrowsePhoto";
            buttonBrowsePhoto.Size = new Size(100, 58);
            buttonBrowsePhoto.TabIndex = 1;
            buttonBrowsePhoto.Text = "SUBIR FOTO";
            buttonBrowsePhoto.UseVisualStyleBackColor = false;
            // 
            // buttonClearPhoto
            // 
            buttonClearPhoto.BackColor = Color.FromArgb(239, 68, 68);
            buttonClearPhoto.FlatAppearance.BorderSize = 0;
            buttonClearPhoto.FlatStyle = FlatStyle.Flat;
            buttonClearPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearPhoto.ForeColor = Color.White;
            buttonClearPhoto.Location = new Point(122, 190);
            buttonClearPhoto.Name = "buttonClearPhoto";
            buttonClearPhoto.Size = new Size(54, 58);
            buttonClearPhoto.TabIndex = 2;
            buttonClearPhoto.Text = "✕";
            buttonClearPhoto.UseVisualStyleBackColor = false;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelUsername.Location = new Point(195, 12);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(67, 20);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBoxUsername.Location = new Point(195, 34);
            textBoxUsername.MaxLength = 50;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(210, 30);
            textBoxUsername.TabIndex = 4;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFirstName.Location = new Point(195, 78);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(71, 20);
            labelFirstName.TabIndex = 5;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(195, 100);
            textBoxFirstName.MaxLength = 50;
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(210, 30);
            textBoxFirstName.TabIndex = 6;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLastName.Location = new Point(425, 78);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(71, 20);
            labelLastName.TabIndex = 7;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(425, 100);
            textBoxLastName.MaxLength = 50;
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(210, 30);
            textBoxLastName.TabIndex = 8;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(195, 144);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(141, 20);
            labelEmail.TabIndex = 9;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(195, 166);
            textBoxEmail.MaxLength = 100;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(440, 30);
            textBoxEmail.TabIndex = 10;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPassword.Location = new Point(425, 12);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(92, 20);
            labelPassword.TabIndex = 11;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 10F);
            textBoxPassword.Location = new Point(425, 34);
            textBoxPassword.MaxLength = 100;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(165, 30);
            textBoxPassword.TabIndex = 12;
            // 
            // buttonTogglePasswordVisibility
            // 
            buttonTogglePasswordVisibility.BackColor = Color.FromArgb(241, 245, 249);
            buttonTogglePasswordVisibility.FlatStyle = FlatStyle.Flat;
            buttonTogglePasswordVisibility.Font = new Font("Segoe UI", 10F);
            buttonTogglePasswordVisibility.Location = new Point(595, 34);
            buttonTogglePasswordVisibility.Name = "buttonTogglePasswordVisibility";
            buttonTogglePasswordVisibility.Size = new Size(40, 30);
            buttonTogglePasswordVisibility.TabIndex = 13;
            buttonTogglePasswordVisibility.Text = "👁";
            buttonTogglePasswordVisibility.UseVisualStyleBackColor = false;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRole.Location = new Point(655, 12);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(110, 20);
            labelRole.TabIndex = 14;
            labelRole.Text = "Rol de Acceso:";
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.Font = new Font("Segoe UI", 10F);
            comboBoxRole.Location = new Point(655, 34);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(240, 31);
            comboBoxRole.TabIndex = 15;
            // 
            // labelProfessionalLink
            // 
            labelProfessionalLink.AutoSize = true;
            labelProfessionalLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelProfessionalLink.Location = new Point(655, 78);
            labelProfessionalLink.Name = "labelProfessionalLink";
            labelProfessionalLink.Size = new Size(198, 20);
            labelProfessionalLink.TabIndex = 16;
            labelProfessionalLink.Text = "Vincular a Ficha de Médico:";
            // 
            // comboBoxProfessional
            // 
            comboBoxProfessional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfessional.Enabled = false;
            comboBoxProfessional.Font = new Font("Segoe UI", 10F);
            comboBoxProfessional.Location = new Point(655, 100);
            comboBoxProfessional.Name = "comboBoxProfessional";
            comboBoxProfessional.Size = new Size(240, 31);
            comboBoxProfessional.TabIndex = 17;
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
            buttonSave.Location = new Point(915, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Padding = new Padding(30, 0, 0, 0);
            buttonSave.Size = new Size(315, 42);
            buttonSave.TabIndex = 18;
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
            buttonEdit.Location = new Point(915, 62);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Padding = new Padding(30, 0, 0, 0);
            buttonEdit.Size = new Size(315, 42);
            buttonEdit.TabIndex = 19;
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
            buttonToggleStatus.Location = new Point(915, 114);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Padding = new Padding(30, 0, 0, 0);
            buttonToggleStatus.Size = new Size(315, 42);
            buttonToggleStatus.TabIndex = 20;
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
            buttonDelete.Location = new Point(915, 166);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Padding = new Padding(30, 0, 0, 0);
            buttonDelete.Size = new Size(315, 42);
            buttonDelete.TabIndex = 21;
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
            buttonCancel.Location = new Point(915, 218);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(30, 0, 0, 0);
            buttonCancel.Size = new Size(315, 42);
            buttonCancel.TabIndex = 22;
            buttonCancel.Text = "LIMPIAR CAMPOS";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 800);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            panelUserForm.ResumeLayout(false);
            panelUserForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelMain;
        private DataGridView dataGridViewUsers;
        private Panel panelUserForm;
        private PictureBox pictureBoxUserPhoto;
        private Button buttonBrowsePhoto;
        private Button buttonClearPhoto;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelFirstName;
        private TextBox textBoxFirstName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonTogglePasswordVisibility;
        private Label labelRole;
        private ComboBox comboBoxRole;
        private Label labelProfessionalLink;
        private ComboBox comboBoxProfessional;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonToggleStatus;
        private Button buttonDelete;
        private Button buttonCancel;
        private PictureBox picIconSave;
        private PictureBox picIconEdit;
        private PictureBox picIconToggleStatus;
        private PictureBox picIconDelete;
        private PictureBox picIconCancel;
    }
}