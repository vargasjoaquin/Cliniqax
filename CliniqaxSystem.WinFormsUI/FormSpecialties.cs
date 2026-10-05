using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Windows.Forms;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormSpecialties : Form
    {
        private readonly ICatalogService _catalogService;
        private int _selectedSpecialtyId = 0;

        public FormSpecialties(ICatalogService catalogService)
        {
            _catalogService = catalogService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos overlay (Patrón Compriax)
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleStatus, this.picIconToggleStatus);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.dataGridViewSpecialties.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewSpecialties, e);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveSpecialtyAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateSpecialtyAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteToggleStatusAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteSpecialtyAsync();
            this.buttonCancel.Click += (s, e) => ResetInputFields();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                await RefreshGridAsync();
                UIHelper.AttachManagedSelection(this, dataGridViewSpecialties, SynchronizeSelectedSpecialtyToFields, ResetInputFields);
            }
        }

        private async Task RefreshGridAsync()
        {
            var list = await _catalogService.GetSpecialtiesAsync();
            dataGridViewSpecialties.DataSource = null;
            dataGridViewSpecialties.DataSource = list.ToList();
            UIHelper.FormatGrid(dataGridViewSpecialties);
        }

        private void SynchronizeSelectedSpecialtyToFields()
        {
            if (dataGridViewSpecialties.CurrentRow == null)
                return;

            var specialty = (SpecialtyDto)dataGridViewSpecialties.CurrentRow.DataBoundItem;

            _selectedSpecialtyId = specialty.Id;
            textBoxName.Text = specialty.Name;
            textBoxDescription.Text = specialty.Description ?? string.Empty;

            UpdateButtonStates(isEditing: true);
        }

        private void ResetInputFields()
        {
            _selectedSpecialtyId = 0;
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

        private async Task ExecuteSaveSpecialtyAsync()
        {
            var dto = new SpecialtyDto
            {
                Id = 0,
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.CreateSpecialtyAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Especialidades", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteUpdateSpecialtyAsync()
        {
            if (_selectedSpecialtyId == 0) return;

            var dto = new SpecialtyDto
            {
                Id = _selectedSpecialtyId,
                Name = textBoxName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                IsActive = true
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.UpdateSpecialtyAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Especialidades", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteToggleStatusAsync()
        {
            if (_selectedSpecialtyId == 0) return;

            using (new WaitCursorHelper(this))
            {
                var result = await _catalogService.ToggleSpecialtyStatusAsync(_selectedSpecialtyId);
                UIHelper.ShowResult(result, "Estado de Especialidad", async () =>
                {
                    await RefreshGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteDeleteSpecialtyAsync()
        {
            if (_selectedSpecialtyId == 0) return;

            if (UIHelper.ConfirmMessage("¿Desea dar de baja esta especialidad médica?", "Confirmar Baja"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _catalogService.DeleteSpecialtyAsync(_selectedSpecialtyId);
                    UIHelper.ShowResult(result, "Baja de Especialidad", async () =>
                    {
                        await RefreshGridAsync();
                        ResetInputFields();
                    });
                }
            }
        }
    }
}
