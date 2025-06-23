using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class CreatePurchaseCommandFromResourceAssembler
{
    public static CreatePurchaseCommand ToCommandFromResource(CreatePurchaseResource resource) =>
    new CreatePurchaseCommand(resource.supplier_id, resource.product_id, resource.order_id, resource.quantity, resource.purchase_date, resource.status, resource.user_id, resource.location_id, resource.created_at, resource.updated_at);
}
