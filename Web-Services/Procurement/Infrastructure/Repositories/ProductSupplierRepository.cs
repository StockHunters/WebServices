using Microsoft.EntityFrameworkCore;
using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.Procurement.Infrastructure.Repositories;

public class ProductSupplierRepository(AppDbContext context): BaseRepository<product_suppliers>(context), IProductSupplierRepository
{
    public async Task<IEnumerable<product_suppliers>> FindByProductIdAsync(int productId)
    {
        return await Context.Set<product_suppliers>().Where(f => f.product_id == productId).ToListAsync();
    }
}