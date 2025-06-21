using Web_Services.SystemManagement.Domain.Model.Aggregates;
namespace Web_Services.SystemManagement.Domain.Repositories;

public interface IActivityRepository
{
    Task AddAsync(Activity activity);
    Task<Activity?> GetByIdAsync(string id);
    Task<IEnumerable<Activity>> GetByUserIdAsync(string userId);
}