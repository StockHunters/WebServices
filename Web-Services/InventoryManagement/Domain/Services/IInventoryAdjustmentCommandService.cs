using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface IInventoryAdjustmentCommandService
{
    Task<InventoryAdjustment?> Handle(CreateInventoryAdjustmentCommand command);
}