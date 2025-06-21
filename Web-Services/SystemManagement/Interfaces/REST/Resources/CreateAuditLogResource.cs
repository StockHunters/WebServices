namespace Web_Services.SystemManagement.Interfaces.REST.Resources;

public class CreateAuditLogResource
{
    public string UserId { get; set; }
    public string ActionType { get; set; }
    public string Description { get; set; }
    public DateTime ActionDate { get; set; }
    public string RelatedId { get; set; }
}