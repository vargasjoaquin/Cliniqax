using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Clinical;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Constants;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class ClinicalDocumentService(IUnitOfWork unitOfWork, IClinicalService clinicalService, IClinicalStorageService storageService, IClinicalDocumentParserService parserService, ClinicalDocumentGeneratorService generatorService) : IClinicalDocumentService
    {
        public async Task<byte[]> GenerateOfficialMedicalRecordPdfAsync(int patientId)
        {
            var record = await clinicalService.GetMedicalRecordByPatientIdAsync(patientId);

            if (record == null)
            {
                var patient = await unitOfWork.Patients.GetByIdAsync(patientId);
                record = new MedicalRecordDto
                {
                    PatientId = patientId,
                    PatientFullName = patient?.FullName ?? "Paciente",
                    PatientDocument = patient?.DocumentNumber ?? "-",
                    PatientHealthInsurance = patient?.HealthInsurance?.Name ?? "Particular",
                    PatientAge = patient?.Age ?? 0,
                    RecordNumber = $"HC-{patient?.DocumentNumber ?? patientId.ToString()}",
                    Consultations = new List<ConsultationSummaryDto>()
                };
            }

            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            var settingsDto = new Application.DTOs.AdminAndDashboard.ClinicSettingsDto
            {
                ClinicName = settings?.ClinicName ?? "Consultorio Médico Cliniqax",
                Address = settings?.Address,
                Logo = settings?.Logo
            };

            return generatorService.GenerateOfficialMedicalRecordPdf(record, settingsDto);
        }

        public async Task<byte[]> GenerateBlankTemplatePdfAsync(int? patientId = null)
        {
            MedicalRecordDto? record = null;
           
            if (patientId.HasValue && patientId.Value > 0)
                record = await clinicalService.GetMedicalRecordByPatientIdAsync(patientId.Value);

            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            var settingsDto = new Application.DTOs.AdminAndDashboard.ClinicSettingsDto
            {
                ClinicName = settings?.ClinicName ?? "Consultorio Médico Cliniqax"
            };

            return generatorService.GenerateOfficialMedicalRecordPdf(record, settingsDto);
        }

        public async Task<byte[]> GenerateBlankTemplateWordAsync(int? patientId = null)
        {
            MedicalRecordDto? record = null;
           
            if (patientId.HasValue && patientId.Value > 0)
                record = await clinicalService.GetMedicalRecordByPatientIdAsync(patientId.Value);

            var settings = await unitOfWork.ClinicSettings.GetSettingsAsync();
            var settingsDto = new Application.DTOs.AdminAndDashboard.ClinicSettingsDto
            {
                ClinicName = settings?.ClinicName ?? "Consultorio Médico Cliniqax",
                Address = settings?.Address
            };

            return generatorService.GenerateBlankTemplateDocx(settingsDto, record);
        }

        public async Task<OperationResult> SyncAndStoreOfficialRecordPdfAsync(int patientId, string reason = "Actualización")
        {
            try
            {
                var patient = await unitOfWork.Patients.GetByIdAsync(patientId);
                
                if (patient == null) 
                    return OperationResult.Failure("Paciente no encontrado.");

                byte[] pdfBytes = await GenerateOfficialMedicalRecordPdfAsync(patientId);
                string fileName = $"HC_{patient.DocumentNumber}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                var saveResult = await storageService.SaveFileAsync(
                    pdfBytes,
                    fileName,
                    patient.FullName,
                    "Historia_Clinica",
                    DateTime.Today);

                return saveResult.Success
                    ? OperationResult.Ok($"Expediente actualizado y almacenado ({reason}).")
                    : OperationResult.Failure(saveResult.Message);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Fallo en sincronización documental: {ex.Message}");
            }
        }

        public async Task<OperationResult> ProcessFilledTemplateAsync(byte[] fileBytes, string fileName, int? targetPatientId = null)
        {
            var parsed = await parserService.ParseDocumentAsync(fileBytes, fileName);
            int resolvedPatientId = targetPatientId ?? 0;

            if (resolvedPatientId == 0 && !string.IsNullOrWhiteSpace(parsed.ExtractedDocumentNumber))
            {
                var patient = await unitOfWork.Patients.GetByDocumentAsync(parsed.ExtractedDocumentNumber);
                
                if (patient != null)
                    resolvedPatientId = patient.Id;
            }

            if (resolvedPatientId == 0)
                return OperationResult.Failure("No se pudo identificar al paciente desde la plantilla. Selecciónelo manualmente.");

            return await SaveConsultationFromParsedDataAsync(parsed, resolvedPatientId, fileBytes, fileName, "Plantilla Cliniqax Offline");
        }

        public async Task<OperationResult> ImportExternalClinicalDocumentAsync(byte[] fileBytes, string fileName, int? targetPatientId = null)
        {
            var parsed = await parserService.ParseDocumentAsync(fileBytes, fileName);
            int resolvedPatientId = targetPatientId ?? 0;

            if (resolvedPatientId == 0 && !string.IsNullOrWhiteSpace(parsed.ExtractedDocumentNumber))
            {
                var patient = await unitOfWork.Patients.GetByDocumentAsync(parsed.ExtractedDocumentNumber);
                
                if (patient != null)
                    resolvedPatientId = patient.Id;
            }

            if (resolvedPatientId == 0)
                return OperationResult.Failure("No se encontró ningún paciente con el DNI detectado. Por favor vincúlelo manualmente.");

            return await SaveConsultationFromParsedDataAsync(parsed, resolvedPatientId, fileBytes, fileName, "Importación Sistema Externo");
        }

        private async Task<OperationResult> SaveConsultationFromParsedDataAsync(ParsedClinicalDocumentDto parsed, int patientId, byte[] originalFile, string originalFileName, string sourceNote)
        {
            var professionals = await unitOfWork.Professionals.GetAllAsync();
            var defaultProf = professionals.FirstOrDefault();
            
            if (defaultProf == null)
                return OperationResult.Failure("Debe existir al menos un profesional registrado para asignar la atención.");

            int specialtyId = defaultProf.ProfessionalSpecialties.FirstOrDefault()?.SpecialtyId ?? 1;

            var dto = new ConsultationCreateDto
            {
                PatientId = patientId,
                ProfessionalId = defaultProf.Id,
                SpecialtyId = specialtyId,
                ConsultationDate = DateTime.Now,
                ReasonForConsultation = string.IsNullOrWhiteSpace(parsed.ReasonForConsultation)
                    ? $"Atención médica registrada vía {sourceNote}"
                    : parsed.ReasonForConsultation,
                PhysicalExamination = parsed.PhysicalExamination,
                EvolutionNotes = $"[INGESTA AUTOMÁTICA]: {sourceNote}",
                Notes = $"Documento original: {originalFileName}"
            };

            if (!string.IsNullOrWhiteSpace(parsed.DiagnosesSummary))
            {
                dto.Diagnoses.Add(new ClinicalDiagnosisCreateDto
                {
                    Description = parsed.DiagnosesSummary,
                    DiagnosisTypeId = DiagnosisTypeConstants.DEFINITIVE
                });
            }

            if (!string.IsNullOrWhiteSpace(parsed.InstructionsSummary))
            {
                dto.Instructions.Add(new MedicalInstructionCreateDto
                {
                    Instructions = parsed.InstructionsSummary
                });
            }

            
            var regResult = await clinicalService.RegisterConsultationAsync(dto);
            
            if (!regResult.Success)
                return regResult;

            
            await clinicalService.UploadAttachmentAsync(new MedicalAttachmentCreateDto
            {
                PatientId = patientId,
                ConsultationId = regResult.EntityId,
                OriginalFileName = originalFileName,
                FileBytes = originalFile,
                Notes = $"Archivo de origen ({sourceNote})"
            });

            await SyncAndStoreOfficialRecordPdfAsync(patientId, sourceNote);

            return OperationResult.Ok($"Historia clínica procesada e importada exitosamente para el paciente.", regResult.EntityId);
        }
    }
}