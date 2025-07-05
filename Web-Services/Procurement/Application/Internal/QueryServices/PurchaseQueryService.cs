using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;

namespace Web_Services.Procurement.Application.Internal.QueryServices;

public class PurchaseQueryService(IPurchaseRepository purchaseRepository): IPurchaseQueryService
{
    public async Task<purchases?> Handle(GetPurchaseByIdQuery query)
    {
        return await purchaseRepository.FindByIdAsync(query.id);
    }
    public async Task<IEnumerable<purchases>> Handle(GetAllPurchaseQuery query)
    {
        return await purchaseRepository.ListAsync();
    }
}