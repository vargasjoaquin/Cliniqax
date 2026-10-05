using CliniqaxSystem.Application.Interfaces.Services;
using ClosedXML.Excel;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            var table = worksheet.Cell(1, 1).InsertTable(data);
            table.Theme = XLTableTheme.TableStyleMedium9;
            worksheet.Columns().AdjustToContents();

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
