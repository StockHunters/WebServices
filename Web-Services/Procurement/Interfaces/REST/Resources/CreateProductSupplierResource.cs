namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record CreateProductSupplierResource(int product_id, int supplier_id, decimal supply_price, DateTime created_at);