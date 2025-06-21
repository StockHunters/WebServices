namespace Web_Services.Reporting.Domain.Model.Aggregates;

public class Report
{
    public string Id { get; private set; }
    public string UserId { get; private set; }
    public string ReportType { get; private set; }
    public DateTime GeneratedDate { get; private set; }
    public string FileUrl { get; private set; }
    public Dictionary<string, string> Parameters { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Report(string id, string userId, string reportType, DateTime generatedDate, string fileUrl, Dictionary<string, string> parameters)
    {
        Id = id;
        UserId = userId;
        ReportType = reportType;
        GeneratedDate = generatedDate;
        FileUrl = fileUrl;
        Parameters = parameters;
        CreatedAt = DateTime.UtcNow;
    }
}