using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserAccountResource ToResourceFromEntity(UserAccount entity)
    {
        return new UserAccountResource(entity.Id, entity.OrganizationId, entity.UserId, entity.Email,
            entity.FirstName, entity.LastName, entity.ProfileImageUrl);
    }
}