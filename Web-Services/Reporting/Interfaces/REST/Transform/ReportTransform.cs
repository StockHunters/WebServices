using Web_Services.Reporting.Domain.Model.Aggregates;
using Web_Services.Reporting.Domain.Model.Commands;
using Web_Services.Reporting.Interfaces.REST.Resources;

namespace Web_Services.Reporting.Interfaces.REST.Transform;

public static class ReportTransform
{
    public static ReportResource ToResource(Report report)
    {
        return new ReportResource
        {
            Id = report.Id,
            UserId = report.UserId,
            ReportType = report.ReportType,
            GeneratedDate = report.GeneratedDate,
            FileUrl = report.FileUrl,
            Parameters = report.Parameters,
            CreatedAt = report.CreatedAt
        };
    }

    public static CreateReportCommand ToCommand(CreateReportResource resource)
    {
        return new CreateReportCommand
        {
            UserId = resource.UserId,
            ReportType = resource.ReportType,
            GeneratedDate = resource.GeneratedDate,
            FileUrl = resource.FileUrl,
            Parameters = resource.Parameters
        };
    }
}