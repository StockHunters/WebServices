using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class ProductLocationResourceFromEntityAssembler
{
    public static ProductLocationResource ToResourceFromEntity(ProductLocation entity)
    {
        return new ProductLocationResource(entity.Id, entity.ProductId, entity.LocationId, entity.Stock);
    }
}