using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.OrganizationId, entity.Username, entity.Email, entity.PasswordHash,
            entity.FirstName, entity.LastName, entity.ProfileImageUrl);
    }
}