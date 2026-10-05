using CliniqaxSystem.Application.Configuration;
using CliniqaxSystem.Application.Interfaces.Common;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Infrastructure.Persistence;
using CliniqaxSystem.Infrastructure.Repositories;
using CliniqaxSystem.Infrastructure.Security;
using CliniqaxSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CliniqaxSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Base de Datos SQL Server con EF Core
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? "Server=.;Database=Cliniqax;Integrated Security=True;TrustServerCertificate=True";

                options.UseSqlServer(connectionString)
                       .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
            });

            // 2. Opciones de configuración
            services.Configure<DatabaseBackupSettings>(configuration.GetSection("DatabaseBackup"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<ClinicalStorageSettings>(configuration.GetSection("ClinicalStorage"));

            // 3. Repositorios y Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // 4. Servicios
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IExcelService, ExcelService>();
            services.AddScoped<IBackupService, BackupService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<ITicketPrinterService, TicketPrinterService>();
            services.AddSingleton<IAppEventBus, AppEventBusService>();
            services.AddSingleton<IClinicalStorageService, ClinicalStorageService>();

            return services;
        }
    }
}
