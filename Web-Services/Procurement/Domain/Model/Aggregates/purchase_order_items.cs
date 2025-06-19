using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Model.Aggregates;

public class purchase_order_items
{
    public int id { get; }
    public int order_id { get; set; }
    public int product_id { get; set; }
    public int quantity { get; set; }
    public decimal unit_price { get; set; }
    public DateTime created_at { get; set; }
    
    protected purchase_order_items()
    {
        order_id = 0;
        product_id = 0;
        quantity = 0;
        unit_price = 0;
        created_at = DateTime.Now;
    }

    public purchase_order_items(CreatePurchaseOrderItemCommand command)
    {
        order_id = command.order_id;
        product_id = command.product_id;
        quantity = command.quantity;
        unit_price = command.unit_price;
        created_at = command.created_at;
    }
}