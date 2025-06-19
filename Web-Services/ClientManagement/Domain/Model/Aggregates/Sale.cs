using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Domain.Model.ValueObjects;

namespace Web_Services.ClientManagement.Domain.Model.Aggregates;

public partial class Sale
{
    public int Id { get; }
    public SaleDate Date { get; private set; }
    public SaleQuantity Quantity { get; private set; }
    public SaleStatus Status { get; private set; }
    public int ProductId { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public int LocationId { get; set; }

    public Sale()
    {
        Date = new SaleDate();
        Quantity = new SaleQuantity();
        Status = new SaleStatus();
        ProductId = 0;
        ClientId = 0;
        UserId = 0;
        LocationId = 0;
    }

    public Sale(CreateSaleCommand command)
    {
        Date = new SaleDate(command.Date);
        Quantity = new SaleQuantity(command.Quantity);
        Status = new SaleStatus(command.Status);
        ProductId = command.ProductId;
        ClientId = command.ClientId;
        UserId = command.UserId;
        LocationId = command.LocationId;
    }
    
    
}