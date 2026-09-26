using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Cash;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Domain.Enums;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class CashSessionService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper, IValidator<CashSessionOpenDto> cashSessionOpenValidator,
                                    IValidator<CashSessionCloseDto> cashSessionCloseValidator,
                                    IValidator<CashMovementCreateDto> cashMovementValidator,
                                    IValidator<ConsultationPaymentCreateDto> consultationPaymentValidator) : ICashSessionService
    {
        public async Task<CashSessionDto?> GetActiveSessionAsync()
        {
            var cashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();
            return cashSession == null ? null : mapper.Map<CashSessionDto>(cashSession);
        }

        public async Task<CashSessionDto?> GetCurrentSessionSummaryAsync()
        {
            var cashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();

            if (cashSession == null)
                return new CashSessionDto
                {
                    UserName = currentUser.FullName
                };

            var detailedCashSession = await unitOfWork.CashSessions.GetByIdAsync(cashSession.Id);

            return mapper.Map<CashSessionDto>(detailedCashSession);
        }

        public async Task<OperationResult> OpenSessionAsync(CashSessionOpenDto cashSessionOpenDto)
        {
            var validation = await cashSessionOpenValidator.ValidateAsync(cashSessionOpenDto);

            if (!validation.IsValid)
                return validation.ToResult();

            if (!currentUser.IsAuthenticated || !currentUser.UserId.HasValue)
                return OperationResult.Failure("La operación no esta autorizada. Por favor, inicie sesión para operar la caja.");

            var activeCashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();

            if (activeCashSession != null)
                return OperationResult.Failure($"Ya existe una sesión de caja abierta en {activeCashSession.StationName} por {activeCashSession.User?.Username}. Debe cerrarla antes de abrir una nueva.");

            var cashSession = new CashSession
            {
                UserId = currentUser.UserId.Value,
                StationName = cashSessionOpenDto.StationName.Trim(),
                InitialCash = cashSessionOpenDto.InitialCash,
                OpeningDate = DateTime.UtcNow,
                Status = CashSessionStatusesConstants.OPEN
            };

            await unitOfWork.CashSessions.AddAsync(cashSession);

            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok($"Sesión de caja abierta exitosamente con fondo inicial de {cashSessionOpenDto.InitialCash:C2}.", cashSession.Id)
                : OperationResult.Failure("Error al registrar la apertura de caja.");
        }

        public async Task<OperationResult> CloseSessionAsync(CashSessionCloseDto cashSessionCloseDto)
        {
            var validation = await cashSessionCloseValidator.ValidateAsync(cashSessionCloseDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var cashSession = await unitOfWork.CashSessions.GetByIdAsync(cashSessionCloseDto.SessionId);
            
            if (cashSession == null || cashSession.Status != CashSessionStatusesConstants.OPEN)
                return OperationResult.Failure("La sesión no existe o ya se encuentra cerrada.");

            var cashMovements = cashSession.CashMovements.ToList();
            var cashPayments = cashSession.Payments.ToList();

            decimal cashIncome = cashPayments.Where(p => p.PaymentMethodId == PaymentMethodConstants.CASH_ID).Sum(p => p.Amount);
            decimal debitIncome = cashPayments.Where(p => p.PaymentMethodId == PaymentMethodConstants.DEBIT_CARD_ID).Sum(p => p.Amount);
            decimal creditIncome = cashPayments.Where(p => p.PaymentMethodId == PaymentMethodConstants.CREDIT_CARD_ID).Sum(p => p.Amount);
            decimal transferIncome = cashPayments.Where(p => p.PaymentMethodId == PaymentMethodConstants.BANK_TRANSFER_ID).Sum(p => p.Amount);
            decimal qrIncome = cashPayments.Where(p => p.PaymentMethodId == PaymentMethodConstants.MERCADO_PAGO_QR_ID).Sum(p => p.Amount);

            decimal manualCashIn = cashMovements.Where(m => m.MovementType == CashMovementType.CashIn).Sum(m => m.Amount);
            decimal manualCashOut = cashMovements.Where(m => m.MovementType == CashMovementType.CashOut).Sum(m => m.Amount);

            decimal expectedCash = cashSession.InitialCash + cashIncome + manualCashIn - manualCashOut;

            cashSession.ClosingDate = DateTime.UtcNow;
            cashSession.RealCash = cashSessionCloseDto.RealCash;
            cashSession.ExpectedCash = expectedCash;
            cashSession.Difference = cashSessionCloseDto.RealCash - expectedCash;
            cashSession.TotalCashIncome = cashIncome;
            cashSession.TotalDebitIncome = debitIncome;
            cashSession.TotalCreditIncome = creditIncome;
            cashSession.TotalTransferIncome = transferIncome;
            cashSession.TotalQrIncome = qrIncome;
            cashSession.TotalManualCashIn = manualCashIn;
            cashSession.TotalManualCashOut = manualCashOut;
            cashSession.Status = CashSessionStatusesConstants.CLOSED;
            cashSession.ClosingNotes = cashSessionCloseDto.ClosingNotes?.Trim();

            unitOfWork.CashSessions.Update(cashSession);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            string cashBalance = cashSession.Difference == 0
                ? "Caja Cuadrada ($ 0.00)"
                : (cashSession.Difference > 0 ? $"Sobrante: +{cashSession.Difference:C2}" : $"Faltante: {cashSession.Difference:C2}");

            return isSuccess
                ? OperationResult.Ok($"Sesión de caja cerrada correctamente. Balance: {cashBalance}.")
                : OperationResult.Failure("Error al persistir el cierre de caja.");
        }

        public async Task<OperationResult> RegisterMovementAsync(CashMovementCreateDto cashMovementCreateDto)
        {
            var validation = await cashMovementValidator.ValidateAsync(cashMovementCreateDto);

            if (!validation.IsValid)
                return validation.ToResult();

            if (!currentUser.IsAuthenticated || !currentUser.UserId.HasValue)
                return OperationResult.Failure("La operación no esta autorizada.");

            var activeCashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();

            if (activeCashSession == null)
                return OperationResult.Failure("No hay ninguna sesión de caja abierta para registrar movimientos.");

            var cashMovement = new CashMovement
            {
                CashSessionId = activeCashSession.Id,
                UserId = currentUser.UserId.Value,
                MovementType = cashMovementCreateDto.MovementType,
                Amount = cashMovementCreateDto.Amount,
                Description = cashMovementCreateDto.Description.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.CashSessions.AddMovementAsync(cashMovement);

            bool isSuccess = await unitOfWork.CompleteAsync();

            string cashMovementType = cashMovementCreateDto.MovementType == CashMovementType.CashIn ? "Ingreso manual" : "Retiro / Egreso";
            
            return isSuccess
                ? OperationResult.Ok($"{cashMovementType} por {cashMovementCreateDto.Amount:C2} registrado con éxito.")
                : OperationResult.Failure("Error al registrar el movimiento de caja.");
        }

        public async Task<OperationResult> ProcessPaymentAsync(ConsultationPaymentCreateDto consultationPaymentCreateDto)
        {
            var validation = await consultationPaymentValidator.ValidateAsync(consultationPaymentCreateDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            if (!currentUser.IsAuthenticated || !currentUser.UserId.HasValue)
                return OperationResult.Failure("Operación no autorizada.");

            var activeSession = await unitOfWork.CashSessions.GetActiveSessionAsync();
            
            if (activeSession == null)
                return OperationResult.Failure("Debe abrir una sesión de caja antes de registrar cobros de consultas.");

            var appointment = await unitOfWork.Appointments.GetByIdAsync(consultationPaymentCreateDto.AppointmentId);
            
            if (appointment == null)
                return OperationResult.Failure("Turno asociado no encontrado.");

            decimal paymentChange = Math.Max(0, consultationPaymentCreateDto.PaymentReceived - consultationPaymentCreateDto.Amount);

            var payment = new ConsultationPayment
            {
                AppointmentId = consultationPaymentCreateDto.AppointmentId,
                CashSessionId = activeSession.Id,
                UserId = currentUser.UserId.Value,
                PaymentMethodId = consultationPaymentCreateDto.PaymentMethodId,
                Amount = consultationPaymentCreateDto.Amount,
                CopayAmount = consultationPaymentCreateDto.CopayAmount,
                PaymentReceived = consultationPaymentCreateDto.PaymentReceived,
                PaymentChange = paymentChange,
                ReceiptNumber = $"REC-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Observations = consultationPaymentCreateDto.Observations?.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.BeginTransactionAsync();
            
            try
            {
                await unitOfWork.CashSessions.AddPaymentAsync(payment);

                // Al cobrar la consulta, pasamos el turno a sala de espera o confirmado si estaba pendiente
                if (appointment.Status == AppointmentStatus.Pending)
                {
                    appointment.Confirm();
                    unitOfWork.Appointments.Update(appointment);
                }

                await unitOfWork.CompleteAsync();
                await unitOfWork.CommitAsync();

                return OperationResult.Ok($"El Cobro se ha registrado con éxito. Comprobante: {payment.ReceiptNumber}.", payment.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure($"Fallo al persistir el pago: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CashSessionDto>> GetSessionHistoryAsync(DateTime start, DateTime end)
        {
            var cashSessions = await unitOfWork.CashSessions.GetHistoryAsync(start.Date, end.Date.AddDays(1));
            return mapper.Map<IEnumerable<CashSessionDto>>(cashSessions);
        }

        public async Task<IEnumerable<CashMovementDto>> GetCurrentSessionMovementsAsync()
        {
            var activeCashSession = await unitOfWork.CashSessions.GetActiveSessionAsync();
            
            if (activeCashSession == null)
                return Enumerable.Empty<CashMovementDto>();

            var movements = await unitOfWork.CashSessions.GetMovementsBySessionIdAsync(activeCashSession.Id);
           
            return mapper.Map<IEnumerable<CashMovementDto>>(movements);
        }
    }
}
