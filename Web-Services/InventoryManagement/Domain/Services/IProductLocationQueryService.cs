using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface IProductLocationQueryService
{
    Task<IEnumerable<ProductLocation>> Handle(GetAllProductLocationsQuery query);
    
    Task<ProductLocation?> Handle(GetProductLocationByIdQuery query);
}