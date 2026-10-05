using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormProfessionals : Form
    {
        private readonly IProfessionalService _professionalService;
        private readonly ICatalogService _catalogService;

        private int _selectedProfessionalId = 0;
        private List<ProfessionalDto> _allProfessionals = new();
        private List<SpecialtyDto> _availableSpecialties = new();
        private List<ProfessionalScheduleDto> _currentSchedules = new();

        public FormProfessionals(IProfessionalService professionalService, ICatalogService catalogService)
        {
            _professionalService = professionalService;
            _catalogService = catalogService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelProfessionalForm);

            ButtonIconOverlayHelper.BindEvents(this.buttonSave, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonEdit, this.picIconEdit);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleStatus, this.picIconToggleStatus);
            ButtonIconOverlayHelper.BindEvents(this.buttonDelete, this.picIconDelete);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "HH:mm";
            dateTimePickerStartTime.ShowUpDown = true;
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "HH:mm";
            dateTimePickerEndTime.ShowUpDown = true;

            dateTimePickerStartTime.Value = DateTime.Today.AddHours(8);
            dateTimePickerEndTime.Value = DateTime.Today.AddHours(12);

            textBoxDocumentNumber.MaxLength = 8;
            textBoxDocumentNumber.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            this.dataGridViewProfessionals.CellFormatting += (s, e) => DataGridViewHelper.ColorRowsByStatus(dataGridViewProfessionals, e);

            this.Load += async (s, e) => await InitializeFormAsync();
            this.buttonSave.Click += async (s, e) => await ExecuteSaveProfessionalAsync();
            this.buttonEdit.Click += async (s, e) => await ExecuteUpdateProfessionalAsync();
            this.buttonToggleStatus.Click += async (s, e) => await ExecuteToggleStatusAsync();
            this.buttonDelete.Click += async (s, e) => await ExecuteDeleteProfessionalAsync();
            this.buttonCancel.Click += (s, e) => ResetInputFields();
            this.buttonAddSchedule.Click += (s, e) => AddScheduleSlot();
            this.buttonRemoveSchedule.Click += (s, e) => RemoveSelectedScheduleSlot();
            this.textBoxSearch.TextChanged += (s, e) => FilterProfessionalsList();
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxDayOfWeek.DataSource = new[]
                {
                    new { Id = DayOfWeek.Monday, Name = "Lunes" },
                    new { Id = DayOfWeek.Tuesday, Name = "Martes" },
                    new { Id = DayOfWeek.Wednesday, Name = "Miércoles" },
                    new { Id = DayOfWeek.Thursday, Name = "Jueves" },
                    new { Id = DayOfWeek.Friday, Name = "Viernes" },
                    new { Id = DayOfWeek.Saturday, Name = "Sábado" },
                    new { Id = DayOfWeek.Sunday, Name = "Domingo" }
                };
                comboBoxDayOfWeek.DisplayMember = "Name";
                comboBoxDayOfWeek.ValueMember = "Id";

                _availableSpecialties = (await _catalogService.GetSpecialtiesAsync()).Where(s => s.IsActive).ToList();

                checkedListBoxSpecialties.Items.Clear();

                foreach (var specialty in _availableSpecialties)
                {
                    checkedListBoxSpecialties.Items.Add(specialty.Name, false);
                }

                await RefreshProfessionalsGridAsync();

                UIHelper.AttachManagedSelection(this, dataGridViewProfessionals, SynchronizeSelectedProfessionalToFields, ResetInputFields);
            }
        }

        private async Task RefreshProfessionalsGridAsync()
        {
            var list = await _professionalService.GetAllAsync();
            _allProfessionals = list.ToList();
            
            FilterProfessionalsList();
        }

        private void FilterProfessionalsList()
        {
            string termSearch = textBoxSearch.Text.Trim().ToLower();

            var filtered = _allProfessionals.Where(p =>
                p.DocumentNumber.Contains(termSearch) ||
                p.LicenseNumber.ToLower().Contains(termSearch) ||
                p.LastName.ToLower().Contains(termSearch) ||
                p.FirstName.ToLower().Contains(termSearch) ||
                p.SpecialtyNames.Any(sn => sn.ToLower().Contains(termSearch))
            ).ToList();

            dataGridViewProfessionals.DataSource = null;
            dataGridViewProfessionals.DataSource = filtered;
            
            UIHelper.FormatGrid(dataGridViewProfessionals);

            labelTotalProfessionals.Text = $"Profesionales Registrados: {filtered.Count}";
        }

        private void SynchronizeSelectedProfessionalToFields()
        {
            if (dataGridViewProfessionals.CurrentRow == null)
                return;

            var professional = (ProfessionalDto)dataGridViewProfessionals.CurrentRow.DataBoundItem;

            _selectedProfessionalId = professional.Id;
            textBoxDocumentNumber.Text = professional.DocumentNumber;
            textBoxLicenseNumber.Text = professional.LicenseNumber;
            textBoxFirstName.Text = professional.FirstName;
            textBoxLastName.Text = professional.LastName;
            textBoxPhone.Text = professional.Phone ?? string.Empty;
            textBoxEmail.Text = professional.Email ?? string.Empty;
            numericUpDownDuration.Value = Math.Clamp(professional.AppointmentDuration > 0 ? professional.AppointmentDuration : 30, 1, 1440);
            textBoxObservations.Text = professional.Observations ?? string.Empty;

            textBoxDocumentNumber.ReadOnly = true;
            textBoxDocumentNumber.BackColor = Color.FromArgb(241, 245, 249);
            textBoxLicenseNumber.ReadOnly = true;
            textBoxLicenseNumber.BackColor = Color.FromArgb(241, 245, 249);

            for (int i = 0; i < checkedListBoxSpecialties.Items.Count; i++)
            {
                string specialtyName = checkedListBoxSpecialties.Items[i].ToString()!;
                checkedListBoxSpecialties.SetItemChecked(i, professional.SpecialtyNames.Contains(specialtyName));
            }

            _currentSchedules = professional.Schedules.ToList();
            RefreshSchedulesGrid();

            UpdateButtonStates(isEditing: true);
        }

        private void ResetInputFields()
        {
            _selectedProfessionalId = 0;
            UIHelper.CleanControls(panelProfessionalForm);

            textBoxDocumentNumber.ReadOnly = false;
            textBoxDocumentNumber.BackColor = Color.White;
            textBoxLicenseNumber.ReadOnly = false;
            textBoxLicenseNumber.BackColor = Color.White;

            numericUpDownDuration.Value = 30;

            for (int i = 0; i < checkedListBoxSpecialties.Items.Count; i++)
                checkedListBoxSpecialties.SetItemChecked(i, false);

            _currentSchedules.Clear();
            RefreshSchedulesGrid();

            UpdateButtonStates(isEditing: false);
            textBoxDocumentNumber.Focus();
        }

        private void UpdateButtonStates(bool isEditing)
        {
            buttonSave.Enabled = !isEditing;
            buttonEdit.Enabled = isEditing;
            buttonToggleStatus.Enabled = isEditing;
            buttonDelete.Enabled = isEditing;
        }

        // ==========================================
        // GESTIÓN DE HORARIOS SEMANALES DEL MÉDICO
        // ==========================================
        private void AddScheduleSlot()
        {
            var selectedDay = (DayOfWeek)comboBoxDayOfWeek.SelectedValue!;
            var start = dateTimePickerStartTime.Value.TimeOfDay;
            var end = dateTimePickerEndTime.Value.TimeOfDay;

            if (start >= end)
            {
                UIHelper.WarnMessage(this, "La hora de inicio debe ser anterior a la hora de fin de atención.", "Horario Inválido");
                return;
            }

            // Evitar duplicados para el mismo día y hora
            bool overlap = _currentSchedules.Any(s => s.DayOfWeek == selectedDay && (start < s.EndTime && end > s.StartTime));
            
            if (overlap)
            {
                UIHelper.WarnMessage(this, $"El profesional ya tiene configurado un bloque de atención solapado para el día {comboBoxDayOfWeek.Text}.", "Horario Solapado");
                return;
            }

            _currentSchedules.Add(new ProfessionalScheduleDto
            {
                DayOfWeek = selectedDay,
                StartTime = start,
                EndTime = end,
                IsActive = true
            });

            RefreshSchedulesGrid();
        }

        private void RemoveSelectedScheduleSlot()
        {
            if (dataGridViewSchedules.CurrentRow?.DataBoundItem is ProfessionalScheduleDto selected)
            {
                _currentSchedules.Remove(selected);
                RefreshSchedulesGrid();
            }
            else
            {
                UIHelper.WarnMessage(this, "Seleccione un horario de la tabla para quitarlo.", "Aviso");
            }
        }

        private void RefreshSchedulesGrid()
        {
            dataGridViewSchedules.DataSource = null;
            dataGridViewSchedules.DataSource = _currentSchedules.OrderBy(s => s.DayOfWeek).ThenBy(s => s.StartTime).ToList();
            UIHelper.FormatGrid(dataGridViewSchedules);
        }

        private async Task ExecuteSaveProfessionalAsync()
        {
            var dto = MapFieldsToCreateDto();

            using (new WaitCursorHelper(this))
            {
                var result = await _professionalService.CreateProfessionalAsync(dto);
               
                UIHelper.ShowResult(result, "Gestión de Profesionales", async () =>
                {
                    await RefreshProfessionalsGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteUpdateProfessionalAsync()
        {
            if (_selectedProfessionalId == 0)
            {
                UIHelper.WarnMessage(this, "Seleccione un profesional para modificar.", "Selección Requerida");
                return;
            }

            var dto = MapFieldsToUpdateDto(_selectedProfessionalId);

            using (new WaitCursorHelper(this))
            {
                var result = await _professionalService.UpdateProfessionalAsync(dto);
                
                UIHelper.ShowResult(result, "Gestión de Profesionales", async () =>
                {
                    await RefreshProfessionalsGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteToggleStatusAsync()
        {
            if (_selectedProfessionalId == 0) 
                return;

            using (new WaitCursorHelper(this))
            {
                var result = await _professionalService.ToggleStatusAsync(_selectedProfessionalId);
               
                UIHelper.ShowResult(result, "Estado del Profesional", async () =>
                {
                    await RefreshProfessionalsGridAsync();
                    ResetInputFields();
                });
            }
        }

        private async Task ExecuteDeleteProfessionalAsync()
        {
            if (_selectedProfessionalId == 0)
                return;

            if (UIHelper.ConfirmMessage("¿Dar de baja a este profesional? No se eliminarán turnos históricos.", "Confirmar Baja"))
            {
                using (new WaitCursorHelper(this))
                {
                    var result = await _professionalService.DeleteProfessionalAsync(_selectedProfessionalId);
                    UIHelper.ShowResult(result, "Baja de Profesional", async () =>
                    {
                        await RefreshProfessionalsGridAsync();
                        ResetInputFields();
                    });
                }
            }
        }

        private List<int> GetSelectedSpecialtyIds()
        {
            var specialtyIds = new List<int>();
            
            foreach (var item in checkedListBoxSpecialties.CheckedItems)
            {
                string specialtyName = item.ToString()!;
                var specialty = _availableSpecialties.FirstOrDefault(s => s.Name == specialtyName);
                
                if (specialty != null) 
                    specialtyIds.Add(specialty.Id);
            }

            return specialtyIds;
        }

        private ProfessionalCreateDto MapFieldsToCreateDto()
        {
            return new ProfessionalCreateDto
            {
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                LicenseNumber = textBoxLicenseNumber.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                AppointmentDuration = (int)numericUpDownDuration.Value,
                Observations = textBoxObservations.Text.Trim(),
                SpecialtyIds = GetSelectedSpecialtyIds(),
                Schedules = _currentSchedules.ToList()
            };
        }

        private ProfessionalUpdateDto MapFieldsToUpdateDto(int id)
        {
            return new ProfessionalUpdateDto
            {
                Id = id,
                DocumentNumber = textBoxDocumentNumber.Text.Trim(),
                LicenseNumber = textBoxLicenseNumber.Text.Trim(),
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                AppointmentDuration = (int)numericUpDownDuration.Value,
                Observations = textBoxObservations.Text.Trim(),
                SpecialtyIds = GetSelectedSpecialtyIds(),
                Schedules = _currentSchedules.ToList()
            };
        }
    }
}
