namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record ProductLocationResource(int Id, int ProductId, int LocationId, int Stock);