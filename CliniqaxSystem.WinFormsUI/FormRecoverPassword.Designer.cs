namespace CliniqaxSystem.WinFormsUI
{
    partial class FormRecoverPassword
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
            picIconSendRecovery = new PictureBox();
            picIconCancel = new PictureBox();
            panelCard = new Panel();
            labelMainTitle = new Label();
            labelInstructions = new Label();
            textBoxIdentity = new TextBox();
            buttonSendRecovery = new Button();
            buttonCancel = new Button();
            labelResultStatus = new Label();
            buttonCloseDialog = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSendRecovery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // picIconSendRecovery
            // 
            picIconSendRecovery.BackColor = Color.FromArgb(2, 132, 199);
            picIconSendRecovery.Cursor = Cursors.Hand;
            picIconSendRecovery.Image = Icons.status_atendido;
            picIconSendRecovery.Location = new Point(148, 165);
            picIconSendRecovery.Name = "picIconSendRecovery";
            picIconSendRecovery.Size = new Size(42, 57);
            picIconSendRecovery.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSendRecovery.TabIndex = 99;
            picIconSendRecovery.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(150, 228);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(40, 49);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelMainTitle);
            panelCard.Controls.Add(labelInstructions);
            panelCard.Controls.Add(textBoxIdentity);
            panelCard.Controls.Add(picIconSendRecovery);
            panelCard.Controls.Add(buttonSendRecovery);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Controls.Add(labelResultStatus);
            panelCard.Location = new Point(24, 30);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(430, 360);
            panelCard.TabIndex = 1;
            // 
            // labelMainTitle
            // 
            labelMainTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelMainTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelMainTitle.Location = new Point(20, 20);
            labelMainTitle.Name = "labelMainTitle";
            labelMainTitle.Size = new Size(390, 28);
            labelMainTitle.TabIndex = 0;
            labelMainTitle.Text = "RECUPERAR CONTRASEÑA";
            labelMainTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelInstructions
            // 
            labelInstructions.Font = new Font("Segoe UI", 9F);
            labelInstructions.ForeColor = Color.FromArgb(100, 116, 139);
            labelInstructions.Location = new Point(24, 60);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(380, 45);
            labelInstructions.TabIndex = 1;
            labelInstructions.Text = "Ingrese su nombre de usuario o correo electrónico registrado para generar su clave temporal:";
            // 
            // textBoxIdentity
            // 
            textBoxIdentity.BorderStyle = BorderStyle.FixedSingle;
            textBoxIdentity.Font = new Font("Segoe UI", 10.5F);
            textBoxIdentity.Location = new Point(24, 115);
            textBoxIdentity.Name = "textBoxIdentity";
            textBoxIdentity.PlaceholderText = "Usuario o correo electrónico...";
            textBoxIdentity.Size = new Size(380, 31);
            textBoxIdentity.TabIndex = 2;
            // 
            // buttonSendRecovery
            // 
            buttonSendRecovery.BackColor = Color.FromArgb(2, 132, 199);
            buttonSendRecovery.Cursor = Cursors.Hand;
            buttonSendRecovery.FlatAppearance.BorderSize = 0;
            buttonSendRecovery.FlatStyle = FlatStyle.Flat;
            buttonSendRecovery.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSendRecovery.ForeColor = Color.White;
            buttonSendRecovery.Location = new Point(24, 165);
            buttonSendRecovery.Name = "buttonSendRecovery";
            buttonSendRecovery.Padding = new Padding(24, 0, 0, 0);
            buttonSendRecovery.Size = new Size(380, 57);
            buttonSendRecovery.TabIndex = 3;
            buttonSendRecovery.Text = "ENVIAR";
            buttonSendRecovery.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(24, 228);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(22, 0, 0, 0);
            buttonCancel.Size = new Size(380, 49);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "VOLVER";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // labelResultStatus
            // 
            labelResultStatus.AutoEllipsis = true;
            labelResultStatus.Font = new Font("Segoe UI", 8.5F);
            labelResultStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelResultStatus.Location = new Point(24, 289);
            labelResultStatus.Name = "labelResultStatus";
            labelResultStatus.Size = new Size(380, 56);
            labelResultStatus.TabIndex = 5;
            labelResultStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonCloseDialog
            // 
            buttonCloseDialog.Cursor = Cursors.Hand;
            buttonCloseDialog.FlatAppearance.BorderSize = 0;
            buttonCloseDialog.FlatStyle = FlatStyle.Flat;
            buttonCloseDialog.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonCloseDialog.ForeColor = Color.White;
            buttonCloseDialog.Location = new Point(440, 4);
            buttonCloseDialog.Name = "buttonCloseDialog";
            buttonCloseDialog.Size = new Size(34, 28);
            buttonCloseDialog.TabIndex = 0;
            buttonCloseDialog.Text = "✕";
            buttonCloseDialog.UseVisualStyleBackColor = true;
            // 
            // FormRecoverPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(480, 420);
            Controls.Add(buttonCloseDialog);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRecoverPassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recuperar Contraseña";
            ((System.ComponentModel.ISupportInitialize)picIconSendRecovery).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Label labelMainTitle;
        private Label labelInstructions;
        private TextBox textBoxIdentity;
        private Button buttonSendRecovery;
        private Button buttonCancel;
        private Label labelResultStatus;
        private Button buttonCloseDialog;
        private PictureBox picIconSendRecovery;
        private PictureBox picIconCancel;
    }
}