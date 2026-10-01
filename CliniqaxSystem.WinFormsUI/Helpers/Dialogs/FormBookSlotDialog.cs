using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using System.Data;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormBookSlotDialog : Form
    {
        public int SelectedPatientId => (int)(comboBoxPatients.SelectedValue ?? 0);
        public int SelectedSpecialtyId => (int)(comboBoxSpecialties.SelectedValue ?? 0);
        public string? Observations => textBoxObservations.Text.Trim();

        private readonly IPatientService _patientService;
        private readonly ProfessionalDto _professional;
        private List<PatientDto> _allPatients = new();

        public FormBookSlotDialog(IPatientService patientService, ProfessionalDto professional)
        {
            _patientService = patientService;
            _professional = professional;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonConfirm, this.picIconConfirm);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Eventos
            this.Load += async (s, e) => await InitializeDialogDataAsync();
            this.textBoxSearchPatient.TextChanged += (s, e) => FilterPatientsList();
            this.buttonConfirm.Click += (s, e) => ValidateAndConfirm();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task InitializeDialogDataAsync()
        {
            labelProfessionalDisplay.Text = $"Profesional: {_professional.FullName}";

            using (new WaitCursorHelper(this))
            {
                // Cargar pacientes
                var patients = await _patientService.GetAllAsync();
                _allPatients = patients.ToList();
                FilterPatientsList();

                // Cargar especialidades exclusivas del médico
                var specialtiesList = _professional.SpecialtyIds
                    .Zip(_professional.SpecialtyNames, (id, name) => new { Id = id, Name = name })
                    .ToList();

                comboBoxSpecialties.DataSource = specialtiesList;
                comboBoxSpecialties.DisplayMember = "Name";
                comboBoxSpecialties.ValueMember = "Id";

                if (specialtiesList.Any())
                    comboBoxSpecialties.SelectedIndex = 0;
            }
        }

        private void FilterPatientsList()
        {
            string term = textBoxSearchPatient.Text.Trim().ToLower();

            var matches = _allPatients.Where(p =>
                            p.DocumentNumber.Contains(term) ||
                            p.LastName.ToLower().Contains(term) ||
                            p.FirstName.ToLower().Contains(term)
                            ).ToList();

            comboBoxPatients.DataSource = null;
            comboBoxPatients.DataSource = matches;
            comboBoxPatients.DisplayMember = "FullName";
            comboBoxPatients.ValueMember = "Id";

            if (matches.Any())
                comboBoxPatients.SelectedIndex = 0;
        }

        private void ValidateAndConfirm()
        {
            if (SelectedPatientId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un paciente para el turno.", "Selección Requerida");
                comboBoxPatients.Focus();
                return;
            }

            if (SelectedSpecialtyId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una especialidad médica.", "Selección Requerida");
                comboBoxSpecialties.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
