using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;

namespace Web_Services.Procurement.Domain.Services;

public interface IProductSupplierQueryService
{
    Task<product_suppliers?> Handle(GetProductSupplierByIdQuery query);
}