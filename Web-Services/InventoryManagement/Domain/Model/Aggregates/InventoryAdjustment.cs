using Web_Services.InventoryManagement.Domain.Model.Commands;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class InventoryAdjustment
{
    public int Id { get; }
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
    public int UserId { get; set; }
    public DateTime AdjustmentDate { get; set; }

    public Product Product { get; set; }
    public Location Location { get; set; }

    public InventoryAdjustment()
    {
        ProductId = 0;
        LocationId = 0;
        Quantity = 0;
        Reason = string.Empty;
        UserId = 0;
        AdjustmentDate = DateTime.Now;
    }

    public InventoryAdjustment(CreateInventoryAdjustmentCommand command)
    {
        ProductId = command.ProductId;
        LocationId = command.LocationId;
        Quantity = command.Quantity;
        Reason = command.Reason;
        UserId = command.UserId;
        AdjustmentDate = command.AdjustmentDate;
    }
}