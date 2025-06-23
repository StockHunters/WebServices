using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Application.Internal.CommandServices;

public class PurchaseOrderItemCommandService(IPurchaseOrderItemRepository purchaseOrderItemRepository, IUnitOfWork unitOfWork): IPurchaseOrderItemCommandService
{
    public async Task<purchase_order_items?> Handle(CreatePurchaseOrderItemCommand command)
    {
        var purchaseOrderItem = new purchase_order_items(command);
        try
        {
            await purchaseOrderItemRepository.AddAsync(purchaseOrderItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return purchaseOrderItem;
    }
}