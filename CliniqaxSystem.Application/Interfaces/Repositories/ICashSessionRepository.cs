using CliniqaxSystem.Domain.Entities;

namespace CliniqaxSystem.Application.Interfaces.Repositories
{
    public interface ICashSessionRepository
    {
        Task<CashSession?> GetActiveSessionAsync();
        Task<CashSession?> GetByIdAsync(int id);
        Task AddAsync(CashSession cashSession);
        Task Update(CashSession cashSession);
        Task<IEnumerable<CashSession>> GetHistoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<CashMovement>> GetMovementsBySessionIdAsync(int sessionId);
        Task AddMovementAsync(CashMovement cashMovement);
        Task AddPaymentAsync(ConsultationPayment consultationPayment);
    }
}
