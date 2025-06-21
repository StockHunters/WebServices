namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, string ImageUrl, int Stock, int CategoryId);