using Web_Services.IAM.Domain.Model.Aggregates;
using Web_Services.IAM.Interfaces.REST.Resources;

namespace Web_Services.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}