using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Application.Internal.CommandServices;

public class ProductLocationCommandService(IProductLocationRepository productLocationRepository, IUnitOfWork unitOfWork):IProductLocationCommandService
{
    public async Task<ProductLocation?> Handle(CreateProductLocationCommand command)
    {
        var productLocation = new ProductLocation(command);
        try
        {
            await productLocationRepository.AddAsync(productLocation);
            await unitOfWork.CompleteAsync();
            return productLocation;
        }catch (Exception e)
        {
            return null;
        }
        
    }
}