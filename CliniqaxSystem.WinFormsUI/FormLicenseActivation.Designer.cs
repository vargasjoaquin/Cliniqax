namespace CliniqaxSystem.WinFormsUI
{
    partial class FormLicenseActivation
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
            panelCard = new Panel();
            labelTitle = new Label();
            labelReason = new Label();
            labelCuit = new Label();
            textBoxCuit = new TextBox();
            labelKey = new Label();
            panelKeyBoxes = new Panel();
            textBoxKey1 = new TextBox();
            labelH1 = new Label();
            textBoxKey2 = new TextBox();
            labelH2 = new Label();
            textBoxKey3 = new TextBox();
            labelH3 = new Label();
            textBoxKey4 = new TextBox();
            labelStatus = new Label();
            buttonActivate = new Button();
            buttonExit = new Button();
            panelCard.SuspendLayout();
            panelKeyBoxes.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(labelReason);
            panelCard.Controls.Add(labelCuit);
            panelCard.Controls.Add(textBoxCuit);
            panelCard.Controls.Add(labelKey);
            panelCard.Controls.Add(panelKeyBoxes);
            panelCard.Controls.Add(labelStatus);
            panelCard.Controls.Add(buttonActivate);
            panelCard.Controls.Add(buttonExit);
            panelCard.Location = new Point(20, 20);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 390);
            panelCard.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(460, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CLINIQAX — ACTIVACIÓN DE LICENCIA";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelReason
            // 
            labelReason.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelReason.ForeColor = Color.FromArgb(239, 68, 68);
            labelReason.Location = new Point(20, 52);
            labelReason.Name = "labelReason";
            labelReason.Size = new Size(460, 42);
            labelReason.TabIndex = 1;
            labelReason.Text = "Se requiere una clave de licencia activa para poder utilizar el sistema.";
            labelReason.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCuit.Location = new Point(30, 102);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(227, 21);
            labelCuit.TabIndex = 2;
            labelCuit.Text = "CUIT del Consultorio Titular:";
            // 
            // textBoxCuit
            // 
            textBoxCuit.Font = new Font("Consolas", 11F);
            textBoxCuit.Location = new Point(30, 126);
            textBoxCuit.MaxLength = 13;
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.PlaceholderText = "XX-XXXXXXXX-X";
            textBoxCuit.Size = new Size(440, 29);
            textBoxCuit.TabIndex = 3;
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelKey.Location = new Point(30, 168);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(145, 21);
            labelKey.TabIndex = 4;
            labelKey.Text = "Clave de Licencia:";
            // 
            // panelKeyBoxes
            // 
            panelKeyBoxes.Controls.Add(textBoxKey1);
            panelKeyBoxes.Controls.Add(labelH1);
            panelKeyBoxes.Controls.Add(textBoxKey2);
            panelKeyBoxes.Controls.Add(labelH2);
            panelKeyBoxes.Controls.Add(textBoxKey3);
            panelKeyBoxes.Controls.Add(labelH3);
            panelKeyBoxes.Controls.Add(textBoxKey4);
            panelKeyBoxes.Location = new Point(30, 192);
            panelKeyBoxes.Name = "panelKeyBoxes";
            panelKeyBoxes.Size = new Size(440, 40);
            panelKeyBoxes.TabIndex = 5;
            // 
            // textBoxKey1
            // 
            textBoxKey1.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey1.Location = new Point(0, 4);
            textBoxKey1.MaxLength = 29;
            textBoxKey1.Name = "textBoxKey1";
            textBoxKey1.Size = new Size(95, 31);
            textBoxKey1.TabIndex = 0;
            textBoxKey1.TextAlign = HorizontalAlignment.Center;
            // 
            // labelH1
            // 
            labelH1.AutoSize = true;
            labelH1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelH1.ForeColor = Color.FromArgb(100, 116, 139);
            labelH1.Location = new Point(102, 5);
            labelH1.Name = "labelH1";
            labelH1.Size = new Size(20, 28);
            labelH1.TabIndex = 1;
            labelH1.Text = "-";
            // 
            // textBoxKey2
            // 
            textBoxKey2.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey2.Location = new Point(125, 4);
            textBoxKey2.MaxLength = 29;
            textBoxKey2.Name = "textBoxKey2";
            textBoxKey2.Size = new Size(95, 31);
            textBoxKey2.TabIndex = 2;
            textBoxKey2.TextAlign = HorizontalAlignment.Center;
            // 
            // labelH2
            // 
            labelH2.AutoSize = true;
            labelH2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelH2.ForeColor = Color.FromArgb(100, 116, 139);
            labelH2.Location = new Point(227, 5);
            labelH2.Name = "labelH2";
            labelH2.Size = new Size(20, 28);
            labelH2.TabIndex = 3;
            labelH2.Text = "-";
            // 
            // textBoxKey3
            // 
            textBoxKey3.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey3.Location = new Point(250, 4);
            textBoxKey3.MaxLength = 29;
            textBoxKey3.Name = "textBoxKey3";
            textBoxKey3.Size = new Size(95, 31);
            textBoxKey3.TabIndex = 4;
            textBoxKey3.TextAlign = HorizontalAlignment.Center;
            // 
            // labelH3
            // 
            labelH3.AutoSize = true;
            labelH3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelH3.ForeColor = Color.FromArgb(100, 116, 139);
            labelH3.Location = new Point(352, 5);
            labelH3.Name = "labelH3";
            labelH3.Size = new Size(20, 28);
            labelH3.TabIndex = 5;
            labelH3.Text = "-";
            // 
            // textBoxKey4
            // 
            textBoxKey4.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey4.Location = new Point(375, 4);
            textBoxKey4.MaxLength = 29;
            textBoxKey4.Name = "textBoxKey4";
            textBoxKey4.Size = new Size(65, 31);
            textBoxKey4.TabIndex = 6;
            textBoxKey4.TextAlign = HorizontalAlignment.Center;
            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Segoe UI", 8.5F);
            labelStatus.ForeColor = Color.FromArgb(100, 116, 139);
            labelStatus.Location = new Point(30, 240);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(440, 36);
            labelStatus.TabIndex = 6;
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonActivate
            // 
            buttonActivate.BackColor = Color.FromArgb(16, 185, 129);
            buttonActivate.Cursor = Cursors.Hand;
            buttonActivate.FlatAppearance.BorderSize = 0;
            buttonActivate.FlatStyle = FlatStyle.Flat;
            buttonActivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonActivate.ForeColor = Color.White;
            buttonActivate.Location = new Point(30, 285);
            buttonActivate.Name = "buttonActivate";
            buttonActivate.Size = new Size(440, 46);
            buttonActivate.TabIndex = 7;
            buttonActivate.Text = "ACTIVAR EN LÍNEA";
            buttonActivate.UseVisualStyleBackColor = false;
            // 
            // buttonExit
            // 
            buttonExit.Cursor = Cursors.Hand;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonExit.Location = new Point(30, 338);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(440, 32);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "CERRAR SISTEMA";
            buttonExit.UseVisualStyleBackColor = true;
            // 
            // FormLicenseActivation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(540, 430);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLicenseActivation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activación de Licencia";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            panelKeyBoxes.ResumeLayout(false);
            panelKeyBoxes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Label labelTitle;
        private Label labelReason;
        private Label labelCuit;
        private TextBox textBoxCuit;
        private Label labelKey;
        private Panel panelKeyBoxes;
        private TextBox textBoxKey1;
        private Label labelH1;
        private TextBox textBoxKey2;
        private Label labelH2;
        private TextBox textBoxKey3;
        private Label labelH3;
        private TextBox textBoxKey4;
        private Label labelStatus;
        private Button buttonActivate;
        private Button buttonExit;
    }
}