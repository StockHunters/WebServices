namespace Web_Services.Procurement.Domain.Model.Commands;

public record CreateProductSupplierCommand(
    int product_id,
    int supplier_id,
    decimal supplier_price,
    DateTime created_at);