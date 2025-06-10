using Microsoft.EntityFrameworkCore;
using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.ProductManagement.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context): BaseRepository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Product>().Where(f => f.CategoryId == categoryId).ToListAsync();
    }
    
}