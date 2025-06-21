using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Repositories;
namespace Web_Services.SystemManagement.Application.Internal.CommandServices;

public class AuditLogCommandService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogCommandService(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public async Task CreateAuditLogAsync(CreateAuditLogCommand command)
    {
        var auditLog = new AuditLog(
            id: $"AUD{Guid.NewGuid().ToString()[..8]}", // Genera un ID similar a AUD001
            userId: command.UserId,
            actionType: command.ActionType,
            description: command.Description,
            actionDate: command.ActionDate,
            relatedId: command.RelatedId
        );
        await _auditLogRepository.AddAsync(auditLog);
    }
}