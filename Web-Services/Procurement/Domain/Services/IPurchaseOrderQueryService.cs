using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;

namespace Web_Services.Procurement.Domain.Services;

public interface IPurchaseOrderQueryService
{
    Task<purchase_orders?> Handle(GetPurchaseOrderByIdQuery query);
    Task<IEnumerable<purchase_orders>> Handle(GetAllPurchaseOrderQuery getAllPurchaseOrderQuery);
}