using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.Patient;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto?> GetByIdAsync(int id);
        Task<PatientDto?> GetByDocumentAsync(string documentNumber);
        Task<OperationResult> RegisterPatientAsync(PatientCreateDto patientCreateDto);
        Task<OperationResult> UpdatePatientAsync(PatientUpdateDto patientUpdateDto);
        Task<OperationResult> DeletePatientAsync(int id);
        Task<IEnumerable<PatientDto>> SearchPatientsAsync(string term);
    }
}
