using Web_Services.Reporting.Domain.Model.Aggregates;

namespace Web_Services.Reporting.Domain.Repositories;

public interface IReportRepository
{
    Task AddAsync(Report report);
    Task<Report> GetByIdAsync(string id);
    Task<IEnumerable<Report>> GetByUserIdAsync(string userId);
}