namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record CreatePurchaseOrderResource( 
    int supplier_id,
    int user_id,
    int location_id,
    DateTime order_date,
    string status,
    DateTime created_at,
    DateTime updated_at);