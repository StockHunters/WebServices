using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;

namespace Web_Services.Procurement.Application.Internal.QueryServices;

public class PurchaseOrderQueryService(IPurchaseOrderRepository purchaseOrderRepository): IPurchaseOrderQueryService
{
    public async Task<purchase_orders?> Handle(GetPurchaseOrderByIdQuery query)
    {
        return await purchaseOrderRepository.FindByIdAsync(query.id);
    }
    
    public async Task<IEnumerable<purchase_orders>> Handle(GetAllPurchaseOrderQuery query)
    {
        return await purchaseOrderRepository.ListAsync();
    }
}