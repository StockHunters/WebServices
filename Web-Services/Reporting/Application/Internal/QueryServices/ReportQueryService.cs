using Web_Services.Reporting.Domain.Model.Aggregates;
using Web_Services.Reporting.Domain.Model.Queries;
using Web_Services.Reporting.Domain.Repositories;

namespace Web_Services.Reporting.Application.Internal.QueryServices;

public class ReportQueryService
{
    private readonly IReportRepository _reportRepository;

    public ReportQueryService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<Report> GetReportByIdAsync(GetReportByIdQuery query)
    {
        return await _reportRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Report>> GetReportsByUserIdAsync(GetReportsByUserIdQuery query)
    {
        return await _reportRepository.GetByUserIdAsync(query.UserId);
    }
}