using CliniqaxSystem.Application.Common;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicalStorageService
    {
        Task<OperationResult> SaveFileAsync(byte[] fileBytes, string originalFileName, string patientFullName, string? specialtyName = null, DateTime? fileDate = null);

        Task<byte[]?> ReadFileAsync(string relativePath);

        OperationResult DeleteFile(string relativePath);

        string GetPhysicalPath(string relativePath);
    }
}
