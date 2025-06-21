using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Interfaces.REST.Resources;

namespace Web_Services.SystemManagement.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
            resource.OrganizationId,
            resource.Username,
            resource.Email,
            resource.PasswordHash,
            resource.FirstName,
            resource.LastName,
            resource.ProfileImageUrl);
    }
}