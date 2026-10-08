using CliniqaxSystem.Application.DTOs.Clinical;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormConsultationEntry : Form
    {
        private readonly IClinicalService _clinicalService;
        private readonly IPatientService _patientService;
        private readonly IProfessionalService _professionalService;
        private readonly ICurrentUserService _currentUserService;

        private readonly int _patientId;
        private readonly int? _appointmentId;
        private int? _initialProfessionalId;
        private int? _initialSpecialtyId;

        private PatientDto? _patient;
        private List<ProfessionalDto> _professionals = new();
        private List<DiagnosisTypeDto> _diagnosisTypes = new();
        private List<ClinicalDiagnosisCreateDto> _currentDiagnoses = new();

        public FormConsultationEntry(IClinicalService clinicalService, IPatientService patientService, IProfessionalService professionalService, ICurrentUserService currentUserService, int patientId, int? appointmentId = null, int? professionalId = null, int? specialtyId = null)
        {
            _clinicalService = clinicalService;
            _patientService = patientService;
            _professionalService = professionalService;
            _currentUserService = currentUserService;

            _patientId = patientId;
            _appointmentId = appointmentId;
            _initialProfessionalId = professionalId;
            _initialSpecialtyId = specialtyId;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelPatientSummaryCard);
            UIThemeHelper.ApplyCardStyle(panelFormContainer);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveConsultation, this.picIconSave);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Eventos
            this.Load += async (s, e) => await InitializeFormAsync();
            this.comboBoxProfessionals.SelectedIndexChanged += (s, e) => OnProfessionalSelectionChanged();
            this.buttonAddDiagnosis.Click += (s, e) => AddDiagnosisToList();
            this.buttonRemoveDiagnosis.Click += (s, e) => RemoveSelectedDiagnosis();
            this.buttonSaveConsultation.Click += async (s, e) => await ExecuteSaveConsultationAsync();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        public FormConsultationEntry(IClinicalService clinicalService, IPatientService patientService, int patientId)
            : this(clinicalService, patientService, null!, null!, patientId)
        {
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                _patient = await _patientService.GetByIdAsync(_patientId);
                
                if (_patient != null)
                {
                    labelPatientName.Text = _patient.FullName.ToUpper();
                    labelPatientInfo.Text = $"DNI: {_patient.DocumentNumber}  |  Edad: {_patient.Age} años  |  Cobertura: {_patient.HealthInsuranceName ?? "Particular"}";
                }

                _professionals = (await _professionalService.GetAllAsync()).Where(p => p.IsActive).ToList();
                comboBoxProfessionals.DataSource = _professionals;
                comboBoxProfessionals.DisplayMember = "FullName";
                comboBoxProfessionals.ValueMember = "Id";

                _diagnosisTypes = (await _clinicalService.GetDiagnosisTypesAsync()).ToList();
                comboBoxDiagnosisType.DataSource = _diagnosisTypes;
                comboBoxDiagnosisType.DisplayMember = "Name";
                comboBoxDiagnosisType.ValueMember = "Id";
                comboBoxDiagnosisType.SelectedValue = DiagnosisTypeConstants.DEFINITIVE;

                if (_initialProfessionalId.HasValue && _initialProfessionalId.Value > 0)
                {
                    comboBoxProfessionals.SelectedValue = _initialProfessionalId.Value;
                }
                else if (_currentUserService?.RoleName?.Equals(RoleConstants.PROFESSIONAL, StringComparison.OrdinalIgnoreCase) == true)
                {
                    var match = _professionals.FirstOrDefault(p => p.DocumentNumber == _currentUserService.Username);
                    
                    if (match != null) 
                        comboBoxProfessionals.SelectedValue = match.Id;
                }
                else if (_professionals.Any())
                {
                    comboBoxProfessionals.SelectedIndex = 0;
                }

                OnProfessionalSelectionChanged();

                if (_initialSpecialtyId.HasValue && _initialSpecialtyId.Value > 0)
                {
                    comboBoxSpecialties.SelectedValue = _initialSpecialtyId.Value;
                }

                dateTimePickerDate.Value = DateTime.Now;
                RefreshDiagnosesGrid();
            }
        }

        private void OnProfessionalSelectionChanged()
        {
            if (comboBoxProfessionals.SelectedItem is ProfessionalDto prof)
            {
                var specialties = prof.SpecialtyIds
                    .Zip(prof.SpecialtyNames, (id, name) => new { Id = id, Name = name })
                    .ToList();

                comboBoxSpecialties.DataSource = specialties;
                comboBoxSpecialties.DisplayMember = "Name";
                comboBoxSpecialties.ValueMember = "Id";

                if (specialties.Any())
                    comboBoxSpecialties.SelectedIndex = 0;
            }
        }

        private void AddDiagnosisToList()
        {
            string desc = textBoxDiagnosisDescription.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(desc))
            {
                UIHelper.WarnMessage(this, "Debe ingresar una descripción para el diagnóstico.", "Campo Requerido");
                textBoxDiagnosisDescription.Focus();
                return;
            }

            int typeId = (int)(comboBoxDiagnosisType.SelectedValue ?? DiagnosisTypeConstants.DEFINITIVE);
            string typeName = comboBoxDiagnosisType.Text;

            _currentDiagnoses.Add(new ClinicalDiagnosisCreateDto
            {
                DiagnosisTypeId = typeId,
                Description = desc,
                DiagnosticCode = textBoxCie10.Text.Trim().ToUpper(),
                Notes = textBoxDiagnosisNotes.Text.Trim()
            });

            textBoxDiagnosisDescription.Clear();
            textBoxCie10.Clear();
            textBoxDiagnosisNotes.Clear();
            comboBoxDiagnosisType.SelectedValue = DiagnosisTypeConstants.DEFINITIVE;

            RefreshDiagnosesGrid();
            textBoxDiagnosisDescription.Focus();
        }

        private void RemoveSelectedDiagnosis()
        {
            if (dataGridViewDiagnoses.CurrentRow?.DataBoundItem is ClinicalDiagnosisCreateDto selected)
            {
                _currentDiagnoses.Remove(selected);
                RefreshDiagnosesGrid();
            }
        }

        private void RefreshDiagnosesGrid()
        {
            dataGridViewDiagnoses.DataSource = null;
            dataGridViewDiagnoses.DataSource = _currentDiagnoses.ToList();
            UIHelper.FormatGrid(dataGridViewDiagnoses);
        }

        private async Task ExecuteSaveConsultationAsync()
        {
            string reason = textBoxReasonForConsultation.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(reason))
            {
                UIHelper.WarnMessage(this, "El motivo de consulta es obligatorio.", "Validación");
                tabControlConsultation.SelectedTab = tabPageAnamnesis;
                textBoxReasonForConsultation.Focus();
                return;
            }

            if (comboBoxProfessionals.SelectedValue is not int professionalId || professionalId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un profesional médico.", "Validación");
                comboBoxProfessionals.Focus();
                return;
            }

            if (comboBoxSpecialties.SelectedValue is not int specialtyId || specialtyId <= 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar una especialidad médica.", "Validación");
                comboBoxSpecialties.Focus();
                return;
            }

            var instructionsList = new List<MedicalInstructionCreateDto>();
            string instructionsText = textBoxInstructions.Text.Trim();
            string medicationText = textBoxMedicationDetails.Text.Trim();
            string followUpText = textBoxFollowUpNotes.Text.Trim();

            if (!string.IsNullOrWhiteSpace(instructionsText) || !string.IsNullOrWhiteSpace(medicationText) || !string.IsNullOrWhiteSpace(followUpText))
            {
                instructionsList.Add(new MedicalInstructionCreateDto
                {
                    Instructions = string.IsNullOrWhiteSpace(instructionsText) ? "Pautas de cuidado general." : instructionsText,
                    MedicationDetails = medicationText,
                    FollowUpNotes = followUpText
                });
            }

            var dto = new ConsultationCreateDto
            {
                PatientId = _patientId,
                ProfessionalId = professionalId,
                SpecialtyId = specialtyId,
                AppointmentId = _appointmentId,
                ConsultationDate = dateTimePickerDate.Value,
                ReasonForConsultation = reason,
                PhysicalExamination = textBoxPhysicalExamination.Text.Trim(),
                EvolutionNotes = textBoxEvolutionNotes.Text.Trim(),
                Notes = textBoxPrivateNotes.Text.Trim(),
                Diagnoses = _currentDiagnoses.ToList(),
                Instructions = instructionsList
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _clinicalService.RegisterConsultationAsync(dto);
                
                if (result.Success)
                {
                    UIHelper.ShowResult(result, "Atención Médica Finalizada");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UIHelper.ShowResult(result, "Error al Guardar Consulta");
                }
            }
        }
    }
}