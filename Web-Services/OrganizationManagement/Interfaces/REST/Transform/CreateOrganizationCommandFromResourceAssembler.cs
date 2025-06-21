using Web_Services.OrganizationManagement.Domain.Model.Commands;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;

namespace Web_Services.OrganizationManagement.Interfaces.REST.Transform;

public static class CreateOrganizationCommandFromResourceAssembler
{
    public static CreateOrganizationCommand ToCommandFromResource(CreateOrganizationResource resource)
    {
        return new CreateOrganizationCommand(
            resource.Name,
            resource.ContactEmail,
            resource.PlanId);
    }
}