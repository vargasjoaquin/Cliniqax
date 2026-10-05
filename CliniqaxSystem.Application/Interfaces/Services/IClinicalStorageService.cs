namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicalStorageService
    {
        Task<(string relativePath, string storedFileName)> SaveFileAsync(byte[] fileBytes, string originalFileName, string patientFullName, string? specialtyName = null, DateTime? fileDate = null);

        Task<byte[]?> ReadFileAsync(string relativePath);

        bool DeleteFile(string relativePath);

        string GetPhysicalPath(string relativePath);
    }
}
