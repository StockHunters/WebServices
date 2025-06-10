using Microsoft.EntityFrameworkCore;
using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.InventoryManagement.Infrastructure.Repositories;

public class ProductPriceRepository(AppDbContext context): BaseRepository<ProductPrice>(context), IProductPriceRepository
{
    public async Task<ProductPrice?> FindByProductIdAsync(int productId)
    {
        return await Context.Set<ProductPrice>().Include(productPrice => productPrice.Product)
            .FirstOrDefaultAsync(f => f.ProductId == productId);
    }
}