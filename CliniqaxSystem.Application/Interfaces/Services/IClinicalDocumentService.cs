using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicalDocumentService
    {
        Task<byte[]> GenerateOfficialMedicalRecordPdfAsync(int patientId);

        Task<byte[]> GenerateBlankTemplatePdfAsync(int? patientId = null);

        Task<OperationResult> SyncAndStoreOfficialRecordPdfAsync(int patientId, string reason = "Actualización");

        Task<OperationResult> ProcessFilledTemplateAsync(byte[] fileBytes, string fileName, int? targetPatientId = null);

        Task<OperationResult> ImportExternalClinicalDocumentAsync(byte[] fileBytes, string fileName, int? targetPatientId = null);

        Task<byte[]> GenerateBlankTemplateWordAsync(int? patientId = null);
    }
}
