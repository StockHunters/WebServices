using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class CreateLocationCommandFromResourceAssembler
{
    public static CreateLocationCommand ToCommandFromResource(CreateLocationResource resource)
    {
        return new CreateLocationCommand(resource.OrganizationId,resource.name, resource.address, resource.city, resource.country);
    }
}