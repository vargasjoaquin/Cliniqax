using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CliniqaxSystem.WinFormsUI
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentUserService _currentUserService;
        
        public FormLogin(IAuthService authService, IServiceProvider serviceProvider, ICurrentUserService currentUserService)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
            _currentUserService = currentUserService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            UIThemeHelper.ApplyCardStyle(panelLoginCard);

            ButtonIconOverlayHelper.BindEvents(this.buttonLogin, this.picIconLogin);

            this.BackColor = UIThemeHelper.SidebarBackground;

            this.buttonLogin.Click += async (s, e) => await ExecuteLoginAsync();
            this.buttonClose.Click += (s, e) => System.Windows.Forms.Application.Exit();
            this.textBoxPassword.KeyDown += async (s, e) => { if (e.KeyCode == Keys.Enter) await ExecuteLoginAsync(); };
            this.textBoxUsername.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) textBoxPassword.Focus(); };

            this.linkLabelForgotPassword.LinkClicked += (s, e) =>
            {
                var recoveryDialog = _serviceProvider.GetRequiredService<FormRecoverPassword>();
                recoveryDialog.ShowDialog(this);
            };
        }

        private async Task ExecuteLoginAsync()
        {
            labelErrorMessage.Visible = false;

            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Por favor, ingrese su nombre de usuario.");
                textBoxUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Por favor, ingrese su contraseña.");
                textBoxPassword.Focus();
                return;
            }

            using (new WaitCursorHelper(this))
            {
                try
                {
                    var result = await _authService.LoginAsync(username, password);

                    if (result.Success)
                    {
                        this.Hide();
                        
                        var mainControlPanel = _serviceProvider.GetRequiredService<FormPanelControl>();
                        mainControlPanel.Show();
                    }
                    else
                    {
                        ShowError(result.Message);
                        textBoxPassword.SelectAll();
                        textBoxPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    UIHelper.ErrorMessage(this, $"Error de comunicación:\n{ex.Message}", "Fallo de Inicio de Sesión");
                }
            }
        }

        private void ShowError(string message)
        {
            labelErrorMessage.Text = message;
            labelErrorMessage.ForeColor = UIThemeHelper.Danger;
            labelErrorMessage.Visible = true;
        }
    }
}
