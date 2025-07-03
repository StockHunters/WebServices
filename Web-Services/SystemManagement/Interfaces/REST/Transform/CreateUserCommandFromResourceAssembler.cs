using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserAccountResource accountResource)
    {
        return new CreateUserCommand(
            accountResource.OrganizationId,
            accountResource.Username,
            accountResource.Email,
            accountResource.PasswordHash,
            accountResource.FirstName,
            accountResource.LastName,
            accountResource.ProfileImageUrl);
    }
}