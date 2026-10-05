namespace CliniqaxSystem.WinFormsUI
{
    partial class FormHealthInsurances
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
            labelCuit = new Label();
            textBoxCuit = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonToggleStatus = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            dataGridViewInsurances = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInsurances).BeginInit();
            SuspendLayout();
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Icons.action_guardar;
            picIconSave.Location = new Point(107, 270);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(39, 42);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(2, 132, 199);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Icons.action_editar;
            picIconEdit.Location = new Point(117, 322);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(40, 42);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconToggleStatus
            // 
            picIconToggleStatus.BackColor = Color.FromArgb(245, 158, 11);
            picIconToggleStatus.Cursor = Cursors.Hand;
            picIconToggleStatus.Image = Icons.action_activar_desactivar;
            picIconToggleStatus.Location = new Point(66, 374);
            picIconToggleStatus.Name = "picIconToggleStatus";
            picIconToggleStatus.Size = new Size(45, 42);
            picIconToggleStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleStatus.TabIndex = 99;
            picIconToggleStatus.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Icons.action_eliminar;
            picIconDelete.Location = new Point(108, 426);
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
            picIconCancel.Location = new Point(81, 478);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(39, 42);
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
            panelHeader.Size = new Size(1150, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(481, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CATÁLOGO DE OBRAS SOCIALES Y PREPAGAS";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelName);
            panelCard.Controls.Add(textBoxName);
            panelCard.Controls.Add(labelCuit);
            panelCard.Controls.Add(textBoxCuit);
            panelCard.Controls.Add(labelPhone);
            panelCard.Controls.Add(textBoxPhone);
            panelCard.Controls.Add(labelEmail);
            panelCard.Controls.Add(textBoxEmail);
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
            panelCard.Size = new Size(350, 550);
            panelCard.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelName.Location = new Point(16, 12);
            labelName.Name = "labelName";
            labelName.Size = new Size(189, 21);
            labelName.TabIndex = 0;
            labelName.Text = "Razón Social / Nombre:";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Segoe UI", 10F);
            textBoxName.Location = new Point(16, 34);
            textBoxName.MaxLength = 100;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(316, 30);
            textBoxName.TabIndex = 1;
            // 
            // labelCuit
            // 
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCuit.Location = new Point(16, 76);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(104, 21);
            labelCuit.TabIndex = 2;
            labelCuit.Text = "CUIT Oficial:";
            // 
            // textBoxCuit
            // 
            textBoxCuit.BorderStyle = BorderStyle.FixedSingle;
            textBoxCuit.Font = new Font("Segoe UI", 10F);
            textBoxCuit.Location = new Point(16, 98);
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.Size = new Size(316, 30);
            textBoxCuit.TabIndex = 3;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPhone.Location = new Point(16, 140);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(162, 21);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Teléfono Autorizac.:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(16, 162);
            textBoxPhone.MaxLength = 30;
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(316, 30);
            textBoxPhone.TabIndex = 5;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(16, 204);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(16, 226);
            textBoxEmail.MaxLength = 100;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(316, 30);
            textBoxEmail.TabIndex = 7;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(16, 270);
            buttonSave.Name = "buttonSave";
            buttonSave.Padding = new Padding(24, 0, 0, 0);
            buttonSave.Size = new Size(316, 42);
            buttonSave.TabIndex = 8;
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
            buttonEdit.Location = new Point(16, 322);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Padding = new Padding(24, 0, 0, 0);
            buttonEdit.Size = new Size(316, 42);
            buttonEdit.TabIndex = 9;
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
            buttonToggleStatus.Location = new Point(16, 374);
            buttonToggleStatus.Name = "buttonToggleStatus";
            buttonToggleStatus.Padding = new Padding(24, 0, 0, 0);
            buttonToggleStatus.Size = new Size(316, 42);
            buttonToggleStatus.TabIndex = 10;
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
            buttonDelete.Location = new Point(16, 426);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Padding = new Padding(24, 0, 0, 0);
            buttonDelete.Size = new Size(316, 42);
            buttonDelete.TabIndex = 11;
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
            buttonCancel.Location = new Point(16, 478);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Padding = new Padding(24, 0, 0, 0);
            buttonCancel.Size = new Size(316, 42);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "LIMPIAR CAMPOS";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewInsurances
            // 
            dataGridViewInsurances.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInsurances.BackgroundColor = Color.White;
            dataGridViewInsurances.BorderStyle = BorderStyle.None;
            dataGridViewInsurances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInsurances.Location = new Point(385, 72);
            dataGridViewInsurances.Name = "dataGridViewInsurances";
            dataGridViewInsurances.RowHeadersWidth = 51;
            dataGridViewInsurances.Size = new Size(745, 550);
            dataGridViewInsurances.TabIndex = 2;
            // 
            // FormHealthInsurances
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1150, 645);
            Controls.Add(dataGridViewInsurances);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Name = "FormHealthInsurances";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo de Obras Sociales - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInsurances).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelCard;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelCuit;
        private TextBox textBoxCuit;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonToggleStatus;
        private Button buttonDelete;
        private Button buttonCancel;
        private DataGridView dataGridViewInsurances;
        private PictureBox picIconSave;
        private PictureBox picIconEdit;
        private PictureBox picIconToggleStatus;
        private PictureBox picIconDelete;
        private PictureBox picIconCancel;
    }
}