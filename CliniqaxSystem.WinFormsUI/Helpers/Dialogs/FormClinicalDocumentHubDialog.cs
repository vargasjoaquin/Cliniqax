using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormClinicalDocumentHubDialog : Form
    {
        private readonly IClinicalDocumentService _documentService;
        private readonly int _patientId;
        private readonly MedicalRecordDto? _patientRecord;

        public FormClinicalDocumentHubDialog(
            IClinicalDocumentService documentService,
            int patientId,
            MedicalRecordDto? patientRecord)
        {
            _documentService = documentService;
            _patientId = patientId;
            _patientRecord = patientRecord;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelContainerCard);

            // Iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonOfficialPdf, this.picIconOfficialPdf);
            ButtonIconOverlayHelper.BindEvents(this.buttonUploadTemplate, this.picIconUploadTemplate);
            ButtonIconOverlayHelper.BindEvents(this.buttonImportExternal, this.picIconImportExternal);

            // Eventos
            this.Load += (s, e) => InitializePatientInfo();
            this.buttonOfficialPdf.Click += async (s, e) => await ExecuteEmitirExpedienteOficialAsync();
            this.buttonUploadTemplate.Click += async (s, e) => await ExecuteCargarPlantillaCompletadaAsync();
            this.buttonImportExternal.Click += async (s, e) => await ExecuteImportarExternoAsync();
        }

        private void InitializePatientInfo()
        {
            if (_patientRecord != null)
            {
                labelPatientName.Text = $"Paciente: {_patientRecord.PatientFullName.ToUpper()} (DNI: {_patientRecord.PatientDocument})";
                labelRecordNumber.Text = $"Expediente N.°: {_patientRecord.RecordNumber}";
            }
        }

        private async Task ExecuteEmitirExpedienteOficialAsync()
        {
            using (new WaitCursorHelper(this))
            {
                try
                {
                    await _documentService.SyncAndStoreOfficialRecordPdfAsync(_patientId, "Emisión Manual");

                    byte[] pdfBytes = await _documentService.GenerateOfficialMedicalRecordPdfAsync(_patientId);
                    string fileName = $"HC_{_patientRecord?.PatientDocument ?? _patientId.ToString()}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                    await FileExportHelper.SaveAndOpenPdfAsync(this, pdfBytes, fileName, "Expediente Oficial Cliniqax");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error al generar el documento oficial:\n{ex.Message}", "Fallo de Generación");
                }
            }
        }

        private async Task ExecuteCargarPlantillaCompletadaAsync()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Plantilla Cliniqax Completada",
                Filter = "Archivos PDF (*.pdf)|*.pdf|Archivos de Texto (*.txt)|*.txt",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                using (new WaitCursorHelper(this))
                {
                    byte[] fileBytes = await File.ReadAllBytesAsync(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);

                    var result = await _documentService.ProcessFilledTemplateAsync(fileBytes, fileName, _patientId);
                    UIHelper.ShowResult(result, "Carga de Plantilla", () =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    });
                }
            }
        }

        private async Task ExecuteImportarExternoAsync()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Informe Clínico Externo (PDF o Texto)",
                Filter = "Documentos Clínicos (*.pdf;*.txt)|*.pdf;*.txt|Todos los Archivos (*.*)|*.*",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                using (new WaitCursorHelper(this))
                {
                    byte[] fileBytes = await File.ReadAllBytesAsync(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);

                    var result = await _documentService.ImportExternalClinicalDocumentAsync(fileBytes, fileName, _patientId);
                    UIHelper.ShowResult(result, "Importación Externa", () =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    });
                }
            }
        }
    }
}