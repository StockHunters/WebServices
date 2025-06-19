using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Domain.Repositories;

public interface IPurchaseOrderItemRepository: IBaseRepository<purchase_order_items>
{
    Task<IEnumerable<purchase_order_items>> FindByPurchaseOrderItemIdAsync(int purchaseOrderItemId);
}