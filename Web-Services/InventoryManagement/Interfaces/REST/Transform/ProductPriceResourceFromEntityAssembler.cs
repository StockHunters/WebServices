using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class ProductPriceResourceFromEntityAssembler
{
    public static ProductPriceResource ToResourceFromEntity(ProductPrice entity)
    {
        return new ProductPriceResource(entity.Id, entity.ProductId, entity.Price, entity.Discount, entity.EffectiveDate);
    }
}