using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface ILocationQueryService
{
    Task<IEnumerable<Location>> Handle(GetAllLocationsQuery query);
    
    Task<Location?> Handle(GetLocationByIdQuery query);
}