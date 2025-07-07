using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Model.Aggregates;

public class lots
{
    public int id { get; }
    public int product_id { get; set; }
    public int purchase_id { get; set; }
    public int lot_number { get; set; }
    public DateOnly purchase_date { get; set; }
    public DateOnly expiration_date { get; set; }
    public DateTime created_at { get; set; }
    
    protected lots()
    {
        product_id = 0;
        purchase_id = 0;
        lot_number = 0;
        purchase_date = DateOnly.FromDateTime(DateTime.Now);
        expiration_date = DateOnly.FromDateTime(DateTime.Now);
        created_at = DateTime.Now;
    }

    public lots(CreateLotCommand command)
    {
        product_id = command.product_id;
        purchase_id = command.purchase_id;
        lot_number = command.lot_number;
        purchase_date = command.purchase_date;
        expiration_date = command.expiration_date;
        created_at = command.created_at;
    }
}