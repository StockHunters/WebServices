using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class CreatePurchaseOrderCommandFromResourceAssembler
{
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource) =>
    new CreatePurchaseOrderCommand(resource.supplier_id, resource.user_id, resource.location_id, resource.order_date, resource.status, resource.created_at, resource.updated_at);
}