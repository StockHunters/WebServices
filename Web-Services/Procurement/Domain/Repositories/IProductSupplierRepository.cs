using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Domain.Repositories;

public interface IProductSupplierRepository: IBaseRepository<product_suppliers>
{
    Task<IEnumerable<product_suppliers>> FindByProductIdAsync(int productId);
}