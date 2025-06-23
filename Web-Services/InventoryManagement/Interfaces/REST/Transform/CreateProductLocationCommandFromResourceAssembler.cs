using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class CreateProductLocationCommandFromResourceAssembler
{
    public static CreateProductLocationCommand ToCommandFromResource(CreateProductLocationResource resource)
    {
        return new CreateProductLocationCommand(
            resource.ProductId,
            resource.LocationId,
            resource.Stock);
    }
}