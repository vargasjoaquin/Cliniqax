using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IAppointmentReminderService
    {
        Task<OperationResult> CheckAndGenerateAppointmentRemindersAsync();
    }
}
