using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId);
}