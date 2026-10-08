using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.Configuration;
using CliniqaxSystem.Application.DTOs.Clinical;
using CliniqaxSystem.Application.DTOs.Clinical.File;
using CliniqaxSystem.Application.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class ClinicalStorageService(IOptions<ClinicalStorageSettings> options) : IClinicalStorageService
    {
        private readonly ClinicalStorageSettings _settings = options.Value;

        private string GetStorageBasePath()
        {
            string configuredPath = _settings.StorageBasePath.Trim();
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuredPath);
        }

        public async Task<OperationResult> SaveFileAsync(byte[] fileBytes, string originalFileName, string patientFullName, string? specialtyName = null, DateTime? fileDate = null)
        {
            if (fileBytes == null || fileBytes.Length == 0)
                return OperationResult.Failure("El archivo no contiene datos o se encuentra vacío.");

            if (string.IsNullOrWhiteSpace(originalFileName))
                return OperationResult.Failure("El nombre del archivo original es requerido.");

            try
            {
                string basePath = GetStorageBasePath();

                string patientFolder = patientFullName.Trim();
                string specialtyFolder = specialtyName.Trim();
                string dateFolder = (fileDate ?? DateTime.Today).ToString("yyyy-MM-dd");

                string relativeFolder = Path.Combine(patientFolder, specialtyFolder, dateFolder);
                string destinationFolder = Path.Combine(basePath, relativeFolder);

                if (!Directory.Exists(destinationFolder))
                    Directory.CreateDirectory(destinationFolder);

                string fileExtension = Path.GetExtension(originalFileName).ToLowerInvariant();
                string fileIdentifier = Guid.NewGuid().ToString("N")[..8];
                string baseFileName = Path.GetFileNameWithoutExtension(originalFileName).Trim();
                string storedFileName = $"{fileIdentifier}_{baseFileName}{fileExtension}";

                string fullPath = Path.Combine(destinationFolder, storedFileName);
                await File.WriteAllBytesAsync(fullPath, fileBytes);

                string relativePath = Path.Combine(relativeFolder, storedFileName).Replace('\\', '/');

                var fileData = new StoredFileDto
                {
                    RelativePath = relativePath,
                    StoredFileName = storedFileName
                };

                return OperationResult.Ok("Archivo guardado exitosamente.", data: fileData);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error al guardar el archivo en disco: {ex.Message}");
            }
        }

        public async Task<byte[]?> ReadFileAsync(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return null;

            string fullPath = GetPhysicalPath(relativePath);

            if (!File.Exists(fullPath))
                return null;

            return await File.ReadAllBytesAsync(fullPath);
        }

        public OperationResult DeleteFile(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return OperationResult.Failure("La ruta del archivo es inválida.");

            try
            {
                string fullPath = GetPhysicalPath(relativePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return OperationResult.Ok("Archivo eliminado correctamente del disco.");
                }

                return OperationResult.Failure("El archivo no fue encontrado en el disco.");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error al eliminar el archivo: {ex.Message}");
            }
        }

        public string GetPhysicalPath(string relativePath)
        {
            string basePath = GetStorageBasePath();
            string relativeSystemPath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            return Path.Combine(basePath, relativeSystemPath);
        }
    }
}
