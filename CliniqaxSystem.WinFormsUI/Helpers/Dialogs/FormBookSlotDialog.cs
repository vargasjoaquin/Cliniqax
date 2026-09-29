using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public class FormBookSlotDialog : Form
    {
        public int SelectedPatientId => (int)(comboBoxPatients.SelectedValue ?? 0);
        public int SelectedSpecialtyId => (int)(comboBoxSpecialties.SelectedValue ?? 0);
        public string? Observations => textBoxObservations.Text.Trim();

        private readonly IPatientService _patientService;
        private readonly ProfessionalDto _professional;

        private ComboBox comboBoxPatients = null!;
        private ComboBox comboBoxSpecialties = null!;
        private TextBox textBoxSearchPatient = null!;
        private TextBox textBoxObservations = null!;
        private Button buttonConfirm = null!;
        private Button buttonCancel = null!;
        private List<PatientDto> _allPatients = new();

        public FormBookSlotDialog(IPatientService patientService, ProfessionalDto professional)
        {
            _patientService = patientService;
            _professional = professional;

            InitializeComponentsCustom();
            UIThemeHelper.ApplyFormStyle(this);

            this.Load += async (s, e) => await LoadDataAsync();
            this.textBoxSearchPatient.TextChanged += (s, e) => FilterPatients();
            this.buttonConfirm.Click += (s, e) => ValidateAndConfirm();
            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private async Task LoadDataAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var patients = await _patientService.GetAllAsync();
                _allPatients = patients.ToList();
                FilterPatients();

                // Cargar las especialidades que atiende ESTE profesional en particular
                var specialtiesList = _professional.SpecialtyIds.Zip(_professional.SpecialtyNames, (id, name) => new { Id = id, Name = name }).ToList();
                comboBoxSpecialties.DataSource = specialtiesList;
                comboBoxSpecialties.DisplayMember = "Name";
                comboBoxSpecialties.ValueMember = "Id";
            }
        }

        private void FilterPatients()
        {
            string term = textBoxSearchPatient.Text.Trim().ToLower();
            var matches = _allPatients.Where(p => p.DocumentNumber.Contains(term) || p.LastName.ToLower().Contains(term) || p.FirstName.ToLower().Contains(term)).ToList();

            comboBoxPatients.DataSource = null;
            comboBoxPatients.DataSource = matches;
            comboBoxPatients.DisplayMember = "FullName";
            comboBoxPatients.ValueMember = "Id";
        }

        private void ValidateAndConfirm()
        {
            if (SelectedPatientId <= 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SelectedSpecialtyId <= 0)
            {
                MessageBox.Show("Debe seleccionar una especialidad médica.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void InitializeComponentsCustom()
        {
            this.Text = "Reservar Turno";
            this.Size = new Size(460, 360);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(248, 250, 252);

            var lblSearch = new Label { Text = "Buscar Paciente (DNI o Apellido):", Location = new Point(20, 15), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            textBoxSearchPatient = new TextBox { Location = new Point(20, 38), Size = new Size(400, 27), Font = new Font("Segoe UI", 10F) };

            var lblPatient = new Label { Text = "Seleccionar Paciente:", Location = new Point(20, 75), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            comboBoxPatients = new ComboBox { Location = new Point(20, 98), Size = new Size(400, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };

            var lblSpec = new Label { Text = "Especialidad de la Consulta:", Location = new Point(20, 135), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            comboBoxSpecialties = new ComboBox { Location = new Point(20, 158), Size = new Size(400, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };

            var lblObs = new Label { Text = "Motivo / Observaciones:", Location = new Point(20, 195), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            textBoxObservations = new TextBox { Location = new Point(20, 218), Size = new Size(400, 27), Font = new Font("Segoe UI", 9.5F) };

            buttonCancel = new Button { Text = "Cancelar", Location = new Point(190, 265), Size = new Size(110, 38), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            buttonConfirm = new Button { Text = "Confirmar Turno", Location = new Point(310, 265), Size = new Size(110, 38), BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            this.Controls.AddRange(new Control[] { lblSearch, textBoxSearchPatient, lblPatient, comboBoxPatients, lblSpec, comboBoxSpecialties, lblObs, textBoxObservations, buttonCancel, buttonConfirm });
        }
    }
}
