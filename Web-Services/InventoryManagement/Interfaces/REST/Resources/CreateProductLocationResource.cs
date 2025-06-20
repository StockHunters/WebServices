namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record CreateProductLocationResource(int ProductId, int LocationId, int Stock);