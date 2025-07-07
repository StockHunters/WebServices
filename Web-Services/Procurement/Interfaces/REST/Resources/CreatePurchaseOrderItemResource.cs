namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record CreatePurchaseOrderItemResource(
    int order_id,
    int product_id,
    int quantity,
    decimal unit_price,
    DateTime created_at);