namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IExcelService
    {
        byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName);
    }
}
