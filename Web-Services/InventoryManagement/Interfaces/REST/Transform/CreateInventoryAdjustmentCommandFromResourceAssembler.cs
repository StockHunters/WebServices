using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class CreateInventoryAdjustmentCommandFromResourceAssembler
{
    public static CreateInventoryAdjustmentCommand ToCommandFromResource(CreateInventoryAdjustmentResource resource)
    {
        return new CreateInventoryAdjustmentCommand(resource.ProductId, resource.LocationId, resource.Quantity,
            resource.Reason, resource.UserId, resource.AdjustmentDate);
    }
}