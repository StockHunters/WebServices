using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class ProductSupplierResourceFromEntityAssembler
{
    public static ProductSupplierResource ToResourceFromEntity(product_suppliers entity) =>
    new ProductSupplierResource(entity.id, entity.product_id, entity.supplier_id, entity.supply_price, entity.created_at);
}