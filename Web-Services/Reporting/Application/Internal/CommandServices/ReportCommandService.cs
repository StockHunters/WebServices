using Web_Services.Reporting.Domain.Model.Aggregates;
using Web_Services.Reporting.Domain.Model.Commands;
using Web_Services.Reporting.Domain.Repositories;

namespace Web_Services.Reporting.Application.Internal.CommandServices;

public class ReportCommandService
{
    private readonly IReportRepository _reportRepository;

    public ReportCommandService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task CreateReportAsync(CreateReportCommand command)
    {
        var report = new Report(
            id: $"REP{Guid.NewGuid().ToString()[..8]}", // Genera un ID similar a REP001
            userId: command.UserId,
            reportType: command.ReportType,
            generatedDate: command.GeneratedDate,
            fileUrl: command.FileUrl,
            parameters: command.Parameters
        );
        await _reportRepository.AddAsync(report);
    }
}