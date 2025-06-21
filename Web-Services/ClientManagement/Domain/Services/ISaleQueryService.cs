using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Queries;

namespace Web_Services.ClientManagement.Domain.Services;

public interface ISaleQueryService
{
    Task<Sale?> Handle(GetSaleByIdQuery query);

    Task<IEnumerable<Sale>> Handle(GetAllSalesQuery query);
}