namespace CliniqaxSystem.WinFormsUI
{
    partial class FormSettings
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
            picIconSaveSettings = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelSettingsCard = new Panel();
            labelClinicName = new Label();
            textBoxClinicName = new TextBox();
            labelCuit = new Label();
            textBoxCuit = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelFooterMessage = new Label();
            textBoxFooterMessage = new TextBox();
            checkBoxShowLogo = new CheckBox();
            checkBoxAutoPrint = new CheckBox();
            labelLogoPrompt = new Label();
            pictureBoxLogo = new PictureBox();
            buttonBrowseLogo = new Button();
            buttonClearLogo = new Button();
            buttonSaveSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSaveSettings).BeginInit();
            panelHeader.SuspendLayout();
            panelSettingsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // picIconSaveSettings
            // 
            picIconSaveSettings.BackColor = Color.FromArgb(16, 185, 129);
            picIconSaveSettings.Cursor = Cursors.Hand;
            picIconSaveSettings.Image = Icons.action_guardar;
            picIconSaveSettings.Location = new Point(312, 470);
            picIconSaveSettings.Name = "picIconSaveSettings";
            picIconSaveSettings.Size = new Size(46, 52);
            picIconSaveSettings.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveSettings.TabIndex = 99;
            picIconSaveSettings.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(486, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "DATOS INSTITUCIONALES Y CONFIGURACIÓN";
            // 
            // panelSettingsCard
            // 
            panelSettingsCard.BackColor = Color.White;
            panelSettingsCard.Controls.Add(labelClinicName);
            panelSettingsCard.Controls.Add(textBoxClinicName);
            panelSettingsCard.Controls.Add(labelCuit);
            panelSettingsCard.Controls.Add(textBoxCuit);
            panelSettingsCard.Controls.Add(labelAddress);
            panelSettingsCard.Controls.Add(textBoxAddress);
            panelSettingsCard.Controls.Add(labelPhone);
            panelSettingsCard.Controls.Add(textBoxPhone);
            panelSettingsCard.Controls.Add(labelEmail);
            panelSettingsCard.Controls.Add(textBoxEmail);
            panelSettingsCard.Controls.Add(labelFooterMessage);
            panelSettingsCard.Controls.Add(textBoxFooterMessage);
            panelSettingsCard.Controls.Add(checkBoxShowLogo);
            panelSettingsCard.Controls.Add(checkBoxAutoPrint);
            panelSettingsCard.Controls.Add(labelLogoPrompt);
            panelSettingsCard.Controls.Add(pictureBoxLogo);
            panelSettingsCard.Controls.Add(buttonBrowseLogo);
            panelSettingsCard.Controls.Add(buttonClearLogo);
            panelSettingsCard.Controls.Add(picIconSaveSettings);
            panelSettingsCard.Controls.Add(buttonSaveSettings);
            panelSettingsCard.Location = new Point(24, 76);
            panelSettingsCard.Name = "panelSettingsCard";
            panelSettingsCard.Padding = new Padding(24);
            panelSettingsCard.Size = new Size(950, 545);
            panelSettingsCard.TabIndex = 1;
            // 
            // labelClinicName
            // 
            labelClinicName.AutoSize = true;
            labelClinicName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelClinicName.Location = new Point(24, 16);
            labelClinicName.Name = "labelClinicName";
            labelClinicName.Size = new Size(241, 20);
            labelClinicName.TabIndex = 0;
            labelClinicName.Text = "Nombre del Consultorio / Clínica:";
            // 
            // textBoxClinicName
            // 
            textBoxClinicName.BorderStyle = BorderStyle.FixedSingle;
            textBoxClinicName.Font = new Font("Segoe UI", 10F);
            textBoxClinicName.Location = new Point(24, 38);
            textBoxClinicName.MaxLength = 100;
            textBoxClinicName.Name = "textBoxClinicName";
            textBoxClinicName.Size = new Size(450, 30);
            textBoxClinicName.TabIndex = 1;
            // 
            // labelCuit
            // 
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCuit.Location = new Point(24, 78);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(95, 20);
            labelCuit.TabIndex = 2;
            labelCuit.Text = "CUIT Oficial:";
            // 
            // textBoxCuit
            // 
            textBoxCuit.BorderStyle = BorderStyle.FixedSingle;
            textBoxCuit.Font = new Font("Segoe UI", 10F);
            textBoxCuit.Location = new Point(24, 100);
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.Size = new Size(450, 30);
            textBoxCuit.TabIndex = 3;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelAddress.Location = new Point(24, 140);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(151, 20);
            labelAddress.TabIndex = 4;
            labelAddress.Text = "Dirección Comercial:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10F);
            textBoxAddress.Location = new Point(24, 162);
            textBoxAddress.MaxLength = 150;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(450, 30);
            textBoxAddress.TabIndex = 5;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPhone.Location = new Point(24, 202);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(162, 20);
            labelPhone.TabIndex = 6;
            labelPhone.Text = "Teléfono de Contacto:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(24, 224);
            textBoxPhone.MaxLength = 30;
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(450, 30);
            textBoxPhone.TabIndex = 7;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelEmail.Location = new Point(24, 264);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(141, 20);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(24, 286);
            textBoxEmail.MaxLength = 100;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(450, 30);
            textBoxEmail.TabIndex = 9;
            // 
            // labelFooterMessage
            // 
            labelFooterMessage.AutoSize = true;
            labelFooterMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFooterMessage.Location = new Point(24, 326);
            labelFooterMessage.Name = "labelFooterMessage";
            labelFooterMessage.Size = new Size(188, 20);
            labelFooterMessage.TabIndex = 10;
            labelFooterMessage.Text = "Mensaje al Pie del Recibo:";
            // 
            // textBoxFooterMessage
            // 
            textBoxFooterMessage.BorderStyle = BorderStyle.FixedSingle;
            textBoxFooterMessage.Font = new Font("Segoe UI", 10F);
            textBoxFooterMessage.Location = new Point(24, 348);
            textBoxFooterMessage.MaxLength = 250;
            textBoxFooterMessage.Multiline = true;
            textBoxFooterMessage.Name = "textBoxFooterMessage";
            textBoxFooterMessage.Size = new Size(450, 60);
            textBoxFooterMessage.TabIndex = 11;
            // 
            // checkBoxShowLogo
            // 
            checkBoxShowLogo.AutoSize = true;
            checkBoxShowLogo.Checked = true;
            checkBoxShowLogo.CheckState = CheckState.Checked;
            checkBoxShowLogo.Font = new Font("Segoe UI", 9F);
            checkBoxShowLogo.Location = new Point(24, 420);
            checkBoxShowLogo.Name = "checkBoxShowLogo";
            checkBoxShowLogo.Size = new Size(253, 24);
            checkBoxShowLogo.TabIndex = 12;
            checkBoxShowLogo.Text = "Imprimir Logo en Recibo Térmico";
            checkBoxShowLogo.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoPrint
            // 
            checkBoxAutoPrint.AutoSize = true;
            checkBoxAutoPrint.Font = new Font("Segoe UI", 9F);
            checkBoxAutoPrint.Location = new Point(285, 420);
            checkBoxAutoPrint.Name = "checkBoxAutoPrint";
            checkBoxAutoPrint.Size = new Size(230, 24);
            checkBoxAutoPrint.TabIndex = 13;
            checkBoxAutoPrint.Text = "Impresión Automática Directa";
            checkBoxAutoPrint.UseVisualStyleBackColor = true;
            checkBoxAutoPrint.CheckedChanged += checkBoxAutoPrint_CheckedChanged;
            // 
            // labelLogoPrompt
            // 
            labelLogoPrompt.AutoSize = true;
            labelLogoPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLogoPrompt.Location = new Point(520, 16);
            labelLogoPrompt.Name = "labelLogoPrompt";
            labelLogoPrompt.Size = new Size(139, 20);
            labelLogoPrompt.TabIndex = 14;
            labelLogoPrompt.Text = "Logo Institucional:";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxLogo.Location = new Point(520, 38);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(390, 304);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 15;
            pictureBoxLogo.TabStop = false;
            // 
            // buttonBrowseLogo
            // 
            buttonBrowseLogo.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowseLogo.FlatAppearance.BorderSize = 0;
            buttonBrowseLogo.FlatStyle = FlatStyle.Flat;
            buttonBrowseLogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonBrowseLogo.ForeColor = Color.White;
            buttonBrowseLogo.Location = new Point(520, 348);
            buttonBrowseLogo.Name = "buttonBrowseLogo";
            buttonBrowseLogo.Size = new Size(200, 60);
            buttonBrowseLogo.TabIndex = 16;
            buttonBrowseLogo.Text = "SELECCIONAR LOGO";
            buttonBrowseLogo.UseVisualStyleBackColor = false;
            // 
            // buttonClearLogo
            // 
            buttonClearLogo.BackColor = Color.FromArgb(239, 68, 68);
            buttonClearLogo.FlatAppearance.BorderSize = 0;
            buttonClearLogo.FlatStyle = FlatStyle.Flat;
            buttonClearLogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearLogo.ForeColor = Color.White;
            buttonClearLogo.Location = new Point(730, 348);
            buttonClearLogo.Name = "buttonClearLogo";
            buttonClearLogo.Size = new Size(180, 60);
            buttonClearLogo.TabIndex = 17;
            buttonClearLogo.Text = "QUITAR LOGO";
            buttonClearLogo.UseVisualStyleBackColor = false;
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.BackColor = Color.FromArgb(16, 185, 129);
            buttonSaveSettings.Cursor = Cursors.Hand;
            buttonSaveSettings.FlatAppearance.BorderSize = 0;
            buttonSaveSettings.FlatStyle = FlatStyle.Flat;
            buttonSaveSettings.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            buttonSaveSettings.ForeColor = Color.White;
            buttonSaveSettings.Location = new Point(24, 470);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Padding = new Padding(30, 0, 0, 0);
            buttonSaveSettings.Size = new Size(886, 52);
            buttonSaveSettings.TabIndex = 18;
            buttonSaveSettings.Text = "GUARDAR CONFIGURACIÓN";
            buttonSaveSettings.UseVisualStyleBackColor = false;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1000, 645);
            Controls.Add(panelSettingsCard);
            Controls.Add(panelHeader);
            Name = "FormSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración del Consultorio - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSaveSettings).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSettingsCard.ResumeLayout(false);
            panelSettingsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelSettingsCard;
        private Label labelClinicName;
        private TextBox textBoxClinicName;
        private Label labelCuit;
        private TextBox textBoxCuit;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelFooterMessage;
        private TextBox textBoxFooterMessage;
        private CheckBox checkBoxShowLogo;
        private CheckBox checkBoxAutoPrint;
        private Label labelLogoPrompt;
        private PictureBox pictureBoxLogo;
        private Button buttonBrowseLogo;
        private Button buttonClearLogo;
        private Button buttonSaveSettings;
        private PictureBox picIconSaveSettings;
    }
}