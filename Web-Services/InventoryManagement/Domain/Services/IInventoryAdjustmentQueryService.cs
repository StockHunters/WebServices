using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface IInventoryAdjustmentQueryService
{
    Task<IEnumerable<InventoryAdjustment>> Handle(GetAllInventoryAdjustmentsQuery query);
    Task<InventoryAdjustment?> Handle(GetInventoryAdjustmentByIdQuery query);
}