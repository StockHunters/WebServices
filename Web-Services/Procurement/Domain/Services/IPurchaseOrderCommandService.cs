using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Model.Aggregates;

namespace Web_Services.Procurement.Domain.Services;

public interface IPurchaseOrderCommandService
{
    Task<purchase_orders?> Handle(CreatePurchaseOrderCommand command);
}