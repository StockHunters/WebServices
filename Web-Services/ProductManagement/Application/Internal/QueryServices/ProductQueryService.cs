using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Domain.Model.Queries;
using Web_Services.ProductManagement.Domain.Repositories;
using Web_Services.ProductManagement.Domain.Services;

namespace Web_Services.ProductManagement.Application.Internal.QueryServices;

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