using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class LocationQueryService(ILocationRepository locationRepository): ILocationQueryService
{
    public async Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query)
    {
        return await locationRepository.ListAsync();
    }
    
    public async Task<Location?> Handle(GetLocationByIdQuery query)
    {
        return await locationRepository.FindByIdAsync(query.Id);
    }
}