namespace CliniqaxSystem.WinFormsUI
{
    partial class FormUserProfile
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
            picIconSaveChanges = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelProfileCard = new Panel();
            pictureBoxAvatar = new PictureBox();
            buttonBrowsePhoto = new Button();
            buttonClearPhoto = new Button();
            labelFullNameDisplay = new Label();
            labelRoleBadge = new Label();
            labelUsernameDisplay = new Label();
            labelEmailDisplay = new Label();
            panelEditCard = new Panel();
            labelSectionTitle = new Label();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelCurrentPassword = new Label();
            textBoxCurrentPassword = new TextBox();
            labelNewPassword = new Label();
            textBoxNewPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSaveChanges).BeginInit();
            panelHeader.SuspendLayout();
            panelProfileCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            panelEditCard.SuspendLayout();
            SuspendLayout();
            // 
            // picIconSaveChanges
            // 
            picIconSaveChanges.BackColor = Color.FromArgb(2, 132, 199);
            picIconSaveChanges.Cursor = Cursors.Hand;
            picIconSaveChanges.Image = Icons.action_guardar;
            picIconSaveChanges.Location = new Point(160, 415);
            picIconSaveChanges.Name = "picIconSaveChanges";
            picIconSaveChanges.Size = new Size(46, 48);
            picIconSaveChanges.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveChanges.TabIndex = 99;
            picIconSaveChanges.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(950, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(253, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MI PERFIL DE USUARIO";
            // 
            // panelProfileCard
            // 
            panelProfileCard.BackColor = Color.White;
            panelProfileCard.Controls.Add(pictureBoxAvatar);
            panelProfileCard.Controls.Add(buttonBrowsePhoto);
            panelProfileCard.Controls.Add(buttonClearPhoto);
            panelProfileCard.Controls.Add(labelFullNameDisplay);
            panelProfileCard.Controls.Add(labelRoleBadge);
            panelProfileCard.Controls.Add(labelUsernameDisplay);
            panelProfileCard.Controls.Add(labelEmailDisplay);
            panelProfileCard.Location = new Point(24, 76);
            panelProfileCard.Name = "panelProfileCard";
            panelProfileCard.Padding = new Padding(16);
            panelProfileCard.Size = new Size(320, 500);
            panelProfileCard.TabIndex = 1;
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxAvatar.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAvatar.Location = new Point(65, 20);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(190, 190);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // buttonBrowsePhoto
            // 
            buttonBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowsePhoto.FlatAppearance.BorderSize = 0;
            buttonBrowsePhoto.FlatStyle = FlatStyle.Flat;
            buttonBrowsePhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonBrowsePhoto.ForeColor = Color.White;
            buttonBrowsePhoto.Location = new Point(65, 220);
            buttonBrowsePhoto.Name = "buttonBrowsePhoto";
            buttonBrowsePhoto.Size = new Size(130, 32);
            buttonBrowsePhoto.TabIndex = 1;
            buttonBrowsePhoto.Text = "CAMBIAR FOTO";
            buttonBrowsePhoto.UseVisualStyleBackColor = false;
            // 
            // buttonClearPhoto
            // 
            buttonClearPhoto.BackColor = Color.FromArgb(239, 68, 68);
            buttonClearPhoto.FlatAppearance.BorderSize = 0;
            buttonClearPhoto.FlatStyle = FlatStyle.Flat;
            buttonClearPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearPhoto.ForeColor = Color.White;
            buttonClearPhoto.Location = new Point(205, 220);
            buttonClearPhoto.Name = "buttonClearPhoto";
            buttonClearPhoto.Size = new Size(50, 32);
            buttonClearPhoto.TabIndex = 2;
            buttonClearPhoto.Text = "✕";
            buttonClearPhoto.UseVisualStyleBackColor = false;
            // 
            // labelFullNameDisplay
            // 
            labelFullNameDisplay.AutoEllipsis = true;
            labelFullNameDisplay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelFullNameDisplay.ForeColor = Color.FromArgb(15, 23, 42);
            labelFullNameDisplay.Location = new Point(10, 270);
            labelFullNameDisplay.Name = "labelFullNameDisplay";
            labelFullNameDisplay.Size = new Size(300, 30);
            labelFullNameDisplay.TabIndex = 3;
            labelFullNameDisplay.Text = "Nombre Completo";
            labelFullNameDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelRoleBadge
            // 
            labelRoleBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRoleBadge.ForeColor = Color.FromArgb(2, 132, 199);
            labelRoleBadge.Location = new Point(10, 300);
            labelRoleBadge.Name = "labelRoleBadge";
            labelRoleBadge.Size = new Size(300, 22);
            labelRoleBadge.TabIndex = 4;
            labelRoleBadge.Text = "[ADMINISTRADOR]";
            labelRoleBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUsernameDisplay
            // 
            labelUsernameDisplay.Font = new Font("Segoe UI", 8.5F);
            labelUsernameDisplay.ForeColor = Color.FromArgb(100, 116, 139);
            labelUsernameDisplay.Location = new Point(10, 335);
            labelUsernameDisplay.Name = "labelUsernameDisplay";
            labelUsernameDisplay.Size = new Size(300, 20);
            labelUsernameDisplay.TabIndex = 5;
            labelUsernameDisplay.Text = "Usuario: @admin";
            labelUsernameDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEmailDisplay
            // 
            labelEmailDisplay.Font = new Font("Segoe UI", 8.5F);
            labelEmailDisplay.ForeColor = Color.FromArgb(100, 116, 139);
            labelEmailDisplay.Location = new Point(10, 360);
            labelEmailDisplay.Name = "labelEmailDisplay";
            labelEmailDisplay.Size = new Size(300, 20);
            labelEmailDisplay.TabIndex = 6;
            labelEmailDisplay.Text = "admin@cliniqax.com";
            labelEmailDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelEditCard
            // 
            panelEditCard.BackColor = Color.White;
            panelEditCard.Controls.Add(labelSectionTitle);
            panelEditCard.Controls.Add(labelFirstName);
            panelEditCard.Controls.Add(textBoxFirstName);
            panelEditCard.Controls.Add(labelLastName);
            panelEditCard.Controls.Add(textBoxLastName);
            panelEditCard.Controls.Add(labelEmail);
            panelEditCard.Controls.Add(textBoxEmail);
            panelEditCard.Controls.Add(labelCurrentPassword);
            panelEditCard.Controls.Add(textBoxCurrentPassword);
            panelEditCard.Controls.Add(labelNewPassword);
            panelEditCard.Controls.Add(textBoxNewPassword);
            panelEditCard.Controls.Add(labelConfirmPassword);
            panelEditCard.Controls.Add(textBoxConfirmPassword);
            panelEditCard.Controls.Add(picIconSaveChanges);
            panelEditCard.Controls.Add(buttonSaveChanges);
            panelEditCard.Location = new Point(365, 76);
            panelEditCard.Name = "panelEditCard";
            panelEditCard.Padding = new Padding(24);
            panelEditCard.Size = new Size(560, 500);
            panelEditCard.TabIndex = 2;
            // 
            // labelSectionTitle
            // 
            labelSectionTitle.AutoSize = true;
            labelSectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSectionTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelSectionTitle.Location = new Point(24, 16);
            labelSectionTitle.Name = "labelSectionTitle";
            labelSectionTitle.Size = new Size(205, 28);
            labelSectionTitle.TabIndex = 0;
            labelSectionTitle.Text = "Modificar Mis Datos";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFirstName.Location = new Point(24, 60);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(71, 20);
            labelFirstName.TabIndex = 1;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10F);
            textBoxFirstName.Location = new Point(24, 82);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(240, 30);
            textBoxFirstName.TabIndex = 2;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLastName.Location = new Point(290, 60);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(71, 20);
            labelLastName.TabIndex = 3;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10F);
            textBoxLastName.Location = new Point(290, 82);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(240, 30);
            textBoxLastName.TabIndex = 4;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(24, 130);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(141, 20);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(24, 152);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(506, 30);
            textBoxEmail.TabIndex = 6;
            // 
            // labelCurrentPassword
            // 
            labelCurrentPassword.AutoSize = true;
            labelCurrentPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCurrentPassword.Location = new Point(24, 205);
            labelCurrentPassword.Name = "labelCurrentPassword";
            labelCurrentPassword.Size = new Size(403, 20);
            labelCurrentPassword.TabIndex = 7;
            labelCurrentPassword.Text = "Contraseña Actual (requerida solo si va a cambiar clave):";
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxCurrentPassword.Font = new Font("Segoe UI", 10F);
            textBoxCurrentPassword.Location = new Point(24, 227);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.PasswordChar = '●';
            textBoxCurrentPassword.Size = new Size(506, 30);
            textBoxCurrentPassword.TabIndex = 8;
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNewPassword.Location = new Point(24, 280);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(141, 20);
            labelNewPassword.TabIndex = 9;
            labelNewPassword.Text = "Nueva Contraseña:";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxNewPassword.Font = new Font("Segoe UI", 10F);
            textBoxNewPassword.Location = new Point(24, 302);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '●';
            textBoxNewPassword.Size = new Size(240, 30);
            textBoxNewPassword.TabIndex = 10;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelConfirmPassword.Location = new Point(290, 280);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(216, 20);
            labelConfirmPassword.TabIndex = 11;
            labelConfirmPassword.Text = "Confirmar Nueva Contraseña:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxConfirmPassword.Font = new Font("Segoe UI", 10F);
            textBoxConfirmPassword.Location = new Point(290, 302);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '●';
            textBoxConfirmPassword.Size = new Size(240, 30);
            textBoxConfirmPassword.TabIndex = 12;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.BackColor = Color.FromArgb(2, 132, 199);
            buttonSaveChanges.Cursor = Cursors.Hand;
            buttonSaveChanges.FlatAppearance.BorderSize = 0;
            buttonSaveChanges.FlatStyle = FlatStyle.Flat;
            buttonSaveChanges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSaveChanges.ForeColor = Color.White;
            buttonSaveChanges.Location = new Point(24, 415);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Padding = new Padding(30, 0, 0, 0);
            buttonSaveChanges.Size = new Size(506, 48);
            buttonSaveChanges.TabIndex = 13;
            buttonSaveChanges.Text = "GUARDAR CAMBIOS";
            buttonSaveChanges.UseVisualStyleBackColor = false;
            // 
            // FormUserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(950, 600);
            Controls.Add(panelEditCard);
            Controls.Add(panelProfileCard);
            Controls.Add(panelHeader);
            Name = "FormUserProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mi Perfil - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSaveChanges).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelProfileCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            panelEditCard.ResumeLayout(false);
            panelEditCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelProfileCard;
        private PictureBox pictureBoxAvatar;
        private Button buttonBrowsePhoto;
        private Button buttonClearPhoto;
        private Label labelFullNameDisplay;
        private Label labelRoleBadge;
        private Label labelUsernameDisplay;
        private Label labelEmailDisplay;
        private Panel panelEditCard;
        private Label labelSectionTitle;
        private Label labelFirstName;
        private TextBox textBoxFirstName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelCurrentPassword;
        private TextBox textBoxCurrentPassword;
        private Label labelNewPassword;
        private TextBox textBoxNewPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonSaveChanges;
        private PictureBox picIconSaveChanges;
    }
}
