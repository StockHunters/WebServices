using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Services;

public interface IPurchaseCommandService
{
    Task<purchases?> Handle(CreatePurchaseCommand command);
}