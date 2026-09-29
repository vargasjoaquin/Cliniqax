namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormLicenseWarningDialog
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
            labelHeader = new Label();
            labelWarningTitle = new Label();
            labelDetails = new Label();
            buttonRenew = new Button();
            buttonContinue = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(217, 119, 6);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(580, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeader.ForeColor = Color.White;
            labelHeader.Location = new Point(16, 14);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(369, 28);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "AVISO DE VENCIMIENTO DE LICENCIA";
            // 
            // labelWarningTitle
            // 
            labelWarningTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            labelWarningTitle.ForeColor = Color.FromArgb(180, 83, 9);
            labelWarningTitle.Location = new Point(20, 75);
            labelWarningTitle.Name = "labelWarningTitle";
            labelWarningTitle.Size = new Size(540, 26);
            labelWarningTitle.TabIndex = 1;
            labelWarningTitle.Text = "Su licencia está próxima a vencer.";
            // 
            // labelDetails
            // 
            labelDetails.Font = new Font("Segoe UI", 9F);
            labelDetails.ForeColor = Color.FromArgb(51, 65, 85);
            labelDetails.Location = new Point(20, 110);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(540, 100);
            labelDetails.TabIndex = 2;
            labelDetails.Text = "Detalles de la licencia...";
            // 
            // buttonRenew
            // 
            buttonRenew.Cursor = Cursors.Hand;
            buttonRenew.FlatStyle = FlatStyle.Flat;
            buttonRenew.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonRenew.Location = new Point(20, 230);
            buttonRenew.Name = "buttonRenew";
            buttonRenew.Size = new Size(200, 38);
            buttonRenew.TabIndex = 3;
            buttonRenew.Text = "RENOVAR CLAVE";
            buttonRenew.UseVisualStyleBackColor = true;
            // 
            // buttonContinue
            // 
            buttonContinue.BackColor = Color.FromArgb(2, 132, 199);
            buttonContinue.Cursor = Cursors.Hand;
            buttonContinue.FlatAppearance.BorderSize = 0;
            buttonContinue.FlatStyle = FlatStyle.Flat;
            buttonContinue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonContinue.ForeColor = Color.White;
            buttonContinue.Location = new Point(340, 230);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(220, 38);
            buttonContinue.TabIndex = 4;
            buttonContinue.Text = "CONTINUAR AL SISTEMA";
            buttonContinue.UseVisualStyleBackColor = false;
            // 
            // FormLicenseWarningDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(580, 290);
            Controls.Add(buttonContinue);
            Controls.Add(buttonRenew);
            Controls.Add(labelDetails);
            Controls.Add(labelWarningTitle);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLicenseWarningDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vencimiento de Licencia";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeader;
        private Label labelWarningTitle;
        private Label labelDetails;
        private Button buttonRenew;
        private Button buttonContinue;
    }
}