using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Interfaces.REST.Resources;

namespace Web_Services.ClientManagement.Interfaces.REST.Transform;

public static class SaleResourceFromEntityAssembler
{
    public static SaleResource ToResourceFromEntity(Sale entity)
    {
        return new SaleResource(entity.Id, entity.Date.Date, entity.Quantity.Quantity, entity.Status.Status, entity.ProductId,
            entity.ClientId, entity.UserId, entity.LocationId);
    }
}