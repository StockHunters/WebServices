using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public class PurchaseOrderItemResourceFromEntityAssembler
{
    public static PurchaseOrderItemResource ToResourceFromEntity(purchase_order_items entity) =>
    new PurchaseOrderItemResource(entity.id, entity.order_id, entity.product_id, entity.quantity, entity.unit_price, entity.created_at);
}