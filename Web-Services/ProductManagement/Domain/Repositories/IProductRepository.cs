using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.ProductManagement.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId);
}