using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Domain.Repositories;

public interface IPurchaseRepository: IBaseRepository<purchases>
{
    Task<IEnumerable<purchases>> FindByPurchaseIdAsync(int purchaseId);
}