using CliniqaxSystem.Application.Interfaces.Services;
using System.Diagnostics;
using System.Drawing.Printing;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class TicketPrinterService : ITicketPrinterService
    {
        public IEnumerable<string> GetInstalledPrinters()
        {
            var printers = new List<string>();
            
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }

            return printers;
        }

        public async Task<bool> PrintDocumentAsync(byte[] pdfBytes, string? printerName = null, int copies = 1)
        {
            if (pdfBytes == null || pdfBytes.Length == 0)
                return false;

            return await Task.Run(() =>
            {
                try
                {
                    string temporaryPdf = Path.Combine(Path.GetTempPath(), $"print_{Guid.NewGuid()}.pdf");
                    
                    File.WriteAllBytes(temporaryPdf, pdfBytes);

                    var psi = new ProcessStartInfo
                    {
                        FileName = temporaryPdf,
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    if (!string.IsNullOrWhiteSpace(printerName))
                    {
                        psi.Verb = "printto";
                        psi.Arguments = $"\"{printerName}\"";
                    }
                    else
                    {
                        psi.Verb = "print";
                    }

                    using var process = Process.Start(psi);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
