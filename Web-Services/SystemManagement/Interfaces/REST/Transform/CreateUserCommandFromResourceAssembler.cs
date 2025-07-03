using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserAccountCommand ToCommandFromResource(CreateUserAccountResource accountResource)
    {
        return new CreateUserAccountCommand(
            accountResource.OrganizationId,
            accountResource.UserId,
            accountResource.Email,
            accountResource.FirstName,
            accountResource.LastName,
            accountResource.ProfileImageUrl);
    }
}