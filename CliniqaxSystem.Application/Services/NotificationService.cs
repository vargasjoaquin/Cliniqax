using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Notification;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Services
{
    public class NotificationService(IUnitOfWork unitOfWork, IEmailService emailService, IWhatsAppService whatsAppService, ITemplateEngineService templateEngine, IMapper mapper) : INotificationService
    {
        public async Task<OperationResult> QueueNotificationAsync(int channelId, string recipient, string templateCode, IDictionary<string, string> tokens, int? appointmentId = null, int? patientId = null, DateTime? scheduledAt = null)
        {
            if (string.IsNullOrWhiteSpace(recipient))
                return OperationResult.Failure("Destinatario no especificado.");

            var template = await unitOfWork.Notifications.GetTemplateByCodeAndChannelAsync(templateCode, channelId);
            
            if (template == null || !template.IsActive)
                return OperationResult.Failure($"Plantilla '{templateCode}' inactiva o no encontrada para este canal.");

            string subject = !string.IsNullOrWhiteSpace(template.SubjectTemplate)
                ? templateEngine.Render(template.SubjectTemplate, tokens)
                : string.Empty;

            string messageBody = templateEngine.Render(template.BodyTemplate, tokens);

            var notification = new Notification
            {
                AppointmentId = appointmentId,
                PatientId = patientId,
                ChannelId = channelId,
                StatusId = NotificationStatusConstants.PENDING,
                TemplateCode = templateCode,
                Recipient = recipient.Trim(),
                Subject = subject,
                MessageBody = messageBody,
                ScheduledAt = scheduledAt ?? DateTime.UtcNow,
                RetryCount = 0,
                MaxRetryCount = 3
            };

            await unitOfWork.Notifications.AddAsync(notification);
            await unitOfWork.CompleteAsync();

            return OperationResult.Ok("Notificación encolada exitosamente.", notification.Id);
        }

        public async Task<OperationResult> ProcessPendingNotificationsQueueAsync()
        {
            var pendingList = (await unitOfWork.Notifications.GetPendingNotificationsAsync(DateTime.UtcNow)).ToList();
            
            if (!pendingList.Any())
                return OperationResult.Ok("No hay notificaciones pendientes para procesar.");

            int sentCount = 0;
            int errorCount = 0;

            foreach (var n in pendingList)
            {
                n.MarkAsProcessing();
                unitOfWork.Notifications.Update(n);
                await unitOfWork.CompleteAsync();

                OperationResult sendResult;

                if (n.ChannelId == NotificationChannelConstants.EMAIL)
                {
                    try
                    {
                        await emailService.SendEmailAsync(n.Recipient, n.Subject ?? "Aviso de Cliniqax", n.MessageBody);
                        sendResult = OperationResult.Ok();
                    }
                    catch (Exception ex)
                    {
                        sendResult = OperationResult.Failure(ex.Message);
                    }
                }
                else if (n.ChannelId == NotificationChannelConstants.WHATSAPP)
                {
                    sendResult = await whatsAppService.SendMessageAsync(n.Recipient, n.MessageBody);
                }
                else
                {
                    sendResult = OperationResult.Failure("Canal de comunicación no soportado.");
                }

                if (sendResult.Success)
                {
                    n.MarkAsSent();
                    sentCount++;
                }
                else
                {
                    n.RegisterFailure(sendResult.Message);
                    errorCount++;
                }

                unitOfWork.Notifications.Update(n);
                await unitOfWork.CompleteAsync();
            }

            return OperationResult.Ok($"Cola procesada: {sentCount} enviadas con éxito, {errorCount} con error o reintentos.");
        }

        public async Task<OperationResult> RetryNotificationAsync(int notificationId)
        {
            var notification = await unitOfWork.Notifications.GetByIdAsync(notificationId);
           
            if (notification == null)
                return OperationResult.Failure("Notificación no encontrada.");

            notification.StatusId = NotificationStatusConstants.PENDING;
            notification.RetryCount = 0;
            notification.ErrorMessage = null;
            notification.ScheduledAt = DateTime.UtcNow;

            unitOfWork.Notifications.Update(notification);
            await unitOfWork.CompleteAsync();

            return await ProcessPendingNotificationsQueueAsync();
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationHistoryAsync(DateTime start, DateTime end, int? channelId = null, int? statusId = null)
        {
            var history = await unitOfWork.Notifications.GetHistoryAsync(start, end, channelId, statusId);
            return mapper.Map<IEnumerable<NotificationDto>>(history);
        }

        public async Task<IEnumerable<NotificationTemplateDto>> GetTemplatesAsync()
        {
            var templates = await unitOfWork.Notifications.GetTemplatesAsync();
            return mapper.Map<IEnumerable<NotificationTemplateDto>>(templates);
        }

        public async Task<OperationResult> UpdateTemplateAsync(NotificationTemplateUpdateDto dto)
        {
            var template = await unitOfWork.Notifications.GetTemplateByIdAsync(dto.Id);

            if (template == null)
                return OperationResult.Failure("Plantilla no encontrada.");

            template.SubjectTemplate = dto.SubjectTemplate?.Trim();
            template.BodyTemplate = dto.BodyTemplate.Trim();
            template.IsActive = dto.IsActive;

            unitOfWork.Notifications.UpdateTemplate(template);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Plantilla actualizada correctamente.")
                : OperationResult.Failure("No se detectaron cambios.");
        }

        public async Task<IEnumerable<ReminderRuleConfigDto>> GetReminderRulesAsync()
        {
            var rules = await unitOfWork.Notifications.GetActiveReminderRulesAsync();
            return mapper.Map<IEnumerable<ReminderRuleConfigDto>>(rules);
        }

        public async Task<OperationResult> ToggleReminderRuleAsync(int ruleId)
        {
            var rules = await unitOfWork.Notifications.GetActiveReminderRulesAsync();
            
            var rule = rules.FirstOrDefault(r => r.Id == ruleId);
           
            if (rule == null)
                return OperationResult.Failure("Regla de recordatorio no encontrada.");

            rule.IsEnabled = !rule.IsEnabled;
            unitOfWork.Notifications.UpdateReminderRule(rule);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok($"Regla de recordatorio {(rule.IsEnabled ? "activada" : "pausada")} correctamente.")
                : OperationResult.Failure("Error al cambiar estado de la regla.");
        }
    }
}