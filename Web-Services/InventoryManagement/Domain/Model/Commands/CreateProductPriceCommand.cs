namespace Web_Services.InventoryManagement.Domain.Model.Commands;

public record CreateProductPriceCommand(int ProductId, decimal Price, decimal Discount, DateTime EffectiveDate);