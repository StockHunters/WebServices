using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository): IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsByCategoryIdQuery query)
    {
        return await productRepository.FindByCategoryIdAsync(query.CategoryId);
    }
    
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }
}