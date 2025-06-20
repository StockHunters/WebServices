namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record InventoryAdjustmentResource(int Id, int ProductId, int LocationId, int Quantity, string Reason, int UserId, DateTime AdjustmentDate);