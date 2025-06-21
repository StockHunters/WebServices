namespace Web_Services.Reporting.Interfaces.REST.Resources;

public class CreateReportResource
{
    public string UserId { get; set; }
    public string ReportType { get; set; }
    public DateTime GeneratedDate { get; set; }
    public string FileUrl { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
}