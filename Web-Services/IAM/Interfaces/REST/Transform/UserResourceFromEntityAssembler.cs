using Web_Services.IAM.Domain.Model.Aggregates;
using Web_Services.IAM.Interfaces.REST.Resources;

namespace Web_Services.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}