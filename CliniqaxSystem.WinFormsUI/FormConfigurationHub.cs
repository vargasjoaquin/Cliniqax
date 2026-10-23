using CliniqaxSystem.Application.DTOs.Notification;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormConfigurationHub : Form
    {
        private readonly INotificationService _notificationService;
        private readonly IAppointmentReminderService _reminderService;
        private readonly IBackupService _backupService;
        private readonly IAuditService _auditService;

        private List<NotificationTemplateDto> _templates = new();
        private NotificationTemplateDto? _selectedTemplate;

        public FormConfigurationHub(INotificationService notificationService, IAppointmentReminderService reminderService, IBackupService backupService, IAuditService auditService)
        {
            _notificationService = notificationService;
            _reminderService = reminderService;
            _backupService = backupService;
            _auditService = auditService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonCheckRemindersNow, this.picIconCheckReminders);
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveTemplate, this.picIconSaveTemplate);
            ButtonIconOverlayHelper.BindEvents(this.buttonExecuteBackupNow, this.picIconExecuteBackup);

            // Eventos
            this.Load += async (s, e) => await LoadAllConfigDataAsync();
            this.buttonToggleRule.Click += async (s, e) => await ExecuteToggleRuleAsync();
            this.buttonCheckRemindersNow.Click += async (s, e) => await ExecuteCheckRemindersNowAsync();
            this.comboBoxTemplates.SelectedIndexChanged += OnComboBoxTemplatesSelectedIndexChanged;
            this.buttonSaveTemplate.Click += async (s, e) => await ExecuteSaveTemplateAsync();
            this.buttonExecuteBackupNow.Click += async (s, e) => await ExecuteRunBackupAsync();
        }

        private async Task LoadAllConfigDataAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshReminderRulesGridAsync();
                await RefreshTemplatesListAsync();
                await RefreshBackupLogsGridAsync();
            }
        }

        private async Task RefreshReminderRulesGridAsync()
        {
            var rules = await _notificationService.GetReminderRulesAsync();
            dataGridViewRules.DataSource = null;
            dataGridViewRules.DataSource = rules.ToList();
            UIHelper.FormatGrid(dataGridViewRules);
        }

        private async Task RefreshBackupLogsGridAsync()
        {
            var logs = await _auditService.GetBackupLogsAsync(30);
            dataGridViewBackupLogs.DataSource = null;
            dataGridViewBackupLogs.DataSource = logs.ToList();
            UIHelper.FormatGrid(dataGridViewBackupLogs);
        }

        private async Task ExecuteToggleRuleAsync()
        {
            if (dataGridViewRules.CurrentRow?.DataBoundItem is ReminderRuleConfigDto selectedRule)
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _notificationService.ToggleReminderRuleAsync(selectedRule.Id);
                    UIHelper.ShowResult(result, "Reglas de Recordatorios", async () =>
                    {
                        await RefreshReminderRulesGridAsync();
                    });
                }
            }
            else
            {
                UIHelper.WarnMessage(this, "Seleccione una regla de la tabla para activar o pausar.", "Aviso");
            }
        }

        private async Task ExecuteCheckRemindersNowAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var result = await _reminderService.CheckAndGenerateAppointmentRemindersAsync();
                UIHelper.ShowResult(result, "Evaluación de Recordatorios");
            }
        }

        private void OnTemplateSelected()
        {
            if (comboBoxTemplates.SelectedItem is NotificationTemplateDto tpl)
            {
                _selectedTemplate = tpl;

                textBoxTemplateSubject.Text = tpl.SubjectTemplate ?? string.Empty;
                textBoxTemplateSubject.Enabled = tpl.ChannelName.Equals("Email", StringComparison.OrdinalIgnoreCase);
                textBoxTemplateBody.Text = tpl.BodyTemplate;
                checkBoxTemplateActive.Checked = tpl.IsActive;
            }
        }

        private async Task ExecuteSaveTemplateAsync()
        {
            if (_selectedTemplate == null) 
                return;

            string body = textBoxTemplateBody.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(body))
            {
                UIHelper.WarnMessage(this, "El cuerpo de la plantilla no puede estar vacío.", "Campo Requerido");
                textBoxTemplateBody.Focus();
                return;
            }

            var dto = new NotificationTemplateUpdateDto
            {
                Id = _selectedTemplate.Id,
                SubjectTemplate = textBoxTemplateSubject.Text.Trim(),
                BodyTemplate = body,
                IsActive = checkBoxTemplateActive.Checked
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _notificationService.UpdateTemplateAsync(dto);

                if (result.Success)
                {
                    UIHelper.ShowResult(result, "Plantillas Dinámicas");

                    // 1. Actualizar inmediatamente el objeto en memoria
                    _selectedTemplate.BodyTemplate = dto.BodyTemplate;
                    _selectedTemplate.SubjectTemplate = dto.SubjectTemplate;
                    _selectedTemplate.IsActive = dto.IsActive;

                    // 2. Recargar desde la base de datos manteniendo la selección actual
                    int currentTemplateId = _selectedTemplate.Id;
                    await RefreshTemplatesListAsync(currentTemplateId);
                }
                else
                {
                    UIHelper.ShowResult(result, "Error al Actualizar");
                }
            }
        }

        private async Task RefreshTemplatesListAsync(int selectedIdToRestore = 0)
        {
            // Desvincular temporalmente el evento para evitar disparos en cascada al limpiar
            this.comboBoxTemplates.SelectedIndexChanged -= OnComboBoxTemplatesSelectedIndexChanged;

            _templates = (await _notificationService.GetTemplatesAsync()).ToList();

            comboBoxTemplates.DataSource = null;
            comboBoxTemplates.DataSource = _templates;
            comboBoxTemplates.DisplayMember = "Name";
            comboBoxTemplates.ValueMember = "Id";

            if (selectedIdToRestore > 0)
            {
                comboBoxTemplates.SelectedValue = selectedIdToRestore;
            }
            else if (_templates.Any())
            {
                comboBoxTemplates.SelectedIndex = 0;
            }

            // Volver a vincular el evento y reflejar en pantalla
            this.comboBoxTemplates.SelectedIndexChanged += OnComboBoxTemplatesSelectedIndexChanged;
            OnTemplateSelected();
        }

        private void OnComboBoxTemplatesSelectedIndexChanged(object? sender, EventArgs e)
        {
            OnTemplateSelected();
        }

        private async Task ExecuteRunBackupAsync()
        {
            if (UIHelper.ConfirmMessage("¿Desea generar una copia de seguridad integral ahora? Se respaldará la base de datos SQL y los archivos adjuntos.", "Confirmar Backup"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _backupService.ExecuteAutomaticBackupAsync();
                    UIHelper.ShowResult(result, "Copia de Seguridad", async () =>
                    {
                        await RefreshBackupLogsGridAsync();
                    });
                }
            }
        }
    }
}