using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Application.Internal.CommandServices;

public class PurchaseOrderCommandService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork): IPurchaseOrderCommandService
{
    public async Task<purchase_orders?> Handle(CreatePurchaseOrderCommand command)
    {
        var purchaseOrder = new purchase_orders(command);
        try
        {
            await purchaseOrderRepository.AddAsync(purchaseOrder);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return purchaseOrder;
    }
}