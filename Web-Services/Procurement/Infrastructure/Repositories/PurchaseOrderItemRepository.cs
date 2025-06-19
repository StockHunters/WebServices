using Microsoft.EntityFrameworkCore;
using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.Procurement.Infrastructure.Repositories;

public class PurchaseOrderItemRepository(AppDbContext context): BaseRepository<purchase_order_items>(context), IPurchaseOrderItemRepository
{
    public async Task<IEnumerable<purchase_order_items>> FindByPurchaseOrderItemIdAsync(int purchaseOrderItemId)
    {
        return await Context.Set<purchase_order_items>().Where(f => f.id == purchaseOrderItemId).ToListAsync();
    }
}