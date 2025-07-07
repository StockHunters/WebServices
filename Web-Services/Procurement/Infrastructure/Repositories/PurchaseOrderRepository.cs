using Microsoft.EntityFrameworkCore;
using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.Procurement.Infrastructure.Repositories;

public class PurchaseOrderRepository(AppDbContext context): BaseRepository<purchase_orders>(context), IPurchaseOrderRepository
{
    public async Task<IEnumerable<purchase_orders>> FindByPurchaseOrderIdAsync(int purchaseOrderId)
    {
        return await Context.Set<purchase_orders>().Where(f => f.id == purchaseOrderId).ToListAsync();
    }
}