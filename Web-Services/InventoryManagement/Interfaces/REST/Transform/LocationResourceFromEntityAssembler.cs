using Microsoft.EntityFrameworkCore.Infrastructure;
using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class LocationResourceFromEntityAssembler
{
    public static LocationResource ToResourceFromEntity(Location entity)
    {
        return new LocationResource(
            entity.Id,
            entity.OrganizationId,
            entity.Name,
            entity.Address.Address,
            entity.Address.City,
            entity.Address.Country);
    }
    
}