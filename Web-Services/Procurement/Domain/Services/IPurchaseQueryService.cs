using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Queries;

namespace Web_Services.Procurement.Domain.Services;

public interface IPurchaseQueryService
{
    Task<purchases?> Handle(GetPurchaseByIdQuery query);
}