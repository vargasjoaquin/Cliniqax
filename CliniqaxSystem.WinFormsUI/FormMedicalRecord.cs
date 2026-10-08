using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.Interfaces.Common;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using CliniqaxSystem.WinFormsUI.Helpers.Dialogs;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormMedicalRecord : Form
    {
        private readonly IClinicalService _clinicalService;
        private readonly IPatientService _patientService;
        private readonly IAppEventBus _eventBus;
        private readonly IServiceProvider _serviceProvider;

        private int _selectedPatientId = 0;
        private MedicalRecordDto? _currentRecord;
        private List<PatientDto> _allPatients = new();

        public FormMedicalRecord(IClinicalService clinicalService, IPatientService patientService, IAppEventBus eventBus, IServiceProvider serviceProvider, int initialPatientId = 0)
        {
            _clinicalService = clinicalService;
            _patientService = patientService;
            _eventBus = eventBus;
            _serviceProvider = serviceProvider;
            _selectedPatientId = initialPatientId;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelPatientSelectorCard);
            UIThemeHelper.ApplyCardStyle(panelAntecedentesCard);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveAntecedentes, this.picIconSaveAntecedentes);
            ButtonIconOverlayHelper.BindEvents(this.buttonNewConsultation, this.picIconNewConsultation);
            ButtonIconOverlayHelper.BindEvents(this.buttonViewConsultation, this.picIconViewConsultation);
            ButtonIconOverlayHelper.BindEvents(this.buttonUploadAttachment, this.picIconUploadAttachment);
            ButtonIconOverlayHelper.BindEvents(this.buttonDownloadAttachment, this.picIconDownloadAttachment);
            ButtonIconOverlayHelper.BindEvents(this.buttonDeleteAttachment, this.picIconDeleteAttachment);

            // Eventos de controles
            this.Load += async (s, e) => await InitializeFormAsync();
            this.comboBoxPatients.SelectedIndexChanged += async (s, e) => await OnPatientSelectionChangedAsync();
            this.buttonSaveAntecedentes.Click += async (s, e) => await ExecuteSaveAntecedentesAsync();
            this.buttonNewConsultation.Click += (s, e) => OpenNewConsultationForm();
            this.buttonViewConsultation.Click += async (s, e) => await OpenConsultationDetailDialogAsync();
            this.buttonUploadAttachment.Click += async (s, e) => await OpenUploadAttachmentDialogAsync();
            this.buttonDownloadAttachment.Click += async (s, e) => await ExecuteDownloadAttachmentAsync();
            this.buttonDeleteAttachment.Click += async (s, e) => await ExecuteDeleteAttachmentAsync();

            this.dataGridViewConsultations.CellDoubleClick += async (s, e) => await OpenConsultationDetailDialogAsync();
            this.dataGridViewAttachments.CellDoubleClick += async (s, e) => await ExecuteDownloadAttachmentAsync();

            // Suscripción en tiempo real
            _eventBus.Subscribe<ClinicalRecordChangedEvent>(evt =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(async () =>
                    {
                        if (_selectedPatientId > 0 && (evt.PatientId == null || evt.PatientId == _selectedPatientId))
                        {
                            await LoadMedicalRecordAsync(_selectedPatientId);
                        }
                    });
                }
            });
        }

        private async Task InitializeFormAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var patients = await _patientService.GetAllAsync();
                _allPatients = patients.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();

                comboBoxPatients.DataSource = _allPatients;
                comboBoxPatients.DisplayMember = "FullName";
                comboBoxPatients.ValueMember = "Id";

                if (_selectedPatientId > 0)
                {
                    comboBoxPatients.SelectedValue = _selectedPatientId;
                    await LoadMedicalRecordAsync(_selectedPatientId);
                }
                else if (_allPatients.Any())
                {
                    comboBoxPatients.SelectedIndex = 0;
                }
            }
        }

        private async Task OnPatientSelectionChangedAsync()
        {
            if (comboBoxPatients.SelectedValue is int patientId && patientId > 0)
            {
                _selectedPatientId = patientId;
                await LoadMedicalRecordAsync(patientId);
            }
        }

        public async Task LoadMedicalRecordAsync(int patientId)
        {
            using (new WaitCursorHelper(this))
            {
                _currentRecord = await _clinicalService.GetMedicalRecordByPatientIdAsync(patientId);
                
                if (_currentRecord == null)
                    return;

                // 1. Resumen de cabecera
                labelPatientNameDisplay.Text = $"{_currentRecord.PatientFullName.ToUpper()}";
                labelPatientDetailsDisplay.Text = $"DNI: {_currentRecord.PatientDocument}  |  Edad: {_currentRecord.PatientAge} años  |  Cobertura: {_currentRecord.PatientHealthInsurance}";
                labelRecordNumberBadge.Text = $"[{_currentRecord.RecordNumber}]";

                // 2. Antecedentes
                textBoxBloodType.Text = _currentRecord.BloodType ?? string.Empty;
                textBoxAllergies.Text = _currentRecord.Allergies ?? string.Empty;
                textBoxPathological.Text = _currentRecord.PathologicalHistory ?? string.Empty;
                textBoxNonPathological.Text = _currentRecord.NonPathologicalHistory ?? string.Empty;
                textBoxSurgical.Text = _currentRecord.SurgicalHistory ?? string.Empty;
                textBoxFamily.Text = _currentRecord.FamilyHistory ?? string.Empty;
                textBoxGeneralObservations.Text = _currentRecord.GeneralObservations ?? string.Empty;

                // 3. Consultas (Historial)
                dataGridViewConsultations.DataSource = null;
                dataGridViewConsultations.DataSource = _currentRecord.Consultations;
                UIHelper.FormatGrid(dataGridViewConsultations);

                // 4. Adjuntos
                dataGridViewAttachments.DataSource = null;
                dataGridViewAttachments.DataSource = _currentRecord.MedicalAttachments;
                UIHelper.FormatGrid(dataGridViewAttachments);
            }
        }

        private async Task ExecuteSaveAntecedentesAsync()
        {
            if (_selectedPatientId <= 0)
                return;

            var dto = new MedicalRecordUpdateDto
            {
                PatientId = _selectedPatientId,
                BloodType = textBoxBloodType.Text.Trim(),
                Allergies = textBoxAllergies.Text.Trim(),
                PathologicalHistory = textBoxPathological.Text.Trim(),
                NonPathologicalHistory = textBoxNonPathological.Text.Trim(),
                SurgicalHistory = textBoxSurgical.Text.Trim(),
                FamilyHistory = textBoxFamily.Text.Trim(),
                GeneralObservations = textBoxGeneralObservations.Text.Trim()
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _clinicalService.UpdateMedicalRecordAsync(dto);
                UIHelper.ShowResult(result, "Historia Clínica");
            }
        }

        private void OpenNewConsultationForm()
        {
            if (_selectedPatientId <= 0) 
                return;

            var form = new FormConsultationEntry(_clinicalService, _patientService, _selectedPatientId);
            
            form.ShowDialog(this);
        }

        private async Task OpenConsultationDetailDialogAsync()
        {
            if (dataGridViewConsultations.CurrentRow?.DataBoundItem is ConsultationSummaryDto summary)
            {
                var consultation = await _clinicalService.GetConsultationByIdAsync(summary.Id);
                
                if (consultation != null)
                {
                    using var dialog = new FormConsultationDetailDialog(consultation);
                    dialog.ShowDialog(this);
                }
            }
            else
            {
                UIHelper.WarnMessage(this, "Seleccione una consulta de la lista para ver su detalle.", "Aviso");
            }
        }

        private async Task OpenUploadAttachmentDialogAsync()
        {
            if (_selectedPatientId <= 0) 
                return;

            var categories = await _clinicalService.GetAttachmentCategoriesAsync();
            using var dialog = new FormUploadAttachmentDialog(_clinicalService, _selectedPatientId, categories);

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                await LoadMedicalRecordAsync(_selectedPatientId);
            }
        }

        private async Task ExecuteDownloadAttachmentAsync()
        {
            if (dataGridViewAttachments.CurrentRow?.DataBoundItem is MedicalAttachmentDto att)
            {
                using (new WaitCursorHelper(this))
                {
                    var fileBytes = await _clinicalService.DownloadAttachmentFileAsync(att.Id);
                    if (fileBytes != null)
                    {
                        await FileExportHelper.SaveAndOpenFileAsync(this, fileBytes, att.OriginalFileName, $"Archivos ({att.FileExtension})|*{att.FileExtension}", "Guardar Estudio");
                    }
                    else
                    {
                        UIHelper.ErrorMessage(this, "No se pudo recuperar el archivo físico desde el almacenamiento.", "Error de Archivo");
                    }
                }
            }
            else
            {
                UIHelper.WarnMessage(this, "Seleccione un archivo de la lista para descargarlo o abrirlo.", "Aviso");
            }
        }

        private async Task ExecuteDeleteAttachmentAsync()
        {
            if (dataGridViewAttachments.CurrentRow?.DataBoundItem is MedicalAttachmentDto att)
            {
                if (UIHelper.ConfirmMessage($"¿Desea eliminar el archivo adjunto '{att.OriginalFileName}'?", "Confirmar Eliminación"))
                {
                    using (new WaitCursorHelper(this))
                    {
                        var result = await _clinicalService.DeleteAttachmentAsync(att.Id);
                        UIHelper.ShowResult(result, "Archivos Adjuntos", async () =>
                        {
                            await LoadMedicalRecordAsync(_selectedPatientId);
                        });
                    }
                }
            }
        }
    }
}