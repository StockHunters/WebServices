namespace Web_Services.SystemManagement.Interfaces.REST.Resources;

public class ActivityResource
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string ActivityType { get; set; }
    public string Description { get; set; }
    public DateTime ActivityDate { get; set; }
}