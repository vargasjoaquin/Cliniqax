using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.Services
{
    public class AppointmentReminderService(IUnitOfWork unitOfWork, INotificationService notificationService) : IAppointmentReminderService
    {
        public async Task<OperationResult> CheckAndGenerateAppointmentRemindersAsync()
        {
            var activeRules = (await unitOfWork.Notifications.GetActiveReminderRulesAsync()).ToList();
            
            if (!activeRules.Any())
                return OperationResult.Ok("No hay reglas de recordatorios automáticos activadas.");

            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            string clinicName = settings?.ClinicName;
            string clinicAddress = settings?.Address;
            string clinicPhone = settings?.Phone;

            DateTime now = DateTime.Now;
            int generatedCount = 0;

            DateTime windowStart = now;
            DateTime windowEnd = now.AddDays(2);

            var appointments = (await unitOfWork.Appointments.GetByDateRangeAsync(windowStart.Date, windowEnd.Date))
                .Where(a => a.Status == AppointmentStatus.Pending || a.Status == AppointmentStatus.Confirmed)
                .ToList();

            foreach (var app in appointments)
            {
                if (app.Patient == null)
                    continue;

                DateTime appointmentDateTime = app.AppointmentDate.Date.Add(app.StartTime);

                foreach (var rule in activeRules)
                {
                    // Ventana de tiempo: ¿El turno está dentro del rango de anticipación de la regla?
                    TimeSpan timeUntilAppointment = appointmentDateTime - now;
                    double hoursDifference = timeUntilAppointment.TotalHours;

                    // Si está dentro de la ventana de anticipación (ej: faltan entre 23 y 25 horas para la regla de 24h)
                    if (hoursDifference <= rule.AdvanceHours && hoursDifference > 0)
                    {
                        // Verificar si ya se envió o encoló un recordatorio para este turno y canal
                        var existingNotifications = await unitOfWork.Notifications.GetHistoryAsync(now.AddDays(-3), now.AddDays(1), rule.ChannelId);
                        bool alreadyQueued = existingNotifications.Any(n => n.AppointmentId == app.Id && n.TemplateCode == rule.Template.Code);

                        if (alreadyQueued)
                            continue; // Previene duplicados

                        string recipient = rule.ChannelId == NotificationChannelConstants.EMAIL
                            ? app.Patient.Email ?? string.Empty
                            : app.Patient.Phone;

                        if (string.IsNullOrWhiteSpace(recipient))
                            continue; 

                        var tokens = new Dictionary<string, string>
                        {
                            { "PacienteNombre", app.Patient.FullName },
                            { "PacienteDni", app.Patient.DocumentNumber },
                            { "ProfesionalNombre", app.Professional?.FullName ?? "Médico" },
                            { "Especialidad", app.Specialty?.Name ?? "Consulta General" },
                            { "FechaTurno", app.AppointmentDate.ToString("dd/MM/yyyy") },
                            { "HoraTurno", $"{app.StartTime:hh\\:mm}" },
                            { "ClinicaNombre", clinicName },
                            { "ClinicaDireccion", clinicAddress },
                            { "ClinicaTelefono", clinicPhone }
                        };

                        await notificationService.QueueNotificationAsync(
                            rule.ChannelId,
                            recipient,
                            rule.Template.Code,
                            tokens,
                            appointmentId: app.Id,
                            patientId: app.PatientId,
                            scheduledAt: DateTime.UtcNow);

                        generatedCount++;
                    }
                }
            }

            if (generatedCount > 0)
            {
                await notificationService.ProcessPendingNotificationsQueueAsync();
            }

            return OperationResult.Ok($"Evaluación completada. Se generaron y procesaron {generatedCount} recordatorios automáticos.");
        }
    }
}