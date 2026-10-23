using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Application.Mappings;
using CliniqaxSystem.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CliniqaxSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IProfessionalService, ProfessionalService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<ICashSessionService, CashSessionService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRestoreService, RestoreService>();
            services.AddScoped<IClinicSettingsService, ClinicSettingsService>();
            services.AddScoped<IClinicalService, ClinicalService>();
            services.AddSingleton<ITemplateEngineService, TemplateEngineService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAppointmentReminderService, AppointmentReminderService>();
            services.AddScoped<IAuditService, AuditService>();

            return services;
        }
    }
}
