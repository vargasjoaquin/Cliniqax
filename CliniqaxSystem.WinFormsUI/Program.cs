using CliniqaxSystem.Application;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Infrastructure;
using CliniqaxSystem.Infrastructure.Persistence;
using CliniqaxSystem.WinFormsUI.Helpers.Dialogs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CliniqaxSystem.WinFormsUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();

            try
            {
                using var scope = host.Services.CreateScope();
                
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!db.Database.CanConnect())
                {
                    MessageBox.Show(
                        "No se pudo establecer conexión con Microsoft SQL Server.\n\n" +
                        "Por favor verifique que:\n" +
                        "1. El servicio de SQL Server esté iniciado.\n" +
                        "2. La base de datos 'Cliniqax' haya sido creada con el script SQL.\n" +
                        "3. La cadena de conexión en 'appsettings.json' sea correcta.",
                        "Error de Base de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                DbInitializer.SeedAsync(db).GetAwaiter().GetResult();

                var licenseService = scope.ServiceProvider.GetRequiredService<ILicenseManagerService>();
                var licenseValidation = licenseService.ValidateInstalledLicenseAsync().GetAwaiter().GetResult();

                if (!licenseValidation.Success || licenseService.CurrentLicense == null || !licenseService.CurrentLicense.IsValid || licenseService.CurrentLicense.IsExpired)
                {
                    // Licencia no instalada, alterada o expirada -> Bloqueo y diálogo de activación
                    using var activationForm = new FormLicenseActivation(licenseService, licenseValidation.Message);
                    if (activationForm.ShowDialog() != DialogResult.OK)
                    {
                        return; // Bloquea el inicio si se cancela la activación
                    }
                }
                else if (licenseService.CurrentLicense.IsExpiredSoon)
                {
                    // Licencia válida pero próxima a vencer (<= 7 días) -> Aviso diario informativo
                    using var warningDialog = new FormLicenseWarningDialog(licenseService.CurrentLicense, licenseService);
                    warningDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                string detail = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(
                    $"Fallo crítico durante el arranque del sistema:\n\n{detail}",
                    "Error al Inicializar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var loginForm = host.Services.GetRequiredService<FormLogin>();
            System.Windows.Forms.Application.Run(loginForm);
        }

        static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices();
                services.AddInfrastructureServices(context.Configuration);

                services.AddTransient<FormLogin>();
                services.AddTransient<FormPanelControl>();
                services.AddTransient<FormHome>();
                services.AddTransient<FormPatients>();
                services.AddTransient<FormProfessionals>();
                services.AddTransient<FormAgenda>();
                services.AddTransient<FormCashSession>();
                services.AddTransient<FormAppointments>();
                services.AddTransient<FormSpecialties>();
                services.AddTransient<FormHealthInsurances>();
                services.AddTransient<FormUsers>();
                services.AddTransient<FormUserProfile>();
                services.AddTransient<FormAppointmentsReport>();
                services.AddTransient<FormIncomeReport>();
                services.AddTransient<FormRestoreRecords>();
                services.AddTransient<FormSettings>();
                services.AddTransient<FormRecoverPassword>();
                services.AddTransient<FormMedicalRecord>();
                services.AddTransient<FormConsultationEntry>();
            });
    }
}