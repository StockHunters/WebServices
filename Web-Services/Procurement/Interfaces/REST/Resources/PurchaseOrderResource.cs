namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record PurchaseOrderResource( 
    int id,
    int supplier_id,
    int user_id,
    int location_id,
    DateTime order_date,
    string status,
    DateTime created_at,
    DateTime updated_at);