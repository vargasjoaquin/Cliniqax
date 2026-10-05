using CliniqaxSystem.Application.Common;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IRestoreService
    {
        Task<IEnumerable<DeletedItemDto>> GetDeletedEntitiesAsync(string entityType);
        Task<OperationResult> RestoreEntityAsync(string entityType, int id);
    }
}
