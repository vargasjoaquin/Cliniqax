namespace CliniqaxSystem.WinFormsUI
{
    partial class FormSpecialties
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
            panelCard = new Panel();
            labelName = new Label();
            textBoxName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonToggleStatus = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            dataGridViewSpecialties = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecialties).BeginInit();
            SuspendLayout();
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(88, 222);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(52, 42);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(2, 132, 199);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Icons.action_editar;
            picIconEdit.Location = new Point(105, 274);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(46, 42);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconToggleStatus
            // 
            picIconToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            picIconToggleStatus.Cursor = Cursors.Hand;
            picIconToggleStatus.Image = Icons.action_activar_desactivar;
            picIconToggleStatus.Location = new Point(64, 326);
            picIconToggleStatus.Name = "picIconToggleStatus";
            picIconToggleStatus.Size = new Size(46, 42);
            picIconToggleStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleStatus.TabIndex = 99;
            picIconToggleStatus.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Icons.action_eliminar;
            picIconDelete.Location = new Point(94, 378);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(46, 42);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.White;
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.action_cancelar_volver;
            picIconCancel.Location = new Point(66, 430);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(44, 42);
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
            panelHeader.Size = new Size(1100, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(445, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CATÁLOGO DE ESPECIALIDADES MÉDICAS";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelName);
            panelCard.Controls.Add(textBoxName);
            panelCard.Controls.Add(labelDescription);
            panelCard.Controls.Add(textBoxDescription);
            panelCard.Controls.Add(picIconSave);
            panelCard.Controls.Add(buttonSave);
            panelCard.Controls.Add(picIconEdit);
            panelCard.Controls.Add(buttonEdit);
            panelCard.Controls.Add(picIconToggleStatus);
            panelCard.Controls.Add(buttonToggleStatus);
            panelCard.Controls.Add(picIconDelete);
            panelCard.Controls.Add(buttonDelete);
            panelCard.Controls.Add(picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 72);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(340, 500);
            panelCard.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelName.Location = new Point(16, 16);
            labelName.Name = "labelName";
            labelName.Size = new Size(200, 21);
            labelName.TabIndex = 0;
            labelName.Text = "Nombre de Especialidad:";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Segoe UI", 10F);
            textBoxName.Location = new Point(16, 38);
            textBoxName.MaxLength = 100;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(306, 30);
            textBoxName.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(16, 85);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 21);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Descripción:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(16, 107);
            textBoxDescription.MaxLength = 250;
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(306, 95);
            textBoxDescription.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(16, 222);
            buttonSave.Name = "buttonSave";
            buttonSave.Padding = new Padding(24, 0, 0, 0);
            buttonSave.Size = new Size(306, 42);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.FromArgb(2, 132, 199);
            buttonEdit.Cursor = Cursors.Hand;
            buttonEdit.Enabled = false;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(16, 274);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Padding = new Padding(24, 0, 0, 0);
            buttonEdit.Size = new Size(306, 42);
            buttonEdit.TabIndex = 5;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonToggleStatus
            // 
            buttonToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            buttonToggleStatus.Cursor = Cursors.Hand;
            buttonToggleStatus.Enabled = false;
            buttonToggleStatus.FlatAppearance.BorderSize = 0;
            buttonToggleStatus.FlatStyle = FlatStyle.Flat;
            buttonToggleStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleStatus.ForeColor = Color.White;
            buttonToggleStatus.Location = new Point(16, 326);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Padding = new Padding(24, 0, 0, 0);
            buttonToggleStatus.Size = new Size(306, 42);
            buttonToggleStatus.TabIndex = 6;
            buttonToggleStatus.Text = "ACTIVAR / PAUSAR";
            buttonToggleStatus.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Enabled = false;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(16, 378);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Padding = new Padding(24, 0, 0, 0);
            buttonDelete.Size = new Size(306, 42);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.ForeColor = Color.FromArgb(100, 116, 139);
            buttonCancel.Location = new Point(16, 430);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(306, 42);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "LIMPIAR CAMPOS";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewSpecialties
            // 
            dataGridViewSpecialties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSpecialties.BackgroundColor = Color.White;
            dataGridViewSpecialties.BorderStyle = BorderStyle.None;
            dataGridViewSpecialties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpecialties.Location = new Point(375, 72);
            dataGridViewSpecialties.Name = "dataGridViewSpecialties";
            dataGridViewSpecialties.RowHeadersWidth = 51;
            dataGridViewSpecialties.Size = new Size(705, 500);
            dataGridViewSpecialties.TabIndex = 2;
            // 
            // FormSpecialties
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1100, 595);
            Controls.Add(dataGridViewSpecialties);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Name = "FormSpecialties";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo de Especialidades - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecialties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelCard;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonToggleStatus;
        private Button buttonDelete;
        private Button buttonCancel;
        private DataGridView dataGridViewSpecialties;
        private PictureBox picIconSave;
        private PictureBox picIconEdit;
        private PictureBox picIconToggleStatus;
        private PictureBox picIconDelete;
        private PictureBox picIconCancel;
    }
}