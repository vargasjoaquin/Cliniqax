namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormBlindCashCountDialog
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
            picIconConfirmClose = new PictureBox();
            picIconCancel = new PictureBox();
            labelHeaderTitle = new Label();
            labelInstructions = new Label();
            labelRealCashPrompt = new Label();
            numericUpDownRealCash = new NumericUpDown();
            labelNotesPrompt = new Label();
            textBoxNotes = new TextBox();
            buttonCancel = new Button();
            buttonConfirmClose = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconConfirmClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRealCash).BeginInit();
            SuspendLayout();
            // 
            // picIconConfirmClose
            // 
            picIconConfirmClose.BackColor = Color.FromArgb(239, 68, 68);
            picIconConfirmClose.Cursor = Cursors.Hand;
            picIconConfirmClose.Image = Icons.caja_arqueo_cierre_z;
            picIconConfirmClose.Location = new Point(310, 225);
            picIconConfirmClose.Name = "picIconConfirmClose";
            picIconConfirmClose.Size = new Size(24, 24);
            picIconConfirmClose.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirmClose.TabIndex = 99;
            picIconConfirmClose.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(155, 225);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(24, 24);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelHeaderTitle.Location = new Point(20, 15);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(300, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "ARQUEO CIEGO DE EFECTIVO";
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.Font = new Font("Segoe UI", 9F);
            labelInstructions.ForeColor = Color.FromArgb(100, 116, 139);
            labelInstructions.Location = new Point(20, 48);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(369, 20);
            labelInstructions.TabIndex = 1;
            labelInstructions.Text = "Cuente los billetes y monedas físicos e ingrese el total:";
            // 
            // labelRealCashPrompt
            // 
            labelRealCashPrompt.AutoSize = true;
            labelRealCashPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRealCashPrompt.Location = new Point(20, 80);
            labelRealCashPrompt.Name = "labelRealCashPrompt";
            labelRealCashPrompt.Size = new Size(287, 21);
            labelRealCashPrompt.TabIndex = 2;
            labelRealCashPrompt.Text = "Efectivo Real Contado en Gaveta ($):";
            // 
            // numericUpDownRealCash
            // 
            numericUpDownRealCash.DecimalPlaces = 2;
            numericUpDownRealCash.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            numericUpDownRealCash.Location = new Point(20, 105);
            numericUpDownRealCash.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownRealCash.Name = "numericUpDownRealCash";
            numericUpDownRealCash.Size = new Size(460, 39);
            numericUpDownRealCash.TabIndex = 3;
            // 
            // labelNotesPrompt
            // 
            labelNotesPrompt.AutoSize = true;
            labelNotesPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNotesPrompt.Location = new Point(20, 155);
            labelNotesPrompt.Name = "labelNotesPrompt";
            labelNotesPrompt.Size = new Size(258, 20);
            labelNotesPrompt.TabIndex = 4;
            labelNotesPrompt.Text = "Observaciones de Cierre (Opcional):";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Font = new Font("Segoe UI", 10F);
            textBoxNotes.Location = new Point(20, 178);
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.Size = new Size(460, 30);
            textBoxNotes.TabIndex = 5;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(145, 225);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(155, 40);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonConfirmClose
            // 
            buttonConfirmClose.BackColor = Color.FromArgb(239, 68, 68);
            buttonConfirmClose.Cursor = Cursors.Hand;
            buttonConfirmClose.FlatAppearance.BorderSize = 0;
            buttonConfirmClose.FlatStyle = FlatStyle.Flat;
            buttonConfirmClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonConfirmClose.ForeColor = Color.White;
            buttonConfirmClose.Location = new Point(310, 225);
            buttonConfirmClose.Name = "buttonConfirmClose";
            buttonConfirmClose.Padding = new Padding(24, 0, 0, 0);
            buttonConfirmClose.Size = new Size(170, 40);
            buttonConfirmClose.TabIndex = 7;
            buttonConfirmClose.Text = "CERRAR CAJA";
            buttonConfirmClose.UseVisualStyleBackColor = false;
            // 
            // FormBlindCashCountDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(500, 285);
            Controls.Add(picIconConfirmClose);
            Controls.Add(buttonConfirmClose);
            Controls.Add(picIconCancel);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxNotes);
            Controls.Add(labelNotesPrompt);
            Controls.Add(numericUpDownRealCash);
            Controls.Add(labelRealCashPrompt);
            Controls.Add(labelInstructions);
            Controls.Add(labelHeaderTitle);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBlindCashCountDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Arqueo y Cierre Definitivo de Caja (Z)";
            ((System.ComponentModel.ISupportInitialize)picIconConfirmClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRealCash).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picIconConfirmClose;
        private PictureBox picIconCancel;
        private Label labelHeaderTitle;
        private Label labelInstructions;
        private Label labelRealCashPrompt;
        private NumericUpDown numericUpDownRealCash;
        private Label labelNotesPrompt;
        private TextBox textBoxNotes;
        private Button buttonCancel;
        private Button buttonConfirmClose;
    }
}