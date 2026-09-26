using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.Configuration;
using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class BackupService(ApplicationDbContext context, IOptions<DatabaseBackupSettings> options) : IBackupService
    {
        private readonly DatabaseBackupSettings _settings = options.Value;

        public async Task<OperationResult> ExecuteAutomaticBackupAsync()
        {
            if (!_settings.Enabled)
                return OperationResult.Ok("El servicio de copias automáticas está desactivado.");

            if (string.IsNullOrWhiteSpace(_settings.BackupPath))
                return OperationResult.Failure("No se ha definido la ruta de respaldo (BackupPath) en la configuración.");

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
                string fileName = $"{databaseName}_Backup_{timestamp}.bak";
                string filePath = Path.Combine(backupDirectory, fileName);

                string sql = $@"
                        BACKUP DATABASE [{databaseName}] 
                        TO DISK = @backupPath 
                        WITH FORMAT, INIT, COMPRESSION, CHECKSUM, 
                        NAME = 'Cliniqax-AutoBackup';";

                await using (var conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    
                    await using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandTimeout = 180;
                        cmd.Parameters.AddWithValue("@backupPath", filePath);
                        
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (_settings.RetentionDays > 0)
                {
                    CleanOldBackups(backupDirectory, databaseName, _settings.RetentionDays);
                }

                return OperationResult.Ok($"Backup generado exitosamente en: {filePath}");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Error al generar el respaldo: {ex.Message}");
            }
        }

        private static void CleanOldBackups(string backupDirectory, string databaseName, int retentionDays)
        {
            try
            {
                var directory = new DirectoryInfo(backupDirectory);
                
                DateTime threshold = DateTime.Now.AddDays(-retentionDays);

                var oldFiles = directory.GetFiles($"{databaseName}_Backup_*.bak")
                    .Where(f => f.CreationTime < threshold);

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
