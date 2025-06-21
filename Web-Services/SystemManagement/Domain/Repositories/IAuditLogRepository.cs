using Web_Services.SystemManagement.Domain.Model.Aggregates;
namespace Web_Services.SystemManagement.Domain.Repositories;

public interface IAuditLogRepository
{
    Task AddAsync(AuditLog auditLog);
    Task<AuditLog?> GetByIdAsync(string id);
    Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId);
}