using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.Shared.Domain.Model.Aggregate;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public class ProductPrice: Asset
{
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public DateTime EffectiveDate { get; set; }
    
    public Product Product { get; set; }

    protected ProductPrice()
    {
        ProductId = 0;
        Price = 0;
        Discount = 0;
        EffectiveDate = DateTime.Now;
    }

    public ProductPrice(CreateProductPriceCommand command)
    {
        ProductId = command.ProductId;
        Price = command.Price;
        Discount = command.Discount;
        EffectiveDate = command.EffectiveDate;
    }
}