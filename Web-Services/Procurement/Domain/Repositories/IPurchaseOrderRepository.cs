using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Domain.Repositories;

public interface IPurchaseOrderRepository: IBaseRepository<purchase_orders>
{
    Task<IEnumerable<purchase_orders>> FindByPurchaseOrderIdAsync(int purchaseOrderId);
}