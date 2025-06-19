using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class PurchaseOrderResourceFromEntityAssembler
{
    public static PurchaseOrderResource ToResourceFromEntity(purchase_orders entity) =>
        new PurchaseOrderResource(entity.id, entity.supplier_id, entity.user_id, entity.location_id, entity.order_date, entity.status, entity.created_at, entity.updated_at);
}