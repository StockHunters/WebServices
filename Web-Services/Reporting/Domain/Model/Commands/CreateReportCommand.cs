namespace Web_Services.Reporting.Domain.Model.Commands;

public class CreateReportCommand
{
    public string UserId { get; set; }
    public string ReportType { get; set; }
    public DateTime GeneratedDate { get; set; }
    public string FileUrl { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
}