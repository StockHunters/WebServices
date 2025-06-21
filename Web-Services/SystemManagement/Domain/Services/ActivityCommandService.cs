using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Repositories;
namespace Web_Services.SystemManagement.Domain.Services;

    public class ActivityCommandService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityCommandService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task CreateActivityAsync(CreateActivityCommand command)
        {
            var activity = new Activity(
                id: $"ACT{Guid.NewGuid().ToString()[..8]}",
                userId: command.UserId,
                activityType: command.ActivityType,
                description: command.Description,
                activityDate: command.ActivityDate
            );
            await _activityRepository.AddAsync(activity);
        }
    }

