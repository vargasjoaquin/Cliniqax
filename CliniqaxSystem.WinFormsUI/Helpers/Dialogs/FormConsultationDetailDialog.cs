using CliniqaxSystem.Application.DTOs.Clinical;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormConsultationDetailDialog : Form
    {
        private readonly ConsultationDto _consultation;

        public FormConsultationDetailDialog(ConsultationDto consultation)
        {
            _consultation = consultation;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelHeaderSummaryCard);
            UIThemeHelper.ApplyCardStyle(panelDetailsContainer);

            // Vinculación de icono
            ButtonIconOverlayHelper.BindEvents(this.buttonClose, this.picIconClose);

            this.Load += (s, e) => LoadConsultationData();
            this.buttonClose.Click += (s, e) => this.Close();
        }

        private void LoadConsultationData()
        {
            labelPatientName.Text = _consultation.PatientFullName.ToUpper();
            labelPatientDocument.Text = $"DNI: {_consultation.PatientDocument}";
            labelProfessionalInfo.Text = $"Atendido por: {_consultation.ProfessionalName} (Mat. {_consultation.ProfessionalLicense}) - {_consultation.SpecialtyName}";
            labelConsultationDate.Text = $"Fecha: {_consultation.ConsultationDate:dd/MM/yyyy HH:mm}";
            labelStatusBadge.Text = $"[{_consultation.StatusName.ToUpper()}]";

            // Anamnesis y Examen
            textBoxReason.Text = _consultation.ReasonForConsultation;
            textBoxPhysicalExam.Text = _consultation.PhysicalExamination ?? "Sin datos registrados.";

            var evolution = _consultation.Evolutions.FirstOrDefault();
            textBoxEvolution.Text = evolution != null ? evolution.Description : "Sin evolución registrada.";

            // Diagnósticos
            dataGridViewDiagnoses.DataSource = null;
            dataGridViewDiagnoses.DataSource = _consultation.Diagnoses.ToList();
            UIHelper.FormatGrid(dataGridViewDiagnoses);

            // Indicaciones
            var instruction = _consultation.Instructions.FirstOrDefault();
            if (instruction != null)
            {
                textBoxInstructions.Text = instruction.Instructions;
                textBoxMedication.Text = instruction.MedicationDetails ?? "Sin medicación indicada.";
                textBoxFollowUp.Text = instruction.FollowUpNotes ?? "Sin control pautado.";
            }
            else
            {
                textBoxInstructions.Text = "Sin indicaciones específicas registradas.";
                textBoxMedication.Text = "Sin medicación.";
                textBoxFollowUp.Text = "-";
            }
        }
    }
}