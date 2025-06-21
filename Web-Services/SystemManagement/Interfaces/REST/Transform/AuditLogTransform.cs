using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class AuditLogTransform
{
    public static AuditLogResource ToResource(AuditLog auditLog)
    {
        return new AuditLogResource
        {
            Id = auditLog.Id,
            UserId = auditLog.UserId,
            ActionType = auditLog.ActionType,
            Description = auditLog.Description,
            ActionDate = auditLog.ActionDate,
            RelatedId = auditLog.RelatedId,
            CreatedAt = auditLog.CreatedAt
        };
    }

    public static CreateAuditLogCommand ToCommand(CreateAuditLogResource resource)
    {
        return new CreateAuditLogCommand
        {
            UserId = resource.UserId,
            ActionType = resource.ActionType,
            Description = resource.Description,
            ActionDate = resource.ActionDate,
            RelatedId = resource.RelatedId
        };
    }
}