using Web_Services.OrganizationManagement.Domain.Model.Commands;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;

namespace Web_Services.OrganizationManagement.Interfaces.REST.Transform;

public static class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(
            resource.Name,
            resource.Description,
            resource.Feature,
            resource.Price);
    }
}