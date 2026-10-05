using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.Interfaces.Common;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Domain.Enums;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AppointmentCreateDto> createAppointmentValidator,
                                    IValidator<AppointmentRescheduleDto> rescheduleAppointmentValidtor, IAppEventBus eventBus) : IAppointmentService
    {
        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var appointment = await unitOfWork.Appointments.GetByIdAsync(id);
            return appointment == null ? null : mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId)
        {
            var appointments = await unitOfWork.Appointments.GetHistoryByPatientIdAsync(patientId);
            return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAgendaAsync(DateTime date, int professionalId)
        {
            var appointments = await unitOfWork.Appointments.GetByDateAndProfessionalAsync(date, professionalId);
            return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByRangeAsync(DateTime start, DateTime end, int? professionalId = null, int? specialtyId = null)
        {
            var appointments = await unitOfWork.Appointments.GetByDateRangeAsync(start.Date, end.Date, professionalId, specialtyId);
            return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<IEnumerable<AgendaSlotDto>> GetDailyAgendaSlotsAsync(DateTime date, int professionalId)
        {
            var professional = await unitOfWork.Professionals.GetByIdAsync(professionalId);
            
            if (professional == null || !professional.IsActive)
                return Enumerable.Empty<AgendaSlotDto>();

            var dayOfWeek = date.DayOfWeek;
            var professionalSchedule = professional.Schedules.FirstOrDefault(s => s.DayOfWeek == dayOfWeek && s.IsActive);

            if (professionalSchedule == null)
                return Enumerable.Empty<AgendaSlotDto>();

            var existingAppointments = (await unitOfWork.Appointments.GetByDateAndProfessionalAsync(date.Date, professionalId))
                .Where(a => a.Status != AppointmentStatus.Cancelled)
                .ToList();

            var slots = new List<AgendaSlotDto>();
            int slotDurationMinutes = professional.AppointmentDuration > 0 ? professional.AppointmentDuration : 30;
            var duration = TimeSpan.FromMinutes(slotDurationMinutes);

            var currentStart = professionalSchedule.StartTime;
            
            while (currentStart + duration <= professionalSchedule.EndTime)
            {
                var currentEnd = currentStart + duration;

                var matchingAppointment = existingAppointments.FirstOrDefault(a =>
                    a.StartTime < currentEnd && a.EndTime > currentStart);

                slots.Add(new AgendaSlotDto
                {
                    StartTime = currentStart,
                    EndTime = currentEnd,
                    IsAvailable = matchingAppointment == null,
                    Appointment = matchingAppointment != null ? mapper.Map<AppointmentDto>(matchingAppointment) : null
                });

                currentStart = currentEnd;
            }

            return slots;
        }

        public async Task<OperationResult> CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto)
        {
            var validation = await createAppointmentValidator.ValidateAsync(appointmentCreateDto);

            if (!validation.IsValid)
                return validation.ToResult();

            // Valiadamos que el profesional no tenga turnos solapados entre si.
            bool isSlotTaken = await unitOfWork.Appointments.HasOverlappingAppointmentAsync(appointmentCreateDto.ProfessionalId, appointmentCreateDto.AppointmentDate.Date,
                                                                                            appointmentCreateDto.StartTime, appointmentCreateDto.EndTime);

            if (isSlotTaken)
                return OperationResult.Failure("El profesional ya tiene un turno reservado o en espera que se solapa con esta franja horaria.");

            var appointment = mapper.Map<Appointment>(appointmentCreateDto);
            appointment.AppointmentDate = appointmentCreateDto.AppointmentDate;

            await unitOfWork.Appointments.AddAsync(appointment);

            bool isSuccess = await unitOfWork.CompleteAsync();

            if (isSuccess)
                eventBus.Publish(new AppointmentChangedEvent());

            return isSuccess
                ? OperationResult.Ok($"Turno reservado exitosamente para el {appointmentCreateDto.AppointmentDate:dd/MM/yyyy} a las {appointmentCreateDto.StartTime:hh\\:mm}.", appointment.Id)
                : OperationResult.Failure("Error al persistir el turno.");
        }

        public async Task<OperationResult> ChangeAppointmentStatusAsync(int appointmentId, AppointmentStatus newStatus, string? reason = null)
        {
            var appointment = await unitOfWork.Appointments.GetByIdAsync(appointmentId);

            if (appointment == null)
                return OperationResult.Failure($"El turno con id {appointmentId} no fue encontrado.");

            try
            {
                switch (newStatus)
                {
                    case AppointmentStatus.Confirmed:
                        appointment.Confirm();
                        break;
                    case AppointmentStatus.Waiting:
                        appointment.MarkInWaitingRoom();
                        break;
                    case AppointmentStatus.Attended:
                        appointment.MarkAsAttended();
                        break;
                    case AppointmentStatus.Cancelled:
                        appointment.Cancel(reason ?? "Cancelado por administración / paciente.");
                        break;
                    case AppointmentStatus.Absent:
                        appointment.MarkAsAbsent();
                        break;
                    default:
                        appointment.Status = newStatus;
                        break;
                }

                unitOfWork.Appointments.Update(appointment);

                bool isSuccess = await unitOfWork.CompleteAsync();

                if (isSuccess)
                    eventBus.Publish(new AppointmentChangedEvent());

                // Provisional

                string statusName;

                switch (newStatus)
                {
                    case AppointmentStatus.Pending:
                        statusName = "Pendiente";
                        break;

                    case AppointmentStatus.Confirmed:
                        statusName = "Confirmado";
                        break;

                    case AppointmentStatus.Waiting:
                        statusName = "En Espera";
                        break;

                    case AppointmentStatus.Attended:
                        statusName = "Atendido";
                        break;

                    case AppointmentStatus.Cancelled:
                        statusName = "Cancelado";
                        break;

                    case AppointmentStatus.Absent:
                        statusName = "Ausente";
                        break;

                    case AppointmentStatus.Rescheduled:
                        statusName = "Reprogramado";
                        break;

                    default:
                        statusName = newStatus.ToString();
                        break;
                }

                return isSuccess
                    ? OperationResult.Ok($"Estado del turno actualizado a '{statusName}'.")
                    : OperationResult.Failure("No se pudo actualizar el estado del turno.");

            }
            catch (InvalidOperationException ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public async Task<OperationResult> RescheduleAppointmentAsync(AppointmentRescheduleDto appointmentRescheduleDto)
        {
            var validation = await rescheduleAppointmentValidtor.ValidateAsync(appointmentRescheduleDto);

            if (!validation.IsValid)
                return validation.ToResult();

            var appointment = await unitOfWork.Appointments.GetByIdAsync(appointmentRescheduleDto.AppointmentId);

            if (appointment == null)
                return OperationResult.Failure($"El turno no fue encontrado.");

            // Valiadamos que el profesional no tenga turnos solapados entre si.
            bool isSlotTaken = await unitOfWork.Appointments.HasOverlappingAppointmentAsync(appointment.ProfessionalId, appointmentRescheduleDto.NewDate.Date, appointmentRescheduleDto.NewStartTime,
                                                                              appointmentRescheduleDto.NewEndTime, appointmentRescheduleDto.AppointmentId);

            if (isSlotTaken)
                return OperationResult.Failure("La nueva franja horaria seleccionada ya se encuentra ocupada.");

            try
            {
                appointment.Reschedule(appointmentRescheduleDto.NewDate, appointmentRescheduleDto.NewStartTime, appointmentRescheduleDto.NewEndTime);

                unitOfWork.Appointments.Update(appointment);

                bool isSuccess = await unitOfWork.CompleteAsync();

                if (isSuccess)
                    eventBus.Publish(new AppointmentChangedEvent());

                return isSuccess
                    ? OperationResult.Ok("Turno reprogramado exitosamente.")
                    : OperationResult.Failure("Error al reprogramar el turno.");
            }
            catch (InvalidOperationException ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
    }
}
