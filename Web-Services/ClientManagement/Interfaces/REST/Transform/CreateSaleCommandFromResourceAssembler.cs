using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Interfaces.REST.Resources;

namespace Web_Services.ClientManagement.Interfaces.REST.Transform;

public static class CreateSaleCommandFromResourceAssembler
{
    public static CreateSaleCommand ToCommandFromResource(CreateSaleResource resource)
    {
        return new CreateSaleCommand(
            resource.Date,
            resource.Quantity,
            resource.Status,
            resource.ProductId,
            resource.ClientId,
            resource.UserId,
            resource.LocationId);
    }
}