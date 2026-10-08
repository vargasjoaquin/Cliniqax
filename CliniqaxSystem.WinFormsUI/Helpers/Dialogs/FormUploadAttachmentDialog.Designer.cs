namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    partial class FormUploadAttachmentDialog
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
            labelHeaderTitle = new Label();
            panelCard = new Panel();
            labelFilePrompt = new Label();
            textBoxFileName = new TextBox();
            buttonBrowseFile = new Button();
            labelCategoryPrompt = new Label();
            comboBoxCategories = new ComboBox();
            labelNotesPrompt = new Label();
            textBoxNotes = new TextBox();
            picIconUpload = new PictureBox();
            buttonUpload = new Button();
            picIconCancel = new PictureBox();
            buttonCancel = new Button();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconUpload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(500, 50);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 14);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(262, 28);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "ADJUNTAR ESTUDIO MÉDICO";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelFilePrompt);
            panelCard.Controls.Add(textBoxFileName);
            panelCard.Controls.Add(buttonBrowseFile);
            panelCard.Controls.Add(labelCategoryPrompt);
            panelCard.Controls.Add(comboBoxCategories);
            panelCard.Controls.Add(labelNotesPrompt);
            panelCard.Controls.Add(textBoxNotes);
            panelCard.Controls.Add(picIconUpload);
            panelCard.Controls.Add(buttonUpload);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 62);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(468, 305);
            panelCard.TabIndex = 1;
            // 
            // labelFilePrompt
            // 
            labelFilePrompt.AutoSize = true;
            labelFilePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFilePrompt.Location = new Point(16, 12);
            labelFilePrompt.Name = "labelFilePrompt";
            labelFilePrompt.Size = new Size(189, 20);
            labelFilePrompt.TabIndex = 0;
            labelFilePrompt.Text = "Seleccionar Archivo Físico:";
            // 
            // textBoxFileName
            // 
            textBoxFileName.BackColor = Color.FromArgb(241, 245, 249);
            textBoxFileName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFileName.Font = new Font("Segoe UI", 9.5F);
            textBoxFileName.Location = new Point(16, 35);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.ReadOnly = true;
            textBoxFileName.Size = new Size(300, 29);
            textBoxFileName.TabIndex = 1;
            textBoxFileName.Text = "Ningún archivo seleccionado...";
            // 
            // buttonBrowseFile
            // 
            buttonBrowseFile.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowseFile.Cursor = Cursors.Hand;
            buttonBrowseFile.FlatAppearance.BorderSize = 0;
            buttonBrowseFile.FlatStyle = FlatStyle.Flat;
            buttonBrowseFile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonBrowseFile.ForeColor = Color.White;
            buttonBrowseFile.Location = new Point(322, 34);
            buttonBrowseFile.Name = "buttonBrowseFile";
            buttonBrowseFile.Size = new Size(130, 31);
            buttonBrowseFile.TabIndex = 2;
            buttonBrowseFile.Text = "EXAMINAR...";
            buttonBrowseFile.UseVisualStyleBackColor = false;
            // 
            // labelCategoryPrompt
            // 
            labelCategoryPrompt.AutoSize = true;
            labelCategoryPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCategoryPrompt.Location = new Point(16, 78);
            labelCategoryPrompt.Name = "labelCategoryPrompt";
            labelCategoryPrompt.Size = new Size(157, 20);
            labelCategoryPrompt.TabIndex = 3;
            labelCategoryPrompt.Text = "Categoría del Estudio:";
            // 
            // comboBoxCategories
            // 
            comboBoxCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategories.Font = new Font("Segoe UI", 9.5F);
            comboBoxCategories.Location = new Point(16, 101);
            comboBoxCategories.Name = "comboBoxCategories";
            comboBoxCategories.Size = new Size(436, 29);
            comboBoxCategories.TabIndex = 4;
            // 
            // labelNotesPrompt
            // 
            labelNotesPrompt.AutoSize = true;
            labelNotesPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNotesPrompt.Location = new Point(16, 142);
            labelNotesPrompt.Name = "labelNotesPrompt";
            labelNotesPrompt.Size = new Size(198, 20);
            labelNotesPrompt.TabIndex = 5;
            labelNotesPrompt.Text = "Observaciones / Descripción:";
            // 
            // textBoxNotes
            // 
            textBoxNotes.BorderStyle = BorderStyle.FixedSingle;
            textBoxNotes.Font = new Font("Segoe UI", 9.5F);
            textBoxNotes.Location = new Point(16, 165);
            textBoxNotes.MaxLength = 500;
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.PlaceholderText = "Detalle del estudio, centro de diagnóstico o informe...";
            textBoxNotes.Size = new Size(436, 60);
            textBoxNotes.TabIndex = 6;
            // 
            // picIconUpload
            // 
            picIconUpload.BackColor = Color.FromArgb(16, 185, 129);
            picIconUpload.Cursor = Cursors.Hand;
            picIconUpload.Image = Icons.action_guardar;
            picIconUpload.Location = new Point(252, 242);
            picIconUpload.Name = "picIconUpload";
            picIconUpload.Size = new Size(36, 42);
            picIconUpload.SizeMode = PictureBoxSizeMode.Zoom;
            picIconUpload.TabIndex = 99;
            picIconUpload.TabStop = false;
            // 
            // buttonUpload
            // 
            buttonUpload.BackColor = Color.FromArgb(16, 185, 129);
            buttonUpload.Cursor = Cursors.Hand;
            buttonUpload.Enabled = false;
            buttonUpload.FlatAppearance.BorderSize = 0;
            buttonUpload.FlatStyle = FlatStyle.Flat;
            buttonUpload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonUpload.ForeColor = Color.White;
            buttonUpload.Location = new Point(252, 242);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Padding = new Padding(24, 0, 0, 0);
            buttonUpload.Size = new Size(200, 46);
            buttonUpload.TabIndex = 7;
            buttonUpload.Text = "GUARDAR ESTUDIO";
            buttonUpload.UseVisualStyleBackColor = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(96, 242);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(36, 42);
            picIconCancel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancel.TabIndex = 99;
            picIconCancel.TabStop = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(96, 242);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(144, 46);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // FormUploadAttachmentDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(500, 385);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUploadAttachmentDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adjuntar Archivo Médico";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconUpload).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Panel panelCard;
        private Label labelFilePrompt;
        private TextBox textBoxFileName;
        private Button buttonBrowseFile;
        private Label labelCategoryPrompt;
        private ComboBox comboBoxCategories;
        private Label labelNotesPrompt;
        private TextBox textBoxNotes;
        private Button buttonUpload;
        private PictureBox picIconUpload;
        private Button buttonCancel;
        private PictureBox picIconCancel;
    }
}