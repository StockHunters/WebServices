using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;

namespace Web_Services.Procurement.Domain.Services;

public interface IPurchaseOrderItemQueryService
{
    Task<purchase_order_items?> Handle(GetPurchaseOrderItemsByIdQuery query);
    Task<IEnumerable<purchase_order_items>> Handle(GetAllPurchaseOrderItemQuery query);
}