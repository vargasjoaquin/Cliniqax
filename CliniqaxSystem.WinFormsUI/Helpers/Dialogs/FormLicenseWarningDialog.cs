using CliniqaxSystem.Application.DTOs.License;
using CliniqaxSystem.Application.Interfaces.Services;

namespace CliniqaxSystem.WinFormsUI.Helpers.Dialogs
{
    public partial class FormLicenseWarningDialog : Form
    {
        private readonly LicenseInformationDto _licenseInfo;
        private readonly ILicenseManagerService _licenseService;

        public FormLicenseWarningDialog(LicenseInformationDto licenseInfo, ILicenseManagerService licenseService)
        {
            _licenseInfo = licenseInfo;
            _licenseService = licenseService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            this.Load += (s, e) =>
            {
                int days = _licenseInfo.DaysRemaining ?? 0;
                labelWarningTitle.Text = days == 1
                    ? "¡ATENCIÓN! Le queda ÚNICAMENTE 1 DÍA de vigencia."
                    : $"¡ATENCIÓN! Le quedan {days} DÍAS de vigencia.";

                labelDetails.Text = $"Consultorio: {_licenseInfo.BusinessName}\n" +
                                   $"CUIT: {_licenseInfo.Cuit}\n" +
                                   $"Vencimiento: {_licenseInfo.ExpiresAt?.ToLocalTime():dd/MM/yyyy}\n\n" +
                                   "Le sugerimos renovar su suscripción antes de la fecha límite para evitar interrupciones en la atención.";
            };

            this.buttonContinue.Click += (s, e) => this.Close();
            this.buttonRenew.Click += (s, e) =>
            {
                using var activationForm = new FormLicenseActivation(_licenseService, "Renovación anticipada de licencia");
                if (activationForm.ShowDialog(this) == DialogResult.OK)
                    this.Close();
            };
        }
    }
}
