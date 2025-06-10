namespace Web_Services.ProductManagement.Interfaces.REST.Resources;

public record CreateProductResource(string Name, string ImageUrl, int Stock, int CategoryId);