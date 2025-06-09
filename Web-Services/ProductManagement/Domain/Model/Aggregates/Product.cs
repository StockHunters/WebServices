using Web_Services.ProductManagement.Domain.Model.Commands;

namespace Web_Services.ProductManagement.Domain.Model.Aggregates;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    protected Product()
    {
        Name = string.Empty;
        ImageUrl = string.Empty;
        Stock = 0;
        CategoryId = 0;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        ImageUrl = command.ImageUrl;
        Stock = command.Stock;
        CategoryId = command.CategoryId;
        CreatedAt = DateTime.Now;
    }
    
    
}