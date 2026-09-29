using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using System.Data;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormLicenseActivation : Form
    {
        private readonly ILicenseManagerService _licenseService;
        private readonly string? _reasonMessage;

        public FormLicenseActivation(ILicenseManagerService licenseService, string? reasonMessage = null)
        {
            _licenseService = licenseService;
            _reasonMessage = reasonMessage;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            this.Load += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(_reasonMessage))
                    labelReason.Text = _reasonMessage;

                textBoxCuit.Focus();
            };

            this.textBoxCuit.TextChanged += (s, e) => FormatterHelper.HandleCuitFormat(textBoxCuit);

            this.textBoxKey1.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey1, textBoxKey2, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey2.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey2, textBoxKey3, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey3.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey3, textBoxKey4, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);
            this.textBoxKey4.TextChanged += (s, e) => FormatterHelper.HandleLicenseKeyChange(textBoxKey4, null, textBoxKey1, textBoxKey2, textBoxKey3, textBoxKey4);

            this.textBoxKey2.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey2, textBoxKey1, e);
            this.textBoxKey3.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey3, textBoxKey2, e);
            this.textBoxKey4.KeyDown += (s, e) => FormatterHelper.HandleLicenseKeyBackspace(textBoxKey4, textBoxKey3, e);

            this.buttonActivate.Click += async (s, e) => await ExecuteActivationAsync();
            this.buttonExit.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private async Task ExecuteActivationAsync()
        {
            string cuit = textBoxCuit.Text.Trim();
            string cleanCuit = new string(cuit.Where(char.IsDigit).ToArray());

            string k1 = textBoxKey1.Text.Trim().ToUpper();
            string k2 = textBoxKey2.Text.Trim().ToUpper();
            string k3 = textBoxKey3.Text.Trim().ToUpper();
            string k4 = textBoxKey4.Text.Trim().ToUpper();
            string fullKey = $"{k1}-{k2}-{k3}-{k4}";

            if (cleanCuit.Length < 11)
            {
                UIHelper.WarnMessage(this, "El CUIT debe contener 11 dígitos numéricos.", "CUIT Inválido");
                textBoxCuit.Focus();
                return;
            }

            if (k1.Length < 4 || k2.Length < 4 || k3.Length < 4 || k4.Length < 4)
            {
                UIHelper.WarnMessage(this, "La clave de licencia debe tener 16 caracteres (4 bloques de 4).", "Clave Incompleta");
                return;
            }

            buttonActivate.Enabled = false;
            buttonActivate.Text = "CONECTANDO CON SERVIDOR...";
            labelStatus.Text = "Validando licencia con el servidor central...";
            labelStatus.ForeColor = UIThemeHelper.Primary;

            try
            {
                var result = await _licenseService.ActivateOnlineAsync(cuit, fullKey);
                if (result.Success)
                {
                    UIHelper.InfoMessage(this, "¡Sistema Cliniqax activado con éxito!", "Activación Aprobada");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    labelStatus.Text = result.Message;
                    labelStatus.ForeColor = UIThemeHelper.Danger;
                    UIHelper.WarnMessage(this, result.Message, "Activación Rechazada");
                }
            }
            catch (Exception ex)
            {
                UIHelper.ErrorMessage(this, $"Error de red:\n{ex.Message}", "Fallo de Comunicación");
            }
            finally
            {
                buttonActivate.Enabled = true;
                buttonActivate.Text = "ACTIVAR EN LÍNEA";
            }
        }
    }
}
