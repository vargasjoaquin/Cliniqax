using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormPatients : Form
    {
        private readonly IPatientService _patientService;
        private readonly ICatalogService _catalogService;
        private readonly IDocumentService _documentService;
        private readonly IExcelService _excelService;

        private int _selectedPatientId = 0;
        private List<PatientDto> _allPatients = new();

        public FormPatients(IPatientService patientService, ICatalogService catalogService, IDocumentService documentService, IExcelService excelService)
        {
            _patientService = patientService;
            _catalogService = catalogService;
            _documentService = documentService;
            _excelService = excelService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelPatientForm);

            // 1. Vinculación de Iconos Superpuestos (Patrón Compriax)
            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportPdf, this.picIconExportPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonExportExcel, this.picIconExportExcel);

            // 2. Máscaras y validaciones de entrada en tiempo real
            textBoxDocumentNumber.MaxLength = 8;
            textBoxDocumentNumber.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true; // Solo números en DNI
            };

            // 3. Resaltado de filas en la grilla
            this.dataGridViewPatients.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewPatients, e);

            // 4. Eventos de controles
            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSavePatientAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdatePatientAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeletePatientAsync();
            this.buttonCancel.Click += (s, e) => ResetInputFields();
            this.buttonExportPdf.Click += async (s, e) => await ExecuteExportPdfAsync();
            this.buttonExportExcel.Click += (s, e) => ExecuteExportExcel();
            this.textBoxSearch.TextChanged += (s, e) => FilterPatientsList();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                // Cargar combo de Obras Sociales
                var insurances = (await _catalogService.GetHealthInsurancesAsync()).ToList();
                insurances.Insert(0, new HealthInsuranceDto { Id = 0, Name = "[ Particular / Sin Obra Social ]" });
                comboBoxHealthInsurance.DataSource = insurances;
                comboBoxHealthInsurance.DisplayMember = "Name";
                comboBoxHealthInsurance.ValueMember = "Id";
                comboBoxHealthInsurance.SelectedIndex = 0;

                await RefreshPatientsGridAsync();

                // Selección administrada segura
                UIHelper.AttachManagedSelection(this, dataGridViewPatients, SynchronizeSelectedPatientToFields, ResetInputFields);
            }
        }

        private async Task RefreshPatientsGridAsync()
        {
            var patients = await _patientService.GetAllAsync();
            _allPatients = patients.ToList();
            FilterPatientsList();
        }

        private void FilterPatientsList()
        {
            string term = textBoxSearch.Text.Trim().ToLower();

            var filtered = _allPatients.Where(p =>
                p.DocumentNumber.Contains(term) ||
                p.LastName.ToLower().Contains(term) ||
                p.FirstName.ToLower().Contains(term) ||
                (p.HealthInsuranceName != null && p.HealthInsuranceName.ToLower().Contains(term)) ||
                p.Phone.Contains(term)
            ).ToList();

            dataGridViewPatients.DataSource = null;
            dataGridViewPatients.DataSource = filtered;
            UIHelper.FormatGrid(dataGridViewPatients);

            labelTotalPatients.Text = $"Pacientes Registrados: {filtered.Count}";
        }

        private void SynchronizeSelectedPatientToFields()
        {
            if (dataGridViewPatients.CurrentRow == null)
                return;

            var patient = (PatientDto)dataGridViewPatients.CurrentRow.DataBoundItem;

            _selectedPatientId = patient.Id;
            textBoxDocumentNumber.Text = patient.DocumentNumber;
            textBoxFirstName.Text = patient.FirstName;
            textBoxLastName.Text = patient.LastName;
            dateTimePickerBirthDate.Value = patient.BirthDate > dateTimePickerBirthDate.MinDate ? patient.BirthDate : DateTime.Today;
            textBoxPhone.Text = patient.Phone;
            textBoxEmail.Text = patient.Email ?? string.Empty;
            textBoxAddress.Text = patient.Address ?? string.Empty;
            textBoxCity.Text = patient.City ?? string.Empty;
            comboBoxHealthInsurance.SelectedValue = patient.HealthInsuranceId ?? 0;
            textBoxAffiliateNumber.Text = patient.AffiliateNumber ?? string.Empty;
            textBoxAdministrativeNotes.Text = patient.AdministrativeNotes ?? string.Empty;

            // INMUTABILIDAD DEL DNI: Se bloquea y cambia de color en modo edición
            textBoxDocumentNumber.ReadOnly = true;
            textBoxDocumentNumber.BackColor = Color.FromArgb(241, 245, 249);

            UpdateButtonStates(isEditing: true);
        }

        private void ResetInputFields()
        {
            _selectedPatientId = 0;
            UIHelper.CleanControls(panelPatientForm);

            comboBoxHealthInsurance.SelectedValue = 0;
            dateTimePickerBirthDate.Value = DateTime.Today.AddYears(-20);

            // Desbloquear DNI para nuevo ingreso
            textBoxDocumentNumber.ReadOnly = false;
            textBoxDocumentNumber.BackColor = Color.White;

            UpdateButtonStates(isEditing: false);
            textBoxDocumentNumber.Focus();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        private async Task ExecuteSavePatientAsync()
        {
            var dto = MapFieldsToDto(0);

            using (new WaitCursorHelper(this))
            {
                var result = await _patientService.RegisterPatientAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Pacientes", async () =>
                {
                    await RefreshPatientsGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteUpdatePatientAsync()
        {
            if (_selectedPatientId == 0)
            {
                UIHelper.WarnMessage(this, "Seleccione un paciente de la lista para modificarlo.", "Selección Requerida");
                return;
            }

            var dto = MapFieldsToUpdateDto(_selectedPatientId);

            using (new WaitCursorHelper(this))
            {
                var result = await _patientService.UpdatePatientAsync(dto);
                UIHelper.ShowResult(result, "Gestión de Pacientes", async () =>
                {
                    await RefreshPatientsGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteDeletePatientAsync()
        {
            if (_selectedPatientId == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Está seguro de que desea dar de baja a este paciente?", "Confirmar Baja"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _patientService.DeletePatientAsync(_selectedPatientId);
                    UIHelper.ShowResult(result, "Baja de Paciente", async () =>
                    {
                        await RefreshPatientsGridAsync();
                        ResetInputFields();
                    });
                }
            }
        }

        private async Task ExecuteExportPdfAsync()
        {
            if (!_allPatients.Any())
            {
                UIHelper.WarnMessage(this, "No hay pacientes para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] pdfBytes = await _documentService.GeneratePatientsListPdfAsync(_allPatients);
                string fileName = $"Pacientes_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Padrón de Pacientes en PDF");
            }
        }

        private void ExecuteExportExcel()
        {
            if (!_allPatients.Any())
            {
                UIHelper.WarnMessage(this, "No hay pacientes para exportar.", "Aviso");
                return;
            }

            using (new WaitCursorHelper(this))
            {
                byte[] excelBytes = _excelService.ExportToExcel(_allPatients, "Pacientes");
                string fileName = $"Pacientes_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                _ = FileExportHelper.SaveAndOpenExcelAsync(this, excelBytes, fileName, "Padrón de Pacientes en Excel");
            }
        }

        private PatientCreateDto MapFieldsToDto(int id)
        {
            return new PatientCreateDto
            {
                Id = id,
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                BirthDate = dateTimePickerBirthDate.Value.Date,
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                HealthInsuranceId = comboBoxHealthInsurance.SelectedValue is int hId && hId > 0 ? hId : null,
                AffiliateNumber = textBoxAffiliateNumber.Text.Trim(),
                AdministrativeNotes = textBoxAdministrativeNotes.Text.Trim()
            };
        }

        private PatientUpdateDto MapFieldsToUpdateDto(int id)
        {
            return new PatientUpdateDto
            {
                Id = id,
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                BirthDate = dateTimePickerBirthDate.Value.Date,
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                HealthInsuranceId = comboBoxHealthInsurance.SelectedValue is int hId && hId > 0 ? hId : null,
                AffiliateNumber = textBoxAffiliateNumber.Text.Trim(),
                AdministrativeNotes = textBoxAdministrativeNotes.Text.Trim()
            };
        }
    }
}
