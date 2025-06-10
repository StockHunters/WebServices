using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.Shared.Domain.Model.Aggregate;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class Product: Asset
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    protected Product()
    {
        Name = string.Empty;
        ImageUrl = string.Empty;
        Stock = 0;
        CategoryId = 0;
        
    }

    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        ImageUrl = command.ImageUrl;
        Stock = command.Stock;
        CategoryId = command.CategoryId;
    }
    
    
}