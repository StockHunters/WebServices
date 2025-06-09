using Web_Services.ProductManagement.Domain.Model.Aggregates;
using Web_Services.ProductManagement.Domain.Model.Commands;
using Web_Services.ProductManagement.Domain.Repositories;
using Web_Services.ProductManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.ProductManagement.Application.Internal.CommandServices;

public class ProductCommandService( IProductRepository productRepository, IUnitOfWork unitOfWork): IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return product;
    }
}