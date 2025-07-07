using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class CreatePurchaseOrderItemCommandFromResourceAssembler
{
    public static CreatePurchaseOrderItemCommand ToCommandFromResource(CreatePurchaseOrderItemResource resource) =>
    new CreatePurchaseOrderItemCommand(resource.order_id, resource.product_id, resource.quantity, resource.unit_price, resource.created_at);
}