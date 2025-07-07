namespace Web_Services.Procurement.Interfaces.REST.Resources;

public record LotResource(
    int id,
    int product_id,
    int purchase_id,
    int lot_number,
    DateOnly purchase_date,
    DateOnly expiration_date,
    DateTime created_at);