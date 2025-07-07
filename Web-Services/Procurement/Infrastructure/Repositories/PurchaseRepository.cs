using Microsoft.EntityFrameworkCore;
using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.Procurement.Infrastructure.Repositories;

public class PurchaseRepository(AppDbContext context): BaseRepository<purchases>(context), IPurchaseRepository
{
    public async Task<IEnumerable<purchases>> FindByPurchaseIdAsync(int purchaseId)
    {
        return await Context.Set<purchases>().Where(f => f.id == purchaseId).ToListAsync();
    }
}