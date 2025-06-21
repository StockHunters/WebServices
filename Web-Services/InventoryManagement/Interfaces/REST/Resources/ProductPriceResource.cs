namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record ProductPriceResource(int id, int productId, decimal price, decimal discount, DateTime effectiveDate);
