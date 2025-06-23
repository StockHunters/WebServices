using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class ProductLocationQueryService(IProductLocationRepository productLocationRepository): IProductLocationQueryService
{
    public async Task<IEnumerable<ProductLocation>> Handle(GetAllProductLocationsQuery query)
    {
        return await productLocationRepository.ListAsync();
    }
    public async Task<ProductLocation?> Handle(GetProductLocationByIdQuery query)
    {
        return await productLocationRepository.FindByIdAsync(query.Id);
    }
}