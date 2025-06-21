using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Domain.Repositories;

namespace Web_Services.SystemManagement.Domain.Services;

public class ActivityQueryService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityQueryService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Activity?> GetActivityByIdAsync(GetActivityByIdQuery query)
    {
        return await _activityRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Activity>> GetActivitiesByUserIdAsync(GetActivitiesByUserIdQuery query)
    {
        return await _activityRepository.GetByUserIdAsync(query.UserId);
    }
}