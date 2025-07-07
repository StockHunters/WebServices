using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public class LotResourceFromEntityAssembler
{
    public static LotResource ToResourceFromEntity(lots entity) =>
    new LotResource(entity.id, entity.product_id, entity.purchase_id, entity.lot_number, entity.purchase_date, entity.expiration_date, entity.created_at);
}