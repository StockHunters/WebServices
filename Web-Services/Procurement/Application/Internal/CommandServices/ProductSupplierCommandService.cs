using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Application.Internal.CommandServices;

public class ProductSupplierCommandService(IProductSupplierRepository productSupplierRepository, IUnitOfWork unitOfWork): IProductSupplierCommandService
{
    public async Task<product_suppliers?> Handle(CreateProductSupplierCommand command)
    {
        var productSupplier = new product_suppliers(command);
        try
        {
            await productSupplierRepository.AddAsync(productSupplier);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return productSupplier;
    }
}