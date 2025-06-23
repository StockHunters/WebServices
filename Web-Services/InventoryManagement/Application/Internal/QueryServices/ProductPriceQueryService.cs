using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class ProductPriceQueryService(IProductPriceRepository productPriceRepository): IProductPriceQueryService
{
    public async Task<ProductPrice?> Handle(GetProductPriceByIdQuery query)
    {
        return await productPriceRepository.FindByProductIdAsync(query.Id);
    }

    public async Task<ProductPrice?> Handle(GetProductPriceByProductIdQuery query)
    {
        return await productPriceRepository.FindByProductIdAsync(query.ProductId);
    }
}