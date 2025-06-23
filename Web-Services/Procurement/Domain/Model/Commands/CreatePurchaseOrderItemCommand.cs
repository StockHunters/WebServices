namespace Web_Services.Procurement.Domain.Model.Commands;

public record CreatePurchaseOrderItemCommand(
    int order_id,
    int product_id,
    int quantity,
    decimal unit_price,
    DateTime created_at);