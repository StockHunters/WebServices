using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;

namespace Web_Services.Procurement.Application.Internal.QueryServices;

public class PurchaseOrderItemQueryService(IPurchaseOrderItemRepository purchaseOrderItemRepository): IPurchaseOrderItemQueryService
{
    public async Task<purchase_order_items?> Handle(GetPurchaseOrderItemsByIdQuery query)
    {
        return await purchaseOrderItemRepository.FindByIdAsync(query.id);
    }
    
    public async Task<IEnumerable<purchase_order_items>> Handle(GetAllPurchaseOrderItemQuery query)
    {
        return await purchaseOrderItemRepository.ListAsync();
    }
}