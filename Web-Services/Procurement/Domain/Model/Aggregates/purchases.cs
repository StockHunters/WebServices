using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Model.Aggregates;

public class purchases
{
    public int id { get; }
    public int supplier_id { get; set; }
    public int product_id { get; set; }
    public int order_id { get; set; }
    public int quantity { get; set; }
    public DateTime purchase_date { get; set; }
    public string status { get; set; }
    public int user_id { get; set; }
    public int location_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    protected purchases()
    {
        supplier_id = 0;
        product_id = 0;
        order_id = 0;
        quantity = 0;
        purchase_date = DateTime.Now;
        status = string.Empty;
        user_id = 0;
        location_id = 0;
        created_at = DateTime.Now;
        updated_at = DateTime.Now;
    }

    public purchases(CreatePurchaseCommand command)
    {
        supplier_id = command.supplier_id;
        product_id = command.product_id;
        order_id = command.order_id;
        quantity = command.quantity;
        purchase_date = command.purchase_date;
        status = command.status;
        user_id = command.user_id;
        location_id = command.location_id;
        created_at = command.created_at;
        updated_at = command.updated_at;
    }
}