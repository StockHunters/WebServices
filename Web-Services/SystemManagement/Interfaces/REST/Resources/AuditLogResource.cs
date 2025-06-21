namespace Web_Services.SystemManagement.Interfaces.REST.Resources;
public class AuditLogResource
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string ActionType { get; set; }
    public string Description { get; set; }
    public DateTime ActionDate { get; set; }
    public string RelatedId { get; set; }
    public DateTime CreatedAt { get; set; }
}