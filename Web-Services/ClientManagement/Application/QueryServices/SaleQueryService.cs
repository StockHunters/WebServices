using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Queries;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;

namespace Web_Services.ClientManagement.Application.QueryServices;

public class SaleQueryService(ISaleRepository saleRepository): ISaleQueryService
{
    public async Task<IEnumerable<Sale>> Handle(GetAllSalesQuery query)
    {
        return await saleRepository.ListAsync();
    }

    public async Task<Sale?> Handle(GetSaleByIdQuery query)
    {
        return await saleRepository.FindByIdAsync(query.Id);
    }
}