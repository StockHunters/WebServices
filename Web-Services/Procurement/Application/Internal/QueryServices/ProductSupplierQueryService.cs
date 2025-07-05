using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;

namespace Web_Services.Procurement.Application.Internal.QueryServices;

public class ProductSupplierQueryService(IProductSupplierRepository productSupplierRepository): IProductSupplierQueryService
{
    public async Task<product_suppliers?> Handle(GetProductSupplierByIdQuery query)
    {
        return await productSupplierRepository.FindByIdAsync(query.id);
    }
    
    public async Task<IEnumerable<product_suppliers>> Handle(GetAllProductSuppliersQuery query)
    {
        return await productSupplierRepository.ListAsync();
    }
}