namespace Web_Services.ProductManagement.Domain.Model.Commands;

public record CreateProductCommand(string Name, string ImageUrl, int Stock, int CategoryId);