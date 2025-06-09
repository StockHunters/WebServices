using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Domain.Model.Commands;

namespace Web_Services.ProductManagement.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
}