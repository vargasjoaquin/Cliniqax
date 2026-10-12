namespace CliniqaxSystem.WinFormsUI
{
    partial class FormConfigurationHub
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
            labelTitle = new Label();
            tabControlConfig = new TabControl();
            tabPageReminders = new TabPage();
            dataGridViewRules = new DataGridView();
            panelRulesActions = new Panel();
            picIconCheckReminders = new PictureBox();
            buttonCheckRemindersNow = new Button();
            buttonToggleRule = new Button();
            tabPageTemplates = new TabPage();
            panelTemplateCard = new Panel();
            labelSelectTemplatePrompt = new Label();
            comboBoxTemplates = new ComboBox();
            labelSubjectPrompt = new Label();
            textBoxTemplateSubject = new TextBox();
            labelBodyPrompt = new Label();
            textBoxTemplateBody = new TextBox();
            checkBoxTemplateActive = new CheckBox();
            picIconSaveTemplate = new PictureBox();
            buttonSaveTemplate = new Button();
            tabPageBackups = new TabPage();
            dataGridViewBackupLogs = new DataGridView();
            panelBackupActions = new Panel();
            picIconExecuteBackup = new PictureBox();
            buttonExecuteBackupNow = new Button();
            labelBackupLogsTitle = new Label();
            panelHeader.SuspendLayout();
            tabControlConfig.SuspendLayout();
            tabPageReminders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRules).BeginInit();
            panelRulesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconCheckReminders).BeginInit();
            tabPageTemplates.SuspendLayout();
            panelTemplateCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconSaveTemplate).BeginInit();
            tabPageBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackupLogs).BeginInit();
            panelBackupActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIconExecuteBackup).BeginInit();
            SuspendLayout();
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
            labelTitle.Size = new Size(544, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CENTRO DE CONFIGURACIÓN Y AUTOMATIZACIÓN";
            // 
            // tabControlConfig
            // 
            tabControlConfig.Controls.Add(tabPageReminders);
            tabControlConfig.Controls.Add(tabPageTemplates);
            tabControlConfig.Controls.Add(tabPageBackups);
            tabControlConfig.Dock = DockStyle.Fill;
            tabControlConfig.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabControlConfig.Location = new Point(0, 56);
            tabControlConfig.Name = "tabControlConfig";
            tabControlConfig.SelectedIndex = 0;
            tabControlConfig.Size = new Size(1150, 684);
            tabControlConfig.TabIndex = 1;
            // 
            // tabPageReminders
            // 
            tabPageReminders.BackColor = Color.FromArgb(248, 250, 252);
            tabPageReminders.Controls.Add(dataGridViewRules);
            tabPageReminders.Controls.Add(panelRulesActions);
            tabPageReminders.Location = new Point(4, 30);
            tabPageReminders.Name = "tabPageReminders";
            tabPageReminders.Padding = new Padding(16);
            tabPageReminders.Size = new Size(1142, 650);
            tabPageReminders.TabIndex = 0;
            tabPageReminders.Text = "  Recordatorios Automáticos  ";
            // 
            // dataGridViewRules
            // 
            dataGridViewRules.BackgroundColor = Color.White;
            dataGridViewRules.BorderStyle = BorderStyle.None;
            dataGridViewRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRules.Dock = DockStyle.Fill;
            dataGridViewRules.Location = new Point(16, 76);
            dataGridViewRules.Name = "dataGridViewRules";
            dataGridViewRules.RowHeadersWidth = 51;
            dataGridViewRules.Size = new Size(1110, 558);
            dataGridViewRules.TabIndex = 1;
            // 
            // panelRulesActions
            // 
            panelRulesActions.BackColor = Color.White;
            panelRulesActions.Controls.Add(picIconCheckReminders);
            panelRulesActions.Controls.Add(buttonCheckRemindersNow);
            panelRulesActions.Controls.Add(buttonToggleRule);
            panelRulesActions.Dock = DockStyle.Top;
            panelRulesActions.Location = new Point(16, 16);
            panelRulesActions.Name = "panelRulesActions";
            panelRulesActions.Padding = new Padding(8);
            panelRulesActions.Size = new Size(1110, 60);
            panelRulesActions.TabIndex = 0;
            // 
            // picIconCheckReminders
            // 
            picIconCheckReminders.BackColor = Color.FromArgb(16, 185, 129);
            picIconCheckReminders.Cursor = Cursors.Hand;
            picIconCheckReminders.Image = Icons.action_guardar;
            picIconCheckReminders.Location = new Point(44, 10);
            picIconCheckReminders.Name = "picIconCheckReminders";
            picIconCheckReminders.Size = new Size(42, 40);
            picIconCheckReminders.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCheckReminders.TabIndex = 99;
            picIconCheckReminders.TabStop = false;
            // 
            // buttonCheckRemindersNow
            // 
            buttonCheckRemindersNow.BackColor = Color.FromArgb(16, 185, 129);
            buttonCheckRemindersNow.Cursor = Cursors.Hand;
            buttonCheckRemindersNow.FlatAppearance.BorderSize = 0;
            buttonCheckRemindersNow.FlatStyle = FlatStyle.Flat;
            buttonCheckRemindersNow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCheckRemindersNow.ForeColor = Color.White;
            buttonCheckRemindersNow.Location = new Point(12, 10);
            buttonCheckRemindersNow.Name = "buttonCheckRemindersNow";
            buttonCheckRemindersNow.Padding = new Padding(26, 0, 0, 0);
            buttonCheckRemindersNow.Size = new Size(320, 40);
            buttonCheckRemindersNow.TabIndex = 0;
            buttonCheckRemindersNow.Text = "EVALUAR RECORDATORIOS";
            buttonCheckRemindersNow.UseVisualStyleBackColor = false;
            // 
            // buttonToggleRule
            // 
            buttonToggleRule.BackColor = Color.FromArgb(245, 158, 11);
            buttonToggleRule.Cursor = Cursors.Hand;
            buttonToggleRule.FlatAppearance.BorderSize = 0;
            buttonToggleRule.FlatStyle = FlatStyle.Flat;
            buttonToggleRule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleRule.ForeColor = Color.White;
            buttonToggleRule.Location = new Point(345, 10);
            buttonToggleRule.Name = "buttonToggleRule";
            buttonToggleRule.Size = new Size(200, 40);
            buttonToggleRule.TabIndex = 1;
            buttonToggleRule.Text = "ACTIVAR / PAUSAR";
            buttonToggleRule.UseVisualStyleBackColor = false;
            // 
            // tabPageTemplates
            // 
            tabPageTemplates.BackColor = Color.FromArgb(248, 250, 252);
            tabPageTemplates.Controls.Add(panelTemplateCard);
            tabPageTemplates.Location = new Point(4, 30);
            tabPageTemplates.Name = "tabPageTemplates";
            tabPageTemplates.Padding = new Padding(16);
            tabPageTemplates.Size = new Size(1142, 650);
            tabPageTemplates.TabIndex = 1;
            tabPageTemplates.Text = "  Plantillas de Mensajes  ";
            // 
            // panelTemplateCard
            // 
            panelTemplateCard.BackColor = Color.White;
            panelTemplateCard.Controls.Add(labelSelectTemplatePrompt);
            panelTemplateCard.Controls.Add(comboBoxTemplates);
            panelTemplateCard.Controls.Add(labelSubjectPrompt);
            panelTemplateCard.Controls.Add(textBoxTemplateSubject);
            panelTemplateCard.Controls.Add(labelBodyPrompt);
            panelTemplateCard.Controls.Add(textBoxTemplateBody);
            panelTemplateCard.Controls.Add(checkBoxTemplateActive);
            panelTemplateCard.Controls.Add(picIconSaveTemplate);
            panelTemplateCard.Controls.Add(buttonSaveTemplate);
            panelTemplateCard.Dock = DockStyle.Fill;
            panelTemplateCard.Location = new Point(16, 16);
            panelTemplateCard.Name = "panelTemplateCard";
            panelTemplateCard.Padding = new Padding(20);
            panelTemplateCard.Size = new Size(1110, 618);
            panelTemplateCard.TabIndex = 0;
            // 
            // labelSelectTemplatePrompt
            // 
            labelSelectTemplatePrompt.AutoSize = true;
            labelSelectTemplatePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSelectTemplatePrompt.Location = new Point(20, 15);
            labelSelectTemplatePrompt.Name = "labelSelectTemplatePrompt";
            labelSelectTemplatePrompt.Size = new Size(151, 20);
            labelSelectTemplatePrompt.TabIndex = 0;
            labelSelectTemplatePrompt.Text = "Seleccionar Plantilla:";
            // 
            // comboBoxTemplates
            // 
            comboBoxTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTemplates.Font = new Font("Segoe UI", 10F);
            comboBoxTemplates.Location = new Point(20, 38);
            comboBoxTemplates.Name = "comboBoxTemplates";
            comboBoxTemplates.Size = new Size(420, 31);
            comboBoxTemplates.TabIndex = 1;
            // 
            // labelSubjectPrompt
            // 
            labelSubjectPrompt.AutoSize = true;
            labelSubjectPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSubjectPrompt.Location = new Point(20, 85);
            labelSubjectPrompt.Name = "labelSubjectPrompt";
            labelSubjectPrompt.Size = new Size(187, 20);
            labelSubjectPrompt.TabIndex = 3;
            labelSubjectPrompt.Text = "Asunto (Solo para Email):";
            // 
            // textBoxTemplateSubject
            // 
            textBoxTemplateSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTemplateSubject.BorderStyle = BorderStyle.FixedSingle;
            textBoxTemplateSubject.Font = new Font("Segoe UI", 10F);
            textBoxTemplateSubject.Location = new Point(20, 108);
            textBoxTemplateSubject.MaxLength = 200;
            textBoxTemplateSubject.Name = "textBoxTemplateSubject";
            textBoxTemplateSubject.Size = new Size(1070, 30);
            textBoxTemplateSubject.TabIndex = 4;
            // 
            // labelBodyPrompt
            // 
            labelBodyPrompt.AutoSize = true;
            labelBodyPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBodyPrompt.Location = new Point(20, 150);
            labelBodyPrompt.Name = "labelBodyPrompt";
            labelBodyPrompt.Size = new Size(221, 20);
            labelBodyPrompt.TabIndex = 5;
            labelBodyPrompt.Text = "Cuerpo del Mensaje / Plantilla:";
            // 
            // textBoxTemplateBody
            // 
            textBoxTemplateBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTemplateBody.BorderStyle = BorderStyle.FixedSingle;
            textBoxTemplateBody.Font = new Font("Consolas", 10F);
            textBoxTemplateBody.Location = new Point(20, 173);
            textBoxTemplateBody.Multiline = true;
            textBoxTemplateBody.Name = "textBoxTemplateBody";
            textBoxTemplateBody.ScrollBars = ScrollBars.Vertical;
            textBoxTemplateBody.Size = new Size(1070, 260);
            textBoxTemplateBody.TabIndex = 6;
            // 
            // checkBoxTemplateActive
            // 
            checkBoxTemplateActive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBoxTemplateActive.AutoSize = true;
            checkBoxTemplateActive.Checked = true;
            checkBoxTemplateActive.CheckState = CheckState.Checked;
            checkBoxTemplateActive.Location = new Point(23, 453);
            checkBoxTemplateActive.Name = "checkBoxTemplateActive";
            checkBoxTemplateActive.Size = new Size(148, 25);
            checkBoxTemplateActive.TabIndex = 8;
            checkBoxTemplateActive.Text = "Plantilla Activa";
            checkBoxTemplateActive.UseVisualStyleBackColor = true;
            // 
            // picIconSaveTemplate
            // 
            picIconSaveTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIconSaveTemplate.BackColor = Color.FromArgb(16, 185, 129);
            picIconSaveTemplate.Cursor = Cursors.Hand;
            picIconSaveTemplate.Image = Icons.action_guardar;
            picIconSaveTemplate.Location = new Point(810, 545);
            picIconSaveTemplate.Name = "picIconSaveTemplate";
            picIconSaveTemplate.Size = new Size(36, 42);
            picIconSaveTemplate.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveTemplate.TabIndex = 99;
            picIconSaveTemplate.TabStop = false;
            // 
            // buttonSaveTemplate
            // 
            buttonSaveTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveTemplate.BackColor = Color.FromArgb(16, 185, 129);
            buttonSaveTemplate.Cursor = Cursors.Hand;
            buttonSaveTemplate.FlatAppearance.BorderSize = 0;
            buttonSaveTemplate.FlatStyle = FlatStyle.Flat;
            buttonSaveTemplate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSaveTemplate.ForeColor = Color.White;
            buttonSaveTemplate.Location = new Point(810, 545);
            buttonSaveTemplate.Name = "buttonSaveTemplate";
            buttonSaveTemplate.Padding = new Padding(28, 0, 0, 0);
            buttonSaveTemplate.Size = new Size(280, 46);
            buttonSaveTemplate.TabIndex = 9;
            buttonSaveTemplate.Text = "GUARDAR PLANTILLA";
            buttonSaveTemplate.UseVisualStyleBackColor = false;
            // 
            // tabPageBackups
            // 
            tabPageBackups.BackColor = Color.FromArgb(248, 250, 252);
            tabPageBackups.Controls.Add(dataGridViewBackupLogs);
            tabPageBackups.Controls.Add(panelBackupActions);
            tabPageBackups.Location = new Point(4, 30);
            tabPageBackups.Name = "tabPageBackups";
            tabPageBackups.Padding = new Padding(16);
            tabPageBackups.Size = new Size(1142, 650);
            tabPageBackups.TabIndex = 2;
            tabPageBackups.Text = " Copias de Seguridad ";
            // 
            // dataGridViewBackupLogs
            // 
            dataGridViewBackupLogs.BackgroundColor = Color.White;
            dataGridViewBackupLogs.BorderStyle = BorderStyle.None;
            dataGridViewBackupLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBackupLogs.Dock = DockStyle.Fill;
            dataGridViewBackupLogs.Location = new Point(16, 76);
            dataGridViewBackupLogs.Name = "dataGridViewBackupLogs";
            dataGridViewBackupLogs.RowHeadersWidth = 51;
            dataGridViewBackupLogs.Size = new Size(1110, 558);
            dataGridViewBackupLogs.TabIndex = 1;
            // 
            // panelBackupActions
            // 
            panelBackupActions.BackColor = Color.White;
            panelBackupActions.Controls.Add(picIconExecuteBackup);
            panelBackupActions.Controls.Add(buttonExecuteBackupNow);
            panelBackupActions.Controls.Add(labelBackupLogsTitle);
            panelBackupActions.Dock = DockStyle.Top;
            panelBackupActions.Location = new Point(16, 16);
            panelBackupActions.Name = "panelBackupActions";
            panelBackupActions.Padding = new Padding(8);
            panelBackupActions.Size = new Size(1110, 60);
            panelBackupActions.TabIndex = 0;
            // 
            // picIconExecuteBackup
            // 
            picIconExecuteBackup.BackColor = Color.FromArgb(2, 132, 199);
            picIconExecuteBackup.Cursor = Cursors.Hand;
            picIconExecuteBackup.Image = Icons.action_guardar;
            picIconExecuteBackup.Location = new Point(27, 10);
            picIconExecuteBackup.Name = "picIconExecuteBackup";
            picIconExecuteBackup.Size = new Size(43, 40);
            picIconExecuteBackup.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExecuteBackup.TabIndex = 99;
            picIconExecuteBackup.TabStop = false;
            // 
            // buttonExecuteBackupNow
            // 
            buttonExecuteBackupNow.BackColor = Color.FromArgb(2, 132, 199);
            buttonExecuteBackupNow.Cursor = Cursors.Hand;
            buttonExecuteBackupNow.FlatAppearance.BorderSize = 0;
            buttonExecuteBackupNow.FlatStyle = FlatStyle.Flat;
            buttonExecuteBackupNow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExecuteBackupNow.ForeColor = Color.White;
            buttonExecuteBackupNow.Location = new Point(12, 10);
            buttonExecuteBackupNow.Name = "buttonExecuteBackupNow";
            buttonExecuteBackupNow.Padding = new Padding(26, 0, 0, 0);
            buttonExecuteBackupNow.Size = new Size(330, 40);
            buttonExecuteBackupNow.TabIndex = 0;
            buttonExecuteBackupNow.Text = "GENERAR COPIA DE SEGURIDAD";
            buttonExecuteBackupNow.UseVisualStyleBackColor = false;
            // 
            // labelBackupLogsTitle
            // 
            labelBackupLogsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelBackupLogsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelBackupLogsTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelBackupLogsTitle.Location = new Point(733, 13);
            labelBackupLogsTitle.Name = "labelBackupLogsTitle";
            labelBackupLogsTitle.Size = new Size(285, 33);
            labelBackupLogsTitle.TabIndex = 1;
            labelBackupLogsTitle.Text = "Historial Reciente de Ejecuciones:";
            labelBackupLogsTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormConfigurationHub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1150, 740);
            Controls.Add(tabControlConfig);
            Controls.Add(panelHeader);
            Name = "FormConfigurationHub";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración y Automatización - Cliniqax";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControlConfig.ResumeLayout(false);
            tabPageReminders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRules).EndInit();
            panelRulesActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconCheckReminders).EndInit();
            tabPageTemplates.ResumeLayout(false);
            panelTemplateCard.ResumeLayout(false);
            panelTemplateCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIconSaveTemplate).EndInit();
            tabPageBackups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBackupLogs).EndInit();
            panelBackupActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIconExecuteBackup).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private TabControl tabControlConfig;
        private TabPage tabPageReminders;
        private DataGridView dataGridViewRules;
        private Panel panelRulesActions;
        private Button buttonCheckRemindersNow;
        private PictureBox picIconCheckReminders;
        private Button buttonToggleRule;
        private TabPage tabPageTemplates;
        private Panel panelTemplateCard;
        private Label labelSelectTemplatePrompt;
        private ComboBox comboBoxTemplates;
        private Label labelSubjectPrompt;
        private TextBox textBoxTemplateSubject;
        private Label labelBodyPrompt;
        private TextBox textBoxTemplateBody;
        private CheckBox checkBoxTemplateActive;
        private Button buttonSaveTemplate;
        private PictureBox picIconSaveTemplate;
        private TabPage tabPageBackups;
        private DataGridView dataGridViewBackupLogs;
        private Panel panelBackupActions;
        private Button buttonExecuteBackupNow;
        private PictureBox picIconExecuteBackup;
        private Label labelBackupLogsTitle;
    }
}