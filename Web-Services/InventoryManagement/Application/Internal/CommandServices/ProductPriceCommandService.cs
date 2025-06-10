using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Application.Internal.CommandServices;

public class ProductPriceCommandService(IProductPriceRepository productPriceRepository, IUnitOfWork unitOfWork): IProductPriceCommandService
{
    public async Task<ProductPrice?> Handle(CreateProductPriceCommand command)
    {
        var productPrice = new ProductPrice(command);
        await productPriceRepository.AddAsync(productPrice);
        await unitOfWork.CompleteAsync();
        return productPrice;
    }
}