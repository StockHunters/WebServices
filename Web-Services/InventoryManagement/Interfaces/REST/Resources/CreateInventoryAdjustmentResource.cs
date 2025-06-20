namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record CreateInventoryAdjustmentResource(
    int ProductId,
    int LocationId,
    int Quantity,
    string Reason,
    int UserId,
    DateTime AdjustmentDate)
{
    public CreateInventoryAdjustmentResource(): this(0, 0, 0, string.Empty, 0, DateTime.Now) { }
    
}