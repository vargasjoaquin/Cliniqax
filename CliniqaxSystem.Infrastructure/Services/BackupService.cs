using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.Configuration;
using CliniqaxSystem.Application.Interfaces.Repositories;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.IO.Compression;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class BackupService(ApplicationDbContext context, IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IOptions<DatabaseBackupSettings> backupOptions, IOptions<ClinicalStorageSettings> storageOptions) : IBackupService
    {
        private readonly DatabaseBackupSettings _settings = backupOptions.Value;
        private readonly ClinicalStorageSettings _storageSettings = storageOptions.Value;

        public async Task<OperationResult> ExecuteAutomaticBackupAsync()
        {
            if (!_settings.Enabled)
                return OperationResult.Ok("El servicio de copias automáticas está desactivado.");

            if (string.IsNullOrWhiteSpace(_settings.BackupPath))
                return OperationResult.Failure("No se ha definido la ruta de respaldo (BackupPath) en la configuración.");

            var stopwatch = Stopwatch.StartNew();
            string executor = currentUserService.Username;

            try
            {
                string backupDirectory = _settings.BackupPath;

                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                string connectionString = context.Database.GetConnectionString()
                    ?? throw new InvalidOperationException("Cadena de conexión no disponible.");

                var builder = new SqlConnectionStringBuilder(connectionString);

                string databaseName = builder.InitialCatalog;

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                string dbFileName = $"{databaseName}_Backup_{timestamp}.bak";
                string dbFilePath = Path.Combine(backupDirectory, dbFileName);

                string sql = $@"
                        BACKUP DATABASE [{databaseName}] 
                        TO DISK = @backupPath 
                        WITH FORMAT, INIT, COMPRESSION, CHECKSUM, 
                        NAME = 'Cliniqax-AutoBackup';";

                await using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    await using var cmd = new SqlCommand(sql, conn);
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@backupPath", dbFilePath);
                    await cmd.ExecuteNonQueryAsync();
                }

                long dbFileSize = new FileInfo(dbFilePath).Length;

                string storagePath = Path.IsPathRooted(_storageSettings.StorageBasePath)
                    ? _storageSettings.StorageBasePath
                    : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _storageSettings.StorageBasePath);

                if (Directory.Exists(storagePath) && Directory.EnumerateFileSystemEntries(storagePath).Any())
                {
                    string zipFileName = $"{databaseName}_Attachments_{timestamp}.zip";
                    string zipFilePath = Path.Combine(backupDirectory, zipFileName);
                    ZipFile.CreateFromDirectory(storagePath, zipFilePath, CompressionLevel.Optimal, false);

                    long zipFileSize = new FileInfo(zipFilePath).Length;

                    await unitOfWork.AuditLogs.AddBackupLogAsync(new BackupExecutionLog
                    {
                        BackupType = "CLINICAL_ATTACHMENTS",
                        DestinationPath = zipFilePath,
                        FileName = zipFileName,
                        FileSizeBytes = zipFileSize,
                        IsSuccess = true,
                        DurationSeconds = (int)stopwatch.Elapsed.TotalSeconds,
                        ExecutedBy = executor
                    });
                }

                if (_settings.RetentionDays > 0)
                {
                    CleanOldBackups(backupDirectory, databaseName, _settings.RetentionDays);
                }

                stopwatch.Stop();

                await unitOfWork.AuditLogs.AddBackupLogAsync(new BackupExecutionLog
                {
                    BackupType = "DATABASE_SQL",
                    DestinationPath = dbFilePath,
                    FileName = dbFileName,
                    FileSizeBytes = dbFileSize,
                    IsSuccess = true,
                    DurationSeconds = (int)stopwatch.Elapsed.TotalSeconds,
                    ExecutedBy = executor
                });

                await unitOfWork.CompleteAsync();

                return OperationResult.Ok($"Backup generado exitosamente en: {dbFilePath}");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                try
                {
                    await unitOfWork.AuditLogs.AddBackupLogAsync(new BackupExecutionLog
                    {
                        BackupType = "FAILED_ATTEMPT",
                        DestinationPath = _settings.BackupPath,
                        FileName = "None",
                        FileSizeBytes = 0,
                        IsSuccess = false,
                        ErrorMessage = ex.Message,
                        DurationSeconds = (int)stopwatch.Elapsed.TotalSeconds,
                        ExecutedBy = executor
                    });
                    await unitOfWork.CompleteAsync();
                }
                catch { }

                return OperationResult.Failure($"Error al generar el respaldo: {ex.Message}");
            }
        }

        private static void CleanOldBackups(string backupDirectory, string databaseName, int retentionDays)
        {
            try
            {
                var directory = new DirectoryInfo(backupDirectory);

                DateTime threshold = DateTime.Now.AddDays(-retentionDays);

                var oldFiles = directory.GetFiles($"{databaseName}_*.*")
                    .Where(f => (f.Extension == ".bak" || f.Extension == ".zip") && f.CreationTime < threshold);

                foreach (var file in oldFiles)
                {
                    file.Delete();
                }
            }
            catch 
            {
                // Silencioso para no abortar el flujo del usuario
            }
        }
    }
}
