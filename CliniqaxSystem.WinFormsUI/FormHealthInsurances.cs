using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormHealthInsurances : Form
    {
        private readonly ICatalogService _catalogService;
        private int _selectedInsuranceId = 0;

        public FormHealthInsurances(ICatalogService catalogService)
        {
            _catalogService = catalogService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleStatus, this.picIconToggleStatus);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Máscara CUIT
            textBoxCuit.MaxLength = 13;
            textBoxCuit.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxCuit);

            this.dataGridViewInsurances.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewInsurances, e);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveInsuranceAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateInsuranceAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteToggleStatusAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteInsuranceAsync();
            this.buttonCancel.Click += (s, e) => ResetInputFields();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewInsurances, SynchronizeSelectedInsuranceToFields, ResetInputFields);
            }
        }

        private async Task RefreshGridAsync()
        {
            var list = await _catalogService.GetHealthInsurancesAsync();
            dataGridViewInsurances.DataSource = null;
            dataGridViewInsurances.DataSource = list.ToList();
            UIHelper.FormatGrid(dataGridViewInsurances);
        }

        private void SynchronizeSelectedInsuranceToFields()
        {
            if (dataGridViewInsurances.CurrentRow == null)
                return;

            var ins = (HealthInsuranceDto)dataGridViewInsurances.CurrentRow.DataBoundItem;

            _selectedInsuranceId = ins.Id;
            textBoxName.Text = ins.Name;
            textBoxCuit.Text = ins.Cuit ?? string.Empty;
            textBoxPhone.Text = ins.Phone ?? string.Empty;
            textBoxEmail.Text = ins.Email ?? string.Empty;

            UpdateButtonStates(isEditing: true);
        }

        private void ResetInputFields()
        {
            _selectedInsuranceId = 0;
            UIHelper.CleanControls(panelCard);
            UpdateButtonStates(isEditing: false);
            textBoxName.Focus();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonToggleStatus.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        private async Task ExecuteSaveInsuranceAsync()
        {
            var dto = new HealthInsuranceDto
            {
                Id = 0,
                Name = textBoxName.Text.Trim(),
                Cuit = textBoxCuit.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.CreateHealthInsuranceAsync(dto);
                UIHelper.ShowResult(result, "Obras Sociales", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteUpdateInsuranceAsync()
        {
            if (_selectedInsuranceId == 0) return;

            var dto = new HealthInsuranceDto
            {
                Id = _selectedInsuranceId,
                Name = textBoxName.Text.Trim(),
                Cuit = textBoxCuit.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.UpdateHealthInsuranceAsync(dto);
                UIHelper.ShowResult(result, "Obras Sociales", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteToggleStatusAsync()
        {
            if (_selectedInsuranceId == 0) return;

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.ToggleHealthInsuranceStatusAsync(_selectedInsuranceId);
                UIHelper.ShowResult(result, "Estado de Obra Social", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteDeleteInsuranceAsync()
        {
            if (_selectedInsuranceId == 0) return;

            if (UIHelper.ConfirmMessage("¿Dar de baja esta Obra Social / Prepaga?", "Confirmar Baja"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _catalogService.DeleteHealthInsuranceAsync(_selectedInsuranceId);
                    UIHelper.ShowResult(result, "Baja de Obra Social", async () =>
                    {
                        await RefreshGridAsync();
                        ResetInputFields();
                    });
                }
            }
        }
    }
}
