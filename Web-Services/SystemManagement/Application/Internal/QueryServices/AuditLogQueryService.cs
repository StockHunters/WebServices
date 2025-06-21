using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Domain.Repositories;

namespace Web_Services.SystemManagement.Application.Internal.QueryServices;

public class AuditLogQueryService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogQueryService(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public async Task<AuditLog?> GetAuditLogByIdAsync(GetAuditLogByIdQuery query)
    {
        return await _auditLogRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<AuditLog>> GetAuditLogsByUserIdAsync(GetAuditLogsByUserIdQuery query)
    {
        return await _auditLogRepository.GetByUserIdAsync(query.UserId);
    }
}