using CliniqaxSystem.Application.DTOs.Clinical.Attachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormUploadAttachmentDialog : Form
    {
        private readonly IClinicalService _clinicalService;
        private readonly int _patientId;
        private readonly int? _consultationId;
        private readonly IEnumerable<AttachmentCategoryDto> _categories;

        private byte[]? _selectedFileBytes;
        private string _originalFileName = string.Empty;

        public FormUploadAttachmentDialog(
            IClinicalService clinicalService,
            int patientId,
            IEnumerable<AttachmentCategoryDto> categories,
            int? consultationId = null)
        {
            _clinicalService = clinicalService;
            _patientId = patientId;
            _categories = categories;
            _consultationId = consultationId;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            // Vinculación de iconos superpuestos
            ButtonIconOverlayHelper.BindEvents(this.buttonUpload, this.picIconUpload);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            // Eventos
            this.Load += (s, e) => InitializeDialog();
            this.buttonBrowseFile.Click += (s, e) => HandleSelectFile();
            this.buttonUpload.Click += async (s, e) => await ExecuteUploadAsync();
            this.buttonCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void InitializeDialog()
        {
            comboBoxCategories.DataSource = _categories.ToList();
            comboBoxCategories.DisplayMember = "Name";
            comboBoxCategories.ValueMember = "Id";

            if (_categories.Any())
                comboBoxCategories.SelectedIndex = 0;
        }

        private void HandleSelectFile()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar Estudio o Documento Adjunto",
                Filter = "Todos los Archivos Médicos|*.pdf;*.jpg;*.jpeg;*.png;*.webp;*.dcm;*.txt;*.zip;*.rar;*.docx|Documentos PDF (*.pdf)|*.pdf|Imágenes (*.jpg;*.png)|*.jpg;*.jpeg;*.png|Estudios DICOM (*.dcm)|*.dcm|Todos los Archivos (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    _originalFileName = Path.GetFileName(ofd.FileName);
                    _selectedFileBytes = File.ReadAllBytes(ofd.FileName);

                    textBoxFileName.Text = $"{_originalFileName} ({FormatFileSize(_selectedFileBytes.Length)})";
                    buttonUpload.Enabled = true;
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"No se pudo leer el archivo seleccionado:\n{ex.Message}", "Error de Lectura");
                }
            }
        }

        private async Task ExecuteUploadAsync()
        {
            if (_selectedFileBytes == null || _selectedFileBytes.Length == 0)
            {
                UIHelper.WarnMessage(this, "Debe seleccionar un archivo antes de guardar.", "Archivo Requerido");
                buttonBrowseFile.Focus();
                return;
            }

            int? categoryId = comboBoxCategories.SelectedValue is int catId && catId > 0 ? catId : null;

            var dto = new MedicalAttachmentCreateDto
            {
                PatientId = _patientId,
                ConsultationId = _consultationId,
                AttachmentCategoryId = categoryId,
                OriginalFileName = _originalFileName,
                FileBytes = _selectedFileBytes,
                Notes = textBoxNotes.Text.Trim()
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _clinicalService.UploadAttachmentAsync(dto);
                if (result.Success)
                {
                    UIHelper.ShowResult(result, "Archivo Adjuntado");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    UIHelper.ShowResult(result, "Error de Almacenamiento");
                }
            }
        }

        private static string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes / (1024.0 * 1024.0):F2} MB";
        }
    }
}
