namespace Web_Services.SystemManagement.Domain.Model.Commands;

public class CreateAuditLogCommand
{
    public string UserId { get; set; }
    public string ActionType { get; set; }
    public string Description { get; set; }
    public DateTime ActionDate { get; set; }
    public string RelatedId { get; set; }
}