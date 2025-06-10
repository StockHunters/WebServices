using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Interfaces.REST.Resources;

namespace Web_Services.ProductManagement.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity) =>
    new ProductResource(entity.Id, entity.Name, entity.ImageUrl, entity.Stock, entity.CategoryId);
}