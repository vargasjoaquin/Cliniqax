namespace CliniqaxSystem.WinFormsUI
{
    partial class FormAgenda
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
            picIconRefresh = new PictureBox();
            picIconBookSlot = new PictureBox();
            picIconConfirm = new PictureBox();
            picIconWaitingRoom = new PictureBox();
            picIconAttended = new PictureBox();
            picIconCancel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelFiltersCard = new Panel();
            labelProfessionalPrompt = new Label();
            comboBoxProfessionals = new ComboBox();
            labelDatePrompt = new Label();
            dateTimePickerDate = new DateTimePicker();
            buttonPrevDay = new Button();
            buttonToday = new Button();
            buttonNextDay = new Button();
            buttonRefresh = new Button();
            labelScheduleInfo = new Label();
            panelActionsCard = new Panel();
            labelSelectedSlotInfo = new Label();
            buttonBookSlot = new Button();
            buttonConfirmAppointment = new Button();
            buttonWaitingRoom = new Button();
            buttonMarkAttended = new Button();
            buttonCancelAppointment = new Button();
            dataGridViewAgenda = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconRefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconBookSlot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconWaitingRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconAttended).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            panelActionsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAgenda).BeginInit();
            SuspendLayout();
            // 
            // picIconRefresh
            // 
            picIconRefresh.BackColor = Color.White;
            picIconRefresh.Cursor = Cursors.Hand;
            picIconRefresh.Image = Icons.action_limpiar_busqueda;
            picIconRefresh.Location = new Point(760, 13);
            picIconRefresh.Name = "picIconRefresh";
            picIconRefresh.Size = new Size(44, 54);
            picIconRefresh.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRefresh.TabIndex = 99;
            picIconRefresh.TabStop = false;
            // 
            // picIconBookSlot
            // 
            picIconBookSlot.BackColor = Color.FromArgb(16, 185, 129);
            picIconBookSlot.Cursor = Cursors.Hand;
            picIconBookSlot.Image = Icons.action_guardar;
            picIconBookSlot.Location = new Point(415, 16);
            picIconBookSlot.Name = "picIconBookSlot";
            picIconBookSlot.Size = new Size(38, 47);
            picIconBookSlot.SizeMode = PictureBoxSizeMode.Zoom;
            picIconBookSlot.TabIndex = 99;
            picIconBookSlot.TabStop = false;
            // 
            // picIconConfirm
            // 
            picIconConfirm.BackColor = Color.FromArgb(2, 132, 199);
            picIconConfirm.Cursor = Cursors.Hand;
            picIconConfirm.Image = Icons.status_confirmado;
            picIconConfirm.Location = new Point(623, 16);
            picIconConfirm.Name = "picIconConfirm";
            picIconConfirm.Size = new Size(40, 47);
            picIconConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picIconConfirm.TabIndex = 99;
            picIconConfirm.TabStop = false;
            // 
            // picIconWaitingRoom
            // 
            picIconWaitingRoom.BackColor = Color.FromArgb(245, 158, 11);
            picIconWaitingRoom.Cursor = Cursors.Hand;
            picIconWaitingRoom.Image = Icons.status_en_sala_espera;
            picIconWaitingRoom.Location = new Point(791, 16);
            picIconWaitingRoom.Name = "picIconWaitingRoom";
            picIconWaitingRoom.Size = new Size(42, 47);
            picIconWaitingRoom.SizeMode = PictureBoxSizeMode.Zoom;
            picIconWaitingRoom.TabIndex = 99;
            picIconWaitingRoom.TabStop = false;
            // 
            // picIconAttended
            // 
            picIconAttended.BackColor = Color.FromArgb(15, 23, 42);
            picIconAttended.Cursor = Cursors.Hand;
            picIconAttended.Image = Icons.status_atendido;
            picIconAttended.Location = new Point(954, 16);
            picIconAttended.Name = "picIconAttended";
            picIconAttended.Size = new Size(41, 47);
            picIconAttended.SizeMode = PictureBoxSizeMode.Zoom;
            picIconAttended.TabIndex = 99;
            picIconAttended.TabStop = false;
            // 
            // picIconCancel
            // 
            picIconCancel.BackColor = Color.FromArgb(239, 68, 68);
            picIconCancel.Cursor = Cursors.Hand;
            picIconCancel.Image = Icons.status_cancelado;
            picIconCancel.Location = new Point(1116, 16);
            picIconCancel.Name = "picIconCancel";
            picIconCancel.Size = new Size(43, 48);
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
            panelHeader.Size = new Size(1278, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(277, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "AGENDA MÉDICA VISUAL";
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelProfessionalPrompt);
            panelFiltersCard.Controls.Add(comboBoxProfessionals);
            panelFiltersCard.Controls.Add(labelDatePrompt);
            panelFiltersCard.Controls.Add(dateTimePickerDate);
            panelFiltersCard.Controls.Add(buttonPrevDay);
            panelFiltersCard.Controls.Add(buttonToday);
            panelFiltersCard.Controls.Add(buttonNextDay);
            panelFiltersCard.Controls.Add(picIconRefresh);
            panelFiltersCard.Controls.Add(buttonRefresh);
            panelFiltersCard.Controls.Add(labelScheduleInfo);
            panelFiltersCard.Dock = DockStyle.Top;
            panelFiltersCard.Location = new Point(0, 56);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Padding = new Padding(16, 10, 16, 10);
            panelFiltersCard.Size = new Size(1278, 80);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelProfessionalPrompt
            // 
            labelProfessionalPrompt.AutoSize = true;
            labelProfessionalPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelProfessionalPrompt.Location = new Point(16, 8);
            labelProfessionalPrompt.Name = "labelProfessionalPrompt";
            labelProfessionalPrompt.Size = new Size(92, 20);
            labelProfessionalPrompt.TabIndex = 0;
            labelProfessionalPrompt.Text = "Profesional:";
            // 
            // comboBoxProfessionals
            // 
            comboBoxProfessionals.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfessionals.Font = new Font("Segoe UI", 10F);
            comboBoxProfessionals.Location = new Point(16, 29);
            comboBoxProfessionals.Name = "comboBoxProfessionals";
            comboBoxProfessionals.Size = new Size(260, 31);
            comboBoxProfessionals.TabIndex = 1;
            // 
            // labelDatePrompt
            // 
            labelDatePrompt.AutoSize = true;
            labelDatePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDatePrompt.Location = new Point(290, 8);
            labelDatePrompt.Name = "labelDatePrompt";
            labelDatePrompt.Size = new Size(53, 20);
            labelDatePrompt.TabIndex = 2;
            labelDatePrompt.Text = "Fecha:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(290, 29);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(130, 30);
            dateTimePickerDate.TabIndex = 3;
            // 
            // buttonPrevDay
            // 
            buttonPrevDay.FlatStyle = FlatStyle.Flat;
            buttonPrevDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonPrevDay.Location = new Point(430, 28);
            buttonPrevDay.Name = "buttonPrevDay";
            buttonPrevDay.Size = new Size(100, 32);
            buttonPrevDay.TabIndex = 4;
            buttonPrevDay.Text = "◀ Anterior";
            buttonPrevDay.UseVisualStyleBackColor = true;
            // 
            // buttonToday
            // 
            buttonToday.FlatStyle = FlatStyle.Flat;
            buttonToday.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToday.Location = new Point(535, 28);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new Size(70, 32);
            buttonToday.TabIndex = 5;
            buttonToday.Text = "Hoy";
            buttonToday.UseVisualStyleBackColor = true;
            // 
            // buttonNextDay
            // 
            buttonNextDay.FlatStyle = FlatStyle.Flat;
            buttonNextDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonNextDay.Location = new Point(610, 28);
            buttonNextDay.Name = "buttonNextDay";
            buttonNextDay.Size = new Size(100, 32);
            buttonNextDay.TabIndex = 6;
            buttonNextDay.Text = "Siguiente ▶";
            buttonNextDay.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonRefresh.Location = new Point(760, 13);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Padding = new Padding(26, 0, 0, 0);
            buttonRefresh.Size = new Size(170, 54);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.Text = "ACTUALIZAR";
            buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // labelScheduleInfo
            // 
            labelScheduleInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelScheduleInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelScheduleInfo.ForeColor = Color.FromArgb(2, 132, 199);
            labelScheduleInfo.Location = new Point(993, 29);
            labelScheduleInfo.Name = "labelScheduleInfo";
            labelScheduleInfo.Size = new Size(165, 22);
            labelScheduleInfo.TabIndex = 8;
            labelScheduleInfo.Text = "Cargando horarios...";
            labelScheduleInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelActionsCard
            // 
            panelActionsCard.BackColor = Color.White;
            panelActionsCard.Controls.Add(labelSelectedSlotInfo);
            panelActionsCard.Controls.Add(picIconBookSlot);
            panelActionsCard.Controls.Add(buttonBookSlot);
            panelActionsCard.Controls.Add(picIconConfirm);
            panelActionsCard.Controls.Add(buttonConfirmAppointment);
            panelActionsCard.Controls.Add(picIconWaitingRoom);
            panelActionsCard.Controls.Add(buttonWaitingRoom);
            panelActionsCard.Controls.Add(picIconAttended);
            panelActionsCard.Controls.Add(buttonMarkAttended);
            panelActionsCard.Controls.Add(picIconCancel);
            panelActionsCard.Controls.Add(buttonCancelAppointment);
            panelActionsCard.Dock = DockStyle.Bottom;
            panelActionsCard.Location = new Point(0, 705);
            panelActionsCard.Name = "panelActionsCard";
            panelActionsCard.Padding = new Padding(16, 8, 16, 8);
            panelActionsCard.Size = new Size(1278, 75);
            panelActionsCard.TabIndex = 2;
            // 
            // labelSelectedSlotInfo
            // 
            labelSelectedSlotInfo.AutoEllipsis = true;
            labelSelectedSlotInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSelectedSlotInfo.ForeColor = Color.FromArgb(15, 23, 42);
            labelSelectedSlotInfo.Location = new Point(16, 29);
            labelSelectedSlotInfo.Name = "labelSelectedSlotInfo";
            labelSelectedSlotInfo.Size = new Size(342, 24);
            labelSelectedSlotInfo.TabIndex = 0;
            labelSelectedSlotInfo.Text = "Haga clic en una franja horaria para operar.";
            // 
            // buttonBookSlot
            // 
            buttonBookSlot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBookSlot.BackColor = Color.FromArgb(16, 185, 129);
            buttonBookSlot.Cursor = Cursors.Hand;
            buttonBookSlot.Enabled = false;
            buttonBookSlot.FlatAppearance.BorderSize = 0;
            buttonBookSlot.FlatStyle = FlatStyle.Flat;
            buttonBookSlot.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonBookSlot.ForeColor = Color.White;
            buttonBookSlot.Location = new Point(413, 16);
            buttonBookSlot.Name = "buttonBookSlot";
            buttonBookSlot.Padding = new Padding(24, 0, 0, 0);
            buttonBookSlot.Size = new Size(190, 47);
            buttonBookSlot.TabIndex = 1;
            buttonBookSlot.Text = "RESERVAR TURNO";
            buttonBookSlot.UseVisualStyleBackColor = false;
            // 
            // buttonConfirmAppointment
            // 
            buttonConfirmAppointment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonConfirmAppointment.BackColor = Color.FromArgb(2, 132, 199);
            buttonConfirmAppointment.Cursor = Cursors.Hand;
            buttonConfirmAppointment.Enabled = false;
            buttonConfirmAppointment.FlatAppearance.BorderSize = 0;
            buttonConfirmAppointment.FlatStyle = FlatStyle.Flat;
            buttonConfirmAppointment.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonConfirmAppointment.ForeColor = Color.White;
            buttonConfirmAppointment.Location = new Point(621, 16);
            buttonConfirmAppointment.Name = "buttonConfirmAppointment";
            buttonConfirmAppointment.Padding = new Padding(22, 0, 0, 0);
            buttonConfirmAppointment.Size = new Size(152, 47);
            buttonConfirmAppointment.TabIndex = 2;
            buttonConfirmAppointment.Text = "CONFIRMAR";
            buttonConfirmAppointment.UseVisualStyleBackColor = false;
            // 
            // buttonWaitingRoom
            // 
            buttonWaitingRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonWaitingRoom.BackColor = Color.FromArgb(245, 158, 11);
            buttonWaitingRoom.Cursor = Cursors.Hand;
            buttonWaitingRoom.Enabled = false;
            buttonWaitingRoom.FlatAppearance.BorderSize = 0;
            buttonWaitingRoom.FlatStyle = FlatStyle.Flat;
            buttonWaitingRoom.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonWaitingRoom.ForeColor = Color.White;
            buttonWaitingRoom.Location = new Point(789, 16);
            buttonWaitingRoom.Name = "buttonWaitingRoom";
            buttonWaitingRoom.Padding = new Padding(22, 0, 0, 0);
            buttonWaitingRoom.Size = new Size(149, 48);
            buttonWaitingRoom.TabIndex = 3;
            buttonWaitingRoom.Text = "EN ESPERA";
            buttonWaitingRoom.UseVisualStyleBackColor = false;
            // 
            // buttonMarkAttended
            // 
            buttonMarkAttended.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMarkAttended.BackColor = Color.FromArgb(15, 23, 42);
            buttonMarkAttended.Cursor = Cursors.Hand;
            buttonMarkAttended.Enabled = false;
            buttonMarkAttended.FlatAppearance.BorderSize = 0;
            buttonMarkAttended.FlatStyle = FlatStyle.Flat;
            buttonMarkAttended.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonMarkAttended.ForeColor = Color.White;
            buttonMarkAttended.Location = new Point(952, 16);
            buttonMarkAttended.Name = "buttonMarkAttended";
            buttonMarkAttended.Padding = new Padding(22, 0, 0, 0);
            buttonMarkAttended.Size = new Size(145, 47);
            buttonMarkAttended.TabIndex = 4;
            buttonMarkAttended.Text = "ATENDIDO";
            buttonMarkAttended.UseVisualStyleBackColor = false;
            // 
            // buttonCancelAppointment
            // 
            buttonCancelAppointment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancelAppointment.BackColor = Color.FromArgb(239, 68, 68);
            buttonCancelAppointment.Cursor = Cursors.Hand;
            buttonCancelAppointment.Enabled = false;
            buttonCancelAppointment.FlatAppearance.BorderSize = 0;
            buttonCancelAppointment.FlatStyle = FlatStyle.Flat;
            buttonCancelAppointment.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonCancelAppointment.ForeColor = Color.White;
            buttonCancelAppointment.Location = new Point(1114, 16);
            buttonCancelAppointment.Name = "buttonCancelAppointment";
            buttonCancelAppointment.Padding = new Padding(22, 0, 0, 0);
            buttonCancelAppointment.Size = new Size(145, 48);
            buttonCancelAppointment.TabIndex = 5;
            buttonCancelAppointment.Text = "CANCELAR";
            buttonCancelAppointment.UseVisualStyleBackColor = false;
            // 
            // dataGridViewAgenda
            // 
            dataGridViewAgenda.BackgroundColor = Color.White;
            dataGridViewAgenda.BorderStyle = BorderStyle.None;
            dataGridViewAgenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAgenda.Location = new Point(0, 136);
            dataGridViewAgenda.Name = "dataGridViewAgenda";
            dataGridViewAgenda.RowHeadersWidth = 51;
            dataGridViewAgenda.Size = new Size(1280, 563);
            dataGridViewAgenda.TabIndex = 3;
            // 
            // FormAgenda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1278, 780);
            Controls.Add(dataGridViewAgenda);
            Controls.Add(panelActionsCard);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormAgenda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda Médica Visual - Cliniqax";
            ((System.ComponentModel.ISupportInitialize)picIconRefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconBookSlot).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconWaitingRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconAttended).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCancel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            panelActionsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAgenda).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelFiltersCard;
        private Label labelProfessionalPrompt;
        private ComboBox comboBoxProfessionals;
        private Label labelDatePrompt;
        private DateTimePicker dateTimePickerDate;
        private Button buttonPrevDay;
        private Button buttonToday;
        private Button buttonNextDay;
        private Button buttonRefresh;
        private Label labelScheduleInfo;
        private Panel panelActionsCard;
        private Label labelSelectedSlotInfo;
        private Button buttonBookSlot;
        private Button buttonConfirmAppointment;
        private Button buttonWaitingRoom;
        private Button buttonMarkAttended;
        private Button buttonCancelAppointment;
        private DataGridView dataGridViewAgenda;
        private PictureBox picIconRefresh;
        private PictureBox picIconBookSlot;
        private PictureBox picIconConfirm;
        private PictureBox picIconWaitingRoom;
        private PictureBox picIconAttended;
        private PictureBox picIconCancel;
    }
}