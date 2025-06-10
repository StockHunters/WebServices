namespace Web_Services.InventoryManagement.Domain.Model.Commands;

public record CreateProductCommand(string Name, string ImageUrl, int Stock, int CategoryId);