using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class InventoryAdjustmentResourceFromEntityAssembler
{
    public static InventoryAdjustmentResource ToResourceFromEntity(InventoryAdjustment entity)
    {
        return new InventoryAdjustmentResource(entity.Id, entity.ProductId, entity.LocationId, entity.Quantity,
            entity.Reason, entity.UserId, entity.AdjustmentDate);
    }
}