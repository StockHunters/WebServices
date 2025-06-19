namespace Web_Services.Procurement.Domain.Model.Commands;

public record CreateLotCommand(
    int product_id,
    int purchase_id,
    int lot_number,
    DateOnly purchase_date,
    DateOnly expiration_date,
    DateTime created_at);