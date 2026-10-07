using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Clinical.Attachment;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicalService
    {
        // Historia clinica y antecedentes.
        Task<MedicalRecordDto?> GetMedicalRecordByPatientIdAsync(int patientId);
        Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int medicalRecordId);
        Task<OperationResult> UpdateMedicalRecordAsync(MedicalRecordUpdateDto medicalRecord);

        // Consuta medicas.
        Task<ConsultationDto?> GetConsultationByIdAsync(int consultationId);
        Task<ConsultationDto?> GetConsultationByAppointmentIdAsync(int appointmentId);
        Task<IEnumerable<ConsultationSummaryDto>> GetConsultationHistoryAsync(int patientId);
        Task<OperationResult> RegisterConsultationAsync(ConsultationCreateDto consultation);
        Task<OperationResult> CancelConsultationAsync(int consultationId, string reason);

        // Archivos y estudios adjuntos.
        Task<IEnumerable<MedicalAttachmentDto>> GetAttachmentsByRecordIdAsync(int medicalRecordId);
        Task<OperationResult> UploadAttachmentAsync(MedicalAttachmentCreateDto medicalAttachment);
        Task<byte[]?> DownloadAttachmentFileAsync(int attachmentId);
        Task<OperationResult> DeleteAttachmentAsync(int attachmentId);

        // Catalogos clinicos.
        Task<IEnumerable<DiagnosisTypeDto>> GetDiagnosisTypesAsync();
        Task<IEnumerable<ConsultationStatusDto>> GetConsultationStatusesAsync();
        Task<IEnumerable<AttachmentCategoryDto>> GetAttachmentCategoriesAsync();
    }
}
