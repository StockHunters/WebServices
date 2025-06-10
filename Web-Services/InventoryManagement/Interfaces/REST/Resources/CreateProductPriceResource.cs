namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record CreateProductPriceResource(int ProductId, decimal Price, decimal Discount, DateTime EffectiveDate);