namespace Web_Services.InventoryManagement.Domain.Model.Commands;

public record CreateInventoryAdjustmentCommand(
    int ProductId,
    int LocationId,
    int Quantity,
    string Reason,
    int UserId,
    DateTime AdjustmentDate);
