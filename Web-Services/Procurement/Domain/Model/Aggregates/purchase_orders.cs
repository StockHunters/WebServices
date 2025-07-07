using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Model.Aggregates;

public class purchase_orders
{
    public int id { get; }
    public int supplier_id { get; set; }
    public int user_id { get; set; }
    public int location_id { get; set; }
    public DateTime order_date { get; set; }
    public string status { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    protected purchase_orders()
    {
        supplier_id = 0;
        user_id = 0;
        location_id = 0;
        order_date = DateTime.Now;
        status = string.Empty;
        created_at = DateTime.Now;
        updated_at = DateTime.Now;
    }

    public purchase_orders(CreatePurchaseOrderCommand command)
    {
        supplier_id = command.supplier_id;
        user_id = command.user_id;
        location_id = command.location_id;
        order_date = command.order_date;
        status = command.status;
        created_at = command.created_at;
        updated_at = command.updated_at;
    }
}