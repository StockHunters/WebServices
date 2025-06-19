using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;

namespace Web_Services.Procurement.Application.Internal.QueryServices;

public class LotQueryService(ILotRepository lotRepository): ILotQueryService
{
    public async Task<lots?> Handle(GetLotByIdQuery query)
    {
        return await lotRepository.FindByIdAsync(query.id);
    }
}