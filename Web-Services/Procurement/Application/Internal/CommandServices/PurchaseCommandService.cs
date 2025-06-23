using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Application.Internal.CommandServices;

public class PurchaseCommandService(IPurchaseRepository purchaseRepository, IUnitOfWork unitOfWork): IPurchaseCommandService
{
    public async Task<purchases?> Handle(CreatePurchaseCommand command)
    {
        var purchase = new purchases(command);
        try
        {
            await purchaseRepository.AddAsync(purchase);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return purchase;
    }
}