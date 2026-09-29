using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormSettings : Form
    {
        private readonly IClinicSettingsService _settingsService;
        private byte[]? _logoBuffer = null;

        public FormSettings(IClinicSettingsService settingsService)
        {
            _settingsService = settingsService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelSettingsCard);

            // Vinculación de icono overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonSaveSettings, this.picIconSaveSettings);

            // Formato de CUIT con máscara
            textBoxCuit.MaxLength = 13;
            textBoxCuit.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxCuit);

            this.Load += async (s, e) => await LoadSettingsAsync();
            this.buttonSaveSettings.Click += async (s, e) => await ExecuteSaveSettingsAsync();
            this.buttonBrowseLogo.Click += (s, e) => HandleLogoSelection();
            this.buttonClearLogo.Click += (s, e) => HandleLogoRemoval();
        }

        private async Task LoadSettingsAsync()
        {
            using (new WaitCursorHelper(this))
            {
                var settings = await _settingsService.GetSettingsAsync();

                textBoxClinicName.Text = settings.ClinicName;
                textBoxCuit.Text = settings.Cuit ?? string.Empty;
                textBoxAddress.Text = settings.Address ?? string.Empty;
                textBoxPhone.Text = settings.Phone ?? string.Empty;
                textBoxEmail.Text = settings.Email ?? string.Empty;
                textBoxFooterMessage.Text = settings.ReceiptFooterMessage ?? string.Empty;
                checkBoxAutoPrint.Checked = settings.AutoPrintReceipt;
                checkBoxShowLogo.Checked = settings.ShowLogoOnReceipt;

                _logoBuffer = settings.Logo;
                ImageHelper.Clear(pictureBoxLogo);
                pictureBoxLogo.Image = ImageHelper.LoadFromBytes(settings.Logo);
            }
        }

        private void HandleLogoSelection()
        {
            if (ImageHelper.SelectImage(out byte[]? bytes, out Image? img, out string? err))
            {
                ImageHelper.Clear(pictureBoxLogo);
                _logoBuffer = bytes;
                pictureBoxLogo.Image = img;
            }
            else if (!string.IsNullOrEmpty(err))
            {
                UIHelper.WarnMessage(this, err, "Logo");
            }
        }

        private void HandleLogoRemoval()
        {
            _logoBuffer = null;
            ImageHelper.Clear(pictureBoxLogo);
        }

        private async Task ExecuteSaveSettingsAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxClinicName.Text))
            {
                UIHelper.WarnMessage(this, "El nombre del consultorio es obligatorio.", "Campo Requerido");
                textBoxClinicName.Focus();
                return;
            }

            var dto = new ClinicSettingsDto
            {
                ClinicName = textBoxClinicName.Text.Trim(),
                Cuit = textBoxCuit.Text.Trim(),
                Address = textBoxAddress.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                ReceiptFormat = "80mm",
                ReceiptFooterMessage = textBoxFooterMessage.Text.Trim(),
                ShowLogoOnReceipt = checkBoxShowLogo.Checked,
                AutoPrintReceipt = checkBoxAutoPrint.Checked,
                Logo = _logoBuffer
            };

            using (new WaitCursorHelper(this))
            {
                var result = await _settingsService.UpdateSettingsAsync(dto);
                UIHelper.ShowResult(result, "Configuración General", async () =>
                {
                    await LoadSettingsAsync();
                });
            }
        }

        private void checkBoxAutoPrint_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
