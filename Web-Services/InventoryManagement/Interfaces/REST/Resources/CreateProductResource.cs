namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record CreateProductResource(string Name, string ImageUrl, int Stock, int CategoryId);