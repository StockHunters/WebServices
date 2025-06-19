using Web_Services.Procurement.Domain.Model.Commands;

namespace Web_Services.Procurement.Domain.Model.Aggregates;

public class product_suppliers
{
    public int id { get; }
    public int product_id { get; }
    public int supplier_id { get; set; }
    public decimal supply_price { get; set; }
    public DateTime created_at { get; set; }
    
    protected product_suppliers()
    {
        product_id = 0;
        supplier_id = 0;
        supply_price = 0;
        created_at = DateTime.Now;
    }

    public product_suppliers(CreateProductSupplierCommand command)
    {
        product_id = command.product_id;
        supplier_id = command.supplier_id;
        supply_price = command.supplier_price;
        created_at = command.created_at;
    }
}