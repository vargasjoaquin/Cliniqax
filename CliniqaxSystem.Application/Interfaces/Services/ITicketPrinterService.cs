namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ITicketPrinterService
    {
        IEnumerable<string> GetInstalledPrinters();
        Task<bool> PrintDocumentAsync(byte[] pdfBytes, string? printerName = null, int copies = 1);
    }
}
