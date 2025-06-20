using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class InventoryAdjustmentQueryService(IInventoryAdjustmentRepository inventoryAdjustmentRepository): IInventoryAdjustmentQueryService
{
    public async Task<IEnumerable<InventoryAdjustment>> Handle(GetAllInventoryAdjustmentsQuery query)
    {
        return await inventoryAdjustmentRepository.ListAsync();
    }
    
    public async Task<InventoryAdjustment?> Handle(GetInventoryAdjustmentByIdQuery query)
    {
        return await inventoryAdjustmentRepository.FindByIdAsync(query.Id);
    }
}