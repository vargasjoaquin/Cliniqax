using CliniqaxSystem.Application.DTOs.Clinical;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IClinicalDocumentParserService
    {
        Task<ParsedClinicalDocumentDto> ParseDocumentAsync(byte[] fileBytes, string fileName);
    }
}
