using Web_Services.InventoryManagement.Domain.Model.Commands;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class ProductLocation
{
    public int Id { get; }
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int Stock { get; set; }
    
    public Product Product { get; set; }
    public Location Location { get; set; }
    
    public ProductLocation()
    {
        ProductId = 0;
        LocationId = 0;
        Stock = 0;
    }

    public ProductLocation(CreateProductLocationCommand command)
    {
        this.ProductId = command.ProductId;
        this.LocationId = command.LocationId;
        this.Stock = command.Quantity;
    }
}