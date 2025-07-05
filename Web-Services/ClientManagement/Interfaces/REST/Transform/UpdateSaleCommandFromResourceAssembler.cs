using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Interfaces.REST.Resources;

namespace Web_Services.ClientManagement.Interfaces.REST.Transform;

public static class UpdateSaleCommandFromResourceAssembler
{
    public static UpdateSaleCommand ToCommandFromResource(UpdateSaleResource resource)
    {
        return new UpdateSaleCommand(
            resource.Id,
            resource.Date,
            resource.Quantity,
            resource.Status);
    }
}