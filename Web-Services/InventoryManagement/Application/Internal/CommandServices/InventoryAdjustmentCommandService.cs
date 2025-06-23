using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Application.Internal.CommandServices;

public class InventoryAdjustmentCommandService(IInventoryAdjustmentRepository inventoryAdjustmentRepository, IUnitOfWork unitOfWork):IInventoryAdjustmentCommandService
{
    public async Task<InventoryAdjustment?> Handle(CreateInventoryAdjustmentCommand command)
    {
        var inventoryAdjustment = new InventoryAdjustment(command);
        try
        {
            await inventoryAdjustmentRepository.AddAsync(inventoryAdjustment);
            await unitOfWork.CompleteAsync();
            return inventoryAdjustment;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}