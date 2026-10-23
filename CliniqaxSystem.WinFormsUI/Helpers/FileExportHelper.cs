using System.Diagnostics;

namespace CliniqaxSystem.WinFormsUI.Helpers
{
    public static class FileExportHelper
    {
        public static async Task<bool> SaveAndOpenPdfAsync(Form owner, byte[]? pdfBytes, string defaultFileName, string dialogTitle = "Guardar Documento PDF")
        {
            return await SaveAndOpenFileAsync(owner, pdfBytes, defaultFileName, "Archivos PDF (*.pdf)|*.pdf", dialogTitle);
        }

        public static async Task<bool> SaveAndOpenExcelAsync(Form owner, byte[]? excelBytes, string defaultFileName, string dialogTitle = "Guardar Reporte en Excel")
        {
            return await SaveAndOpenFileAsync(owner, excelBytes, defaultFileName, "Archivos Excel (*.xlsx)|*.xlsx", dialogTitle);
        }

        public static async Task<bool> SaveAndOpenWordAsync(Form owner, byte[]? wordBytes, string defaultFileName, string dialogTitle = "Guardar Plantilla en Word")
        {
            return await SaveAndOpenFileAsync(owner, wordBytes, defaultFileName, "Documentos de Microsoft Word (*.docx)|*.docx", dialogTitle);
        }

        public static async Task<bool> SaveAndOpenFileAsync(Form owner, byte[]? fileBytes, string defaultFileName, string filter, string dialogTitle = "Guardar Archivo")
        {
            if (fileBytes == null || fileBytes.Length == 0)
            {
                MessageBox.Show(owner, "No hay contenido generado para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string cleanFileName = SanitizeFileName(defaultFileName);

            using var sfd = new SaveFileDialog
            {
                Title = dialogTitle,
                Filter = filter,
                FileName = cleanFileName,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog(owner) != DialogResult.OK)
                return false;

            try
            {
                await File.WriteAllBytesAsync(sfd.FileName, fileBytes);
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, $"Ocurrió un error al guardar o abrir el archivo:\n{ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string SanitizeFileName(string fileName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitized = string.Concat(fileName.Select(c => invalidChars.Contains(c) ? '_' : c));
            
            return sanitized.Replace('/', '-').Replace('\\', '-');
        }
    }
}
