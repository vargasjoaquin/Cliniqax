using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormRestoreRecords : Form
    {
        private readonly IRestoreService _restoreService;
        private List<DeletedItemDto> _deletedItems = new();
        private DeletedItemDto? _selectedItem = null;
        private bool _isInitializing = false;
        private bool _isLoadingData = false;

        public FormRestoreRecords(IRestoreService restoreService)
        {
            _restoreService = restoreService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelControlsCard);

            // Vinculación de icono overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonRestoreRecord, this.picIconRestoreRecord);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.comboBoxEntityType.SelectedIndexChanged += async (s, e) =>
            {
                if (!_isInitializing)
                    await LoadDeletedRecordsAsync();
            };

            this.buttonRestoreRecord.Click += async (s, e) => await ExecuteRestoreAsync();
            this.textBoxSearch.TextChanged += (s, e) => FilterDeletedRecords();
        }

        private async Task InitializeFormAsync()
        {
            _isInitializing = true;
            try
            {
                comboBoxEntityType.Items.Clear();
                comboBoxEntityType.Items.AddRange(new object[] { "Pacientes", "Profesionales", "Especialidades", "Obras Sociales", "Usuarios" });
                comboBoxEntityType.SelectedIndex = 0;

                UIHelper.FormatGrid(dataGridViewDeletedRecords);
                UIHelper.AttachManagedSelection(this, dataGridViewDeletedRecords, SynchronizeSelectedDeletedRecord, ResetSelection);
            }
            finally
            {
                _isInitializing = false;
            }

            await LoadDeletedRecordsAsync();
        }

        private async Task LoadDeletedRecordsAsync()
        {
            if (comboBoxEntityType.SelectedItem == null || _isLoadingData)
                return;

            _isLoadingData = true;
            string entityType = comboBoxEntityType.SelectedItem.ToString()!;
            labelRecordCount.Text = "Consultando papelera...";

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var data = await _restoreService.GetDeletedEntitiesAsync(entityType);
                    _deletedItems = data.ToList();

                    FilterDeletedRecords();
                    ResetSelection();
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al consultar la papelera:\n{ex.Message}", "Fallo de Consulta");
                }
                finally
                {
                    _isLoadingData = false;
                }
            }
        }

        private void FilterDeletedRecords()
        {
            string term = textBoxSearch.Text.Trim().ToLower();

            var filtered = _deletedItems.Where(x =>
                x.Identifier.ToLower().Contains(term) ||
                x.Name.ToLower().Contains(term) ||
                (x.AdditionalInfo != null && x.AdditionalInfo.ToLower().Contains(term)) ||
                (x.DeletedBy != null && x.DeletedBy.ToLower().Contains(term))
            ).ToList();

            dataGridViewDeletedRecords.DataSource = null;
            dataGridViewDeletedRecords.DataSource = filtered;
            UIHelper.FormatGrid(dataGridViewDeletedRecords);

            labelRecordCount.Text = $"Registros en Papelera: {filtered.Count}";
        }

        private void SynchronizeSelectedDeletedRecord()
        {
            if (dataGridViewDeletedRecords.CurrentRow == null || dataGridViewDeletedRecords.CurrentRow.DataBoundItem is not DeletedItemDto item)
            {
                ResetSelection();
                return;
            }

            _selectedItem = item;
            labelSelectedItemInfo.Text = $"SELECCIONADO: [{_selectedItem.Identifier}] {_selectedItem.Name}";
            labelSelectedItemInfo.ForeColor = UIThemeHelper.Primary;
            buttonRestoreRecord.Enabled = true;
        }

        private void ResetSelection()
        {
            _selectedItem = null;
            labelSelectedItemInfo.Text = "Seleccione un registro de la grilla para restaurarlo.";
            labelSelectedItemInfo.ForeColor = UIThemeHelper.TextMuted;
            buttonRestoreRecord.Enabled = false;
        }

        private async Task ExecuteRestoreAsync()
        {
            if (_selectedItem == null) return;

            string message = $"¿Desea restaurar este registro?\n\n" +
                             $"Módulo: {_selectedItem.EntityType}\n" +
                             $"Detalle: {_selectedItem.Name}\n\n" +
                             $"Volverá a estar activo y disponible en el sistema.";

            if (UIHelper.ConfirmMessage(message, "Confirmar Restauración"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _restoreService.RestoreEntityAsync(_selectedItem.EntityType, _selectedItem.Id);
                    UIHelper.ShowResult(result, "Restauración de Registros", async () =>
                    {
                        await LoadDeletedRecordsAsync();
                    });
                }
            }
        }
    }
}
