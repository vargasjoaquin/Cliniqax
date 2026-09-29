namespace CliniqaxSystem.WinFormsUI
{
    partial class FormLogin
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
            picIconLogin = new PictureBox();
            panelLoginCard = new Panel();
            pictureBoxLogo = new PictureBox();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelErrorMessage = new Label();
            buttonLogin = new Button();
            buttonClose = new Button();
            linkLabelForgotPassword = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)picIconLogin).BeginInit();
            panelLoginCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // picIconLogin
            // 
            picIconLogin.BackColor = Color.FromArgb(2, 132, 199);
            picIconLogin.Cursor = Cursors.Hand;
            picIconLogin.Image = Icons.status_atendido;
            picIconLogin.Location = new Point(66, 325);
            picIconLogin.Name = "picIconLogin";
            picIconLogin.Size = new Size(42, 50);
            picIconLogin.SizeMode = PictureBoxSizeMode.Zoom;
            picIconLogin.TabIndex = 99;
            picIconLogin.TabStop = false;
            // 
            // panelLoginCard
            // 
            panelLoginCard.BackColor = Color.White;
            panelLoginCard.Controls.Add(pictureBoxLogo);
            panelLoginCard.Controls.Add(labelUsername);
            panelLoginCard.Controls.Add(textBoxUsername);
            panelLoginCard.Controls.Add(labelPassword);
            panelLoginCard.Controls.Add(textBoxPassword);
            panelLoginCard.Controls.Add(labelErrorMessage);
            panelLoginCard.Controls.Add(picIconLogin);
            panelLoginCard.Controls.Add(buttonLogin);
            panelLoginCard.Location = new Point(35, 45);
            panelLoginCard.Name = "panelLoginCard";
            panelLoginCard.Size = new Size(390, 440);
            panelLoginCard.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Icons.logo_cliniqax;
            pictureBoxLogo.Location = new Point(30, 20);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(330, 85);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(15, 23, 42);
            labelUsername.Location = new Point(30, 130);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(73, 21);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 11F);
            textBoxUsername.Location = new Point(30, 155);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(330, 32);
            textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(15, 23, 42);
            labelPassword.Location = new Point(30, 205);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 21);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(30, 230);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(330, 32);
            textBoxPassword.TabIndex = 4;
            // 
            // labelErrorMessage
            // 
            labelErrorMessage.Font = new Font("Segoe UI", 8.5F);
            labelErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            labelErrorMessage.Location = new Point(30, 275);
            labelErrorMessage.Name = "labelErrorMessage";
            labelErrorMessage.Size = new Size(330, 38);
            labelErrorMessage.TabIndex = 5;
            labelErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            labelErrorMessage.Visible = false;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(2, 132, 199);
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(30, 325);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Padding = new Padding(30, 0, 0, 0);
            buttonLogin.Size = new Size(330, 50);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "INGRESAR AL SISTEMA";
            buttonLogin.UseVisualStyleBackColor = false;
            // 
            // buttonClose
            // 
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(415, 8);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(36, 32);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "✕";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // linkLabelForgotPassword
            // 
            linkLabelForgotPassword.Font = new Font("Segoe UI", 9F);
            linkLabelForgotPassword.LinkColor = Color.FromArgb(2, 132, 199);
            linkLabelForgotPassword.Location = new Point(30, 390);
            linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            linkLabelForgotPassword.Size = new Size(330, 24);
            linkLabelForgotPassword.TabIndex = 8;
            linkLabelForgotPassword.TabStop = true;
            linkLabelForgotPassword.Text = "¿Olvidó su contraseña?";
            linkLabelForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(460, 520);
            Controls.Add(buttonClose);
            Controls.Add(panelLoginCard);
            panelLoginCard.Controls.Add(linkLabelForgotPassword);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconLogin).EndInit();
            panelLoginCard.ResumeLayout(false);
            panelLoginCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLoginCard;
        private PictureBox pictureBoxLogo;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelErrorMessage;
        private Button buttonLogin;
        private Button buttonClose;
        private PictureBox picIconLogin;
        private LinkLabel linkLabelForgotPassword;
    }
}