using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface IProductPriceQueryService
{
    Task<ProductPrice?> Handle(GetProductPriceByIdQuery query);
    
    Task<ProductPrice?> Handle(GetProductPriceByProductIdQuery query);
    Task<IEnumerable<ProductPrice>> Handle(GetAllProductPriceQuery query);
}