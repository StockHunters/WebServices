namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record PurchaseResource(   
    int id,
    int supplier_id,
    int product_id,
    int order_id,
    int quantity,
    DateTime purchase_date,
    string status,
    int user_id,
    int location_id,
    DateTime created_at,
    DateTime updated_at);