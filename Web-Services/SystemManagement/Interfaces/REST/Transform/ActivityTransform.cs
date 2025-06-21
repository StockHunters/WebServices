using Web_Services.SystemManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Interfaces.REST.Resources;
namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class ActivityTransform
{
    public static ActivityResource ToResource(Activity activity)
    {
        return new ActivityResource
        {
            Id = activity.Id,
            UserId = activity.UserId,
            ActivityType = activity.ActivityType,
            Description = activity.Description,
            ActivityDate = activity.ActivityDate
        };
    }

    public static CreateActivityCommand ToCommand(CreateActivityResource resource)
    {
        return new CreateActivityCommand
        {
            UserId = resource.UserId,
            ActivityType = resource.ActivityType,
            Description = resource.Description,
            ActivityDate = resource.ActivityDate
        };
    }
}