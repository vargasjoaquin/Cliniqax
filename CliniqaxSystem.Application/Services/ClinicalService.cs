using AutoMapper;
using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Clinical.Attachment;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.File;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using CliniqaxSystem.Application.Interfaces.Common;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using FluentValidation;

namespace CliniqaxSystem.Application.Services
{
    public class ClinicalService(IUnitOfWork unitOfWork, IClinicalStorageService storageService, IMapper mapper, IAppEventBus eventBus,
                                 ICurrentUserService currentUserService, IAuditService auditService, IValidator<ConsultationCreateDto> consultationValidator, IValidator<MedicalRecordUpdateDto> recordUpdateValidator,
                                 IValidator<MedicalAttachmentCreateDto> attachmentValidator) : IClinicalService
    {
        // ==========================================
        // 1. HISTORIA CLÍNICA Y ANTECEDENTES
        // ==========================================

        public async Task<MedicalRecordDto?> GetMedicalRecordByPatientIdAsync(int patientId)
        {
            var medicalRecord = await unitOfWork.MedicalRecords.GetByPatientIdAsync(patientId);
            
            if (medicalRecord == null)
            {
                var patient = await unitOfWork.Patients.GetByIdAsync(patientId);
                
                if (patient == null) 
                    return null;

                medicalRecord = new MedicalRecord
                {
                    PatientId = patientId,
                    RecordNumber = $"HC-{patient.DocumentNumber.Trim()}",
                    CreatedAt = DateTime.UtcNow
                };

                await unitOfWork.MedicalRecords.AddAsync(medicalRecord);
                await unitOfWork.CompleteAsync();

                medicalRecord = await unitOfWork.MedicalRecords.GetByPatientIdAsync(patientId);
            }

            await auditService.LogActionAsync(
                AuditActionConstants.VIEW_CLINICAL_RECORD,
                "MedicalRecord",
                medicalRecord?.Id.ToString(),
                $"Acceso a historia clínica del paciente ID {patientId} ({medicalRecord?.RecordNumber})");

            return mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int id)
        {
            var medicalRecord = await unitOfWork.MedicalRecords.GetByIdAsync(id);
            return medicalRecord == null ? null : mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<OperationResult> UpdateMedicalRecordAsync(MedicalRecordUpdateDto dto)
        {
            var validation = await recordUpdateValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var medicalRecord = await unitOfWork.MedicalRecords.GetByPatientIdAsync(dto.PatientId);
            
            if (medicalRecord == null)
                return OperationResult.Failure("Historia clínica no encontrada para este paciente.");

            medicalRecord.BloodType = dto.BloodType?.Trim().ToUpper();
            medicalRecord.Allergies = dto.Allergies?.Trim();
            medicalRecord.PathologicalHistory = dto.PathologicalHistory?.Trim();
            medicalRecord.NonPathologicalHistory = dto.NonPathologicalHistory?.Trim();
            medicalRecord.SurgicalHistory = dto.SurgicalHistory?.Trim();
            medicalRecord.FamilyHistory = dto.FamilyHistory?.Trim();
            medicalRecord.GeneralObservations = dto.GeneralObservations?.Trim();

            unitOfWork.MedicalRecords.Update(medicalRecord);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            if (isSuccess)
            {
                eventBus.Publish(new ClinicalRecordChangedEvent(dto.PatientId));
            }

            return isSuccess
                ? OperationResult.Ok("Antecedentes clínicos actualizados exitosamente.")
                : OperationResult.Failure("No se detectaron cambios en la historia clínica.");
        }

        // ==========================================
        // 2. CONSULTAS MÉDICAS Y ATENCIÓN
        // ==========================================

        public async Task<ConsultationDto?> GetConsultationByIdAsync(int id)
        {
            var consultation = await unitOfWork.Consultations.GetByIdAsync(id);
            return consultation == null ? null : mapper.Map<ConsultationDto>(consultation);
        }

        public async Task<ConsultationDto?> GetConsultationByAppointmentIdAsync(int appointmentId)
        {
            var consultation = await unitOfWork.Consultations.GetByAppoinmentIdAsync(appointmentId);
            return consultation == null ? null : mapper.Map<ConsultationDto>(consultation);
        }

        public async Task<IEnumerable<ConsultationSummaryDto>> GetConsultationHistoryAsync(int medicalRecordId)
        {
            var history = await unitOfWork.Consultations.GetHistoryByMedicalRecordIdAsync(medicalRecordId);
            return mapper.Map<IEnumerable<ConsultationSummaryDto>>(history);
        }

        public async Task<OperationResult> RegisterConsultationAsync(ConsultationCreateDto dto)
        {
            var validation = await consultationValidator.ValidateAsync(dto);

            if (!validation.IsValid)
                return validation.ToResult();

            var medicalRecord = await unitOfWork.MedicalRecords.GetByPatientIdAsync(dto.PatientId);

            if (medicalRecord == null)
            {
                var patient = await unitOfWork.Patients.GetByIdAsync(dto.PatientId);

                if (patient == null)
                    return OperationResult.Failure("Paciente no encontrado en el sistema.");

                string docNumber = !string.IsNullOrWhiteSpace(patient.DocumentNumber)
                    ? patient.DocumentNumber.Trim()
                    : dto.PatientId.ToString();

                medicalRecord = new MedicalRecord
                {
                    PatientId = dto.PatientId,
                    RecordNumber = $"HC-{docNumber}",
                    CreatedAt = DateTime.UtcNow
                };

                await unitOfWork.MedicalRecords.AddAsync(medicalRecord);
                await unitOfWork.CompleteAsync();
            }

            var consultation = new Consultation
            {
                MedicalRecordId = medicalRecord.Id,
                ProfessionalId = dto.ProfessionalId,
                SpecialtyId = dto.SpecialtyId,
                AppointmentId = dto.AppointmentId,
                ConsultationDate = dto.ConsultationDate,
                ReasonForConsultation = dto.ReasonForConsultation?.Trim() ?? string.Empty,
                PhysicalExamination = dto.PhysicalExamination?.Trim(),
                Notes = dto.Notes?.Trim(),
                ConsultationStatusId = ConsultationStatusConstants.COMPLETED,
                ClinicalEvolutions = new List<ClinicalEvolution>(),
                ClinicalDiagnoses = new List<ClinicalDiagnosis>(),
                MedicalInstructions = new List<MedicalInstruction>()
            };

            if (!string.IsNullOrWhiteSpace(dto.EvolutionNotes))
            {
                consultation.ClinicalEvolutions.Add(new ClinicalEvolution
                {
                    Description = dto.EvolutionNotes.Trim(),
                    EvolutionDate = dto.ConsultationDate
                });
            }

            if (dto.Diagnoses != null && dto.Diagnoses.Any())
            {
                foreach (var diagDto in dto.Diagnoses)
                {
                    if (diagDto != null && !string.IsNullOrWhiteSpace(diagDto.Description))
                    {
                        consultation.ClinicalDiagnoses.Add(new ClinicalDiagnosis
                        {
                            DiagnosisTypeId = diagDto.DiagnosisTypeId > 0 ? diagDto.DiagnosisTypeId : DiagnosisTypeConstants.DEFINITIVE,
                            Description = diagDto.Description.Trim(),
                            DiagnosticCode = diagDto.DiagnosticCode?.Trim().ToUpper(),
                            Notes = diagDto.Notes?.Trim()
                        });
                    }
                }
            }

            if (dto.Instructions != null && dto.Instructions.Any())
            {
                foreach (var instruction in dto.Instructions)
                {
                    if (instruction != null && !string.IsNullOrWhiteSpace(instruction.Instructions))
                    {
                        consultation.MedicalInstructions.Add(new MedicalInstruction
                        {
                            Instructions = instruction.Instructions.Trim(),
                            MedicationDetails = instruction.MedicationDetails?.Trim(),
                            FollowUpNotes = instruction.FollowUpNotes?.Trim()
                        });
                    }
                }
            }

            await unitOfWork.BeginTransactionAsync();

            try
            {
                await unitOfWork.Consultations.AddAsync(consultation);

                if (dto.AppointmentId.HasValue && dto.AppointmentId.Value > 0)
                {
                    var appointment = await unitOfWork.Appointments.GetByIdAsync(dto.AppointmentId.Value);

                    if (appointment != null)
                    {
                        appointment.HasClinicalHistory = true;
                        unitOfWork.Appointments.Update(appointment);
                    }
                }

                await unitOfWork.CompleteAsync();
                await unitOfWork.CommitAsync();

                eventBus?.Publish(new AppointmentChangedEvent());
                eventBus?.Publish(new ClinicalRecordChangedEvent(dto.PatientId));

                return OperationResult.Ok("Consulta médica registrada exitosamente.", consultation.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure($"Error al guardar la consulta: {ex.Message}");
            }
        }

        public async Task<OperationResult> CancelConsultationAsync(int consultationId, string reason)
        {
            var consultation = await unitOfWork.Consultations.GetByIdAsync(consultationId);
            
            if (consultation == null)
                return OperationResult.Failure("Consulta médica no encontrada.");

            try
            {
                consultation.CancelConsultation(reason);
                unitOfWork.Consultations.Update(consultation);

                bool isSuccess = await unitOfWork.CompleteAsync();
                
                return isSuccess
                    ? OperationResult.Ok("Consulta médica anulada correctamente.")
                    : OperationResult.Failure("No se pudo anular la consulta.");
            }
            catch (InvalidOperationException ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        // ==========================================
        // 3. ARCHIVOS Y ESTUDIOS ADJUNTOS
        // ==========================================

        public async Task<IEnumerable<MedicalAttachmentDto>> GetAttachmentsByRecordIdAsync(int medicalRecordId)
        {
            var attachments = await unitOfWork.Consultations.GetMedicalAttachmentsByRecordIdAsync(medicalRecordId);
            return mapper.Map<IEnumerable<MedicalAttachmentDto>>(attachments);
        }

        public async Task<OperationResult> UploadAttachmentAsync(MedicalAttachmentCreateDto dto)
        {
            var validation = await attachmentValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var patient = await unitOfWork.Patients.GetByIdAsync(dto.PatientId);
            
            if (patient == null)
                return OperationResult.Failure("Paciente no encontrado.");

            var medicalRecord = await unitOfWork.MedicalRecords.GetByPatientIdAsync(dto.PatientId);
            
            if (medicalRecord == null)
                return OperationResult.Failure("El paciente no posee historia clínica activa.");

            string specialtyName = "General";
            
            if (dto.ConsultationId.HasValue)
            {
                var consultation = await unitOfWork.Consultations.GetByIdAsync(dto.ConsultationId.Value);
                
                if (consultation?.Specialty != null)
                    specialtyName = consultation.Specialty.Name;
            }

            var saveResult = await storageService.SaveFileAsync(dto.FileBytes, dto.OriginalFileName, patient.FullName, specialtyName, DateTime.Today);

            if (!saveResult.Success || saveResult.Data is not StoredFileDto storedFileInfo)
                return OperationResult.Failure(saveResult.Message);

            var attachment = new MedicalAttachment
            {
                MedicalRecordId = medicalRecord.Id,
                ConsultationId = dto.ConsultationId,
                AttachmentCategoryId = dto.AttachmentCategoryId,
                OriginalFileName = dto.OriginalFileName.Trim(),
                StoredFileName = storedFileInfo.StoredFileName,
                RelativePath = storedFileInfo.RelativePath,
                FileExtension = Path.GetExtension(dto.OriginalFileName).ToLowerInvariant(),
                ContentType = "application/octet-stream",
                FileSizeBytes = dto.FileBytes.Length,
                Notes = dto.Notes?.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.Consultations.AddMedicalAttachmentAsync(attachment);
            
            bool isSuccess = await unitOfWork.CompleteAsync();

            return isSuccess
                ? OperationResult.Ok("Estudio médico adjuntado exitosamente.", attachment.Id)
                : OperationResult.Failure("Error al persistir el registro del archivo adjunto.");
        }

        public async Task<byte[]?> DownloadAttachmentFileAsync(int attachmentId)
        {
            var attachment = await unitOfWork.Consultations.GetAttachmentByIdAsync(attachmentId);
            
            if (attachment == null)
                return null;

            return await storageService.ReadFileAsync(attachment.RelativePath);
        }

        public async Task<OperationResult> DeleteAttachmentAsync(int attachmentId)
        {
            var attachment = await unitOfWork.Consultations.GetAttachmentByIdAsync(attachmentId);
            
            if (attachment == null)
                return OperationResult.Failure("Archivo adjunto no encontrado.");

            attachment.IsDeleted = true;
            unitOfWork.Consultations.UpdateMedicalAttachment(attachment);

            storageService.DeleteFile(attachment.RelativePath);

            bool isSuccess = await unitOfWork.CompleteAsync();

            if (isSuccess)
                eventBus.Publish(new ClinicalRecordChangedEvent());

            return isSuccess
                ? OperationResult.Ok("Archivo adjunto eliminado correctamente.")
                : OperationResult.Failure("Error al dar de baja el archivo adjunto.");
        }

        // ==========================================
        // 4. CATÁLOGOS CLÍNICOS
        // ==========================================

        public async Task<IEnumerable<DiagnosisTypeDto>> GetDiagnosisTypesAsync()
        {
            var diagnosisTypes = await unitOfWork.GetDiagnosisTypesAsync();
            return mapper.Map<IEnumerable<DiagnosisTypeDto>>(diagnosisTypes);
        }

        public async Task<IEnumerable<ConsultationStatusDto>> GetConsultationStatusesAsync()
        {
            var consultationStatuses = await unitOfWork.GetConsultationStatusesAsync();
            return mapper.Map<IEnumerable<ConsultationStatusDto>>(consultationStatuses);
        }

        public async Task<IEnumerable<AttachmentCategoryDto>> GetAttachmentCategoriesAsync()
        {
            var attachmentCategories = await unitOfWork.GetAttachmentCategoriesAsync();
            return mapper.Map<IEnumerable<AttachmentCategoryDto>>(attachmentCategories);
        }
    }
}
