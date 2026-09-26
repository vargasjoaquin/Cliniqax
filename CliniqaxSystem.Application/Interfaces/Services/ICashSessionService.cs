using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Cash;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ICashSessionService
    {
        Task<CashSessionDto?> GetActiveSessionAsync();
        Task<CashSessionDto?> GetCurrentSessionSummaryAsync();
        Task<OperationResult> OpenSessionAsync(CashSessionOpenDto cashSessionOpenDto);
        Task<OperationResult> CloseSessionAsync(CashSessionCloseDto cashSessionCloseDto);
        Task<OperationResult> RegisterMovementAsync(CashMovementCreateDto cashMovementCreateDto);
        Task<OperationResult> ProcessPaymentAsync(ConsultationPaymentCreateDto consultationPaymentCreateDto);
        Task<IEnumerable<CashSessionDto>> GetSessionHistoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<CashMovementDto>> GetCurrentSessionMovementsAsync();
    }
}
