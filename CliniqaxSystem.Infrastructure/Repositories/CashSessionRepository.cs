using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CliniqaxSystem.Infrastructure.Repositories
{
    public class CashSessionRepository(ApplicationDbContext context) : ICashSessionRepository
    {
        public async Task<CashSession?> GetActiveSessionAsync()
        {
            return await context.CashSessions
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.PaymentMethod)
                .FirstOrDefaultAsync(cs => cs.Status == CashSessionStatusesConstants.OPEN);
        }

        public async Task<CashSession?> GetByIdAsync(int id)
        {
            return await context.CashSessions
                .Include(cs => cs.User)
                .Include(cs => cs.CashMovements)
                .ThenInclude(cm => cm.User)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.PaymentMethod)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task AddAsync(CashSession cashSession)
        {
            await context.CashSessions.AddAsync(cashSession);
        }

        public void Update(CashSession cashSession)
        {
            context.CashSessions.Update(cashSession);
        }

        public async Task<IEnumerable<CashSession>> GetHistoryAsync(DateTime start, DateTime end)
        {
            return await context.CashSessions
                .AsNoTracking()
                .Include(cs => cs.User)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.PaymentMethod)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.User)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Professional)
                .Include(cs => cs.Payments)
                .ThenInclude(p => p.Appointment)
                .ThenInclude(a => a.Specialty)
                .Where(cs => cs.OpeningDate.Date >= start.Date && cs.OpeningDate.Date <= end.Date)
                .OrderByDescending(cs => cs.OpeningDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<CashMovement>> GetMovementsBySessionIdAsync(int sessionId)
        {
            return await context.CashMovements
                .AsNoTracking()
                .Include(cm => cm.User)
                .Where(cm => cm.CashSessionId == sessionId)
                .OrderByDescending(cm => cm.CreatedAt)
                .ToListAsync();
        }

        public async Task AddMovementAsync(CashMovement cashMovement)
        {
            await context.CashMovements.AddAsync(cashMovement);
        }

        public async Task AddPaymentAsync(ConsultationPayment consultationPayment)
        {
            await context.ConsultationPayments.AddAsync(consultationPayment);
        }
    }
}
