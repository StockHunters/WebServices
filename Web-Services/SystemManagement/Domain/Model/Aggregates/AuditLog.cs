namespace Web_Services.SystemManagement.Domain.Model.Aggregates;

public class AuditLog
{
    public string Id { get; private set; }
    public string UserId { get; private set; }
    public string ActionType { get; private set; }
    public string Description { get; private set; }
    public DateTime ActionDate { get; private set; }
    public string RelatedId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public AuditLog(string id, string userId, string actionType, string description, DateTime actionDate, string relatedId)
    {
        Id = id;
        UserId = userId;
        ActionType = actionType;
        Description = description;
        ActionDate = actionDate;
        RelatedId = relatedId;
        CreatedAt = DateTime.UtcNow;
    }
}