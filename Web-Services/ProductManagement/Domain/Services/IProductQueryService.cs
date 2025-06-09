using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Domain.Model.Queries;

namespace Web_Services.ProductManagement.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetAllProductsByCategoryIdQuery query);
    
    Task<Product?> Handle(GetProductByIdQuery query);
}