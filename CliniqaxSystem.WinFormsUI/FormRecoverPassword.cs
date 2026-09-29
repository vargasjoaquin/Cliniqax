using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormRecoverPassword : Form
    {
        private readonly IAuthService _authService;

        public FormRecoverPassword(IAuthService authService)
        {
            _authService = authService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelCard);

            this.BackColor = UIThemeHelper.SidebarBackground;

            // Vinculación de iconos overlay
            ButtonIconOverlayHelper.BindEvents(this.buttonSendRecovery, this.picIconSendRecovery);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.buttonSendRecovery.Click += async (s, e) => await ExecuteSendRecoveryAsync();
            this.buttonCancel.Click += (s, e) => this.Close();
            this.buttonCloseDialog.Click += (s, e) => this.Close();
            this.textBoxIdentity.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) await ExecuteSendRecoveryAsync();
            };
        }

        private async Task ExecuteSendRecoveryAsync()
        {
            string id = textBoxIdentity.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                UIHelper.WarnMessage(this, "Por favor ingrese su usuario o correo electrónico.", "Campo Requerido");
                textBoxIdentity.Focus();
                return;
            }

            buttonSendRecovery.Enabled = false;
            buttonSendRecovery.Text = "VERIFICANDO...";
            labelResultStatus.Text = string.Empty;

            using (new WaitCursorHelper(this))
            {
                var result = await _authService.SendPasswordResetAsync(id);
                if (result.Success)
                {
                    labelResultStatus.Text = result.Message;
                    labelResultStatus.ForeColor = UIThemeHelper.Success;
                    UIHelper.InfoMessage(this, result.Message, "Recuperación de Contraseña");
                }
                else
                {
                    labelResultStatus.Text = result.Message;
                    labelResultStatus.ForeColor = UIThemeHelper.Danger;
                    UIHelper.WarnMessage(this, result.Message, "Cuenta no encontrada");
                }
            }

            buttonSendRecovery.Enabled = true;
            buttonSendRecovery.Text = "ENVIAR SOLICITUD";
        }
    }
}
