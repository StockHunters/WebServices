using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class PurchaseResourceFromEntityAssembler
{
    public static PurchaseResource ToResourceFromEntity(purchases entity) =>
        new PurchaseResource(
            entity.id,
            entity.supplier_id, 
            entity.product_id, 
            entity.order_id, 
            entity.quantity,
            entity.purchase_date,
            entity.status, 
            entity.user_id,
            entity.location_id,
            entity.created_at,
            entity.updated_at);
}