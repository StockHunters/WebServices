using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Model.ValueObjects;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class Location
{
    public int Id { get; }
    
    public int OrganizationId { get; set; }
    public string Name { get; set; }
    public ProductAddress Address { get; set; }
    
    public Location()
    {
        OrganizationId = 0;
        Name = string.Empty;
        Address = new ProductAddress();
    }

    public Location(CreateLocationCommand command)
    {
        Name = command.Name;
        OrganizationId = command.OrganizationId;
        Address = new ProductAddress(command.Address, command.City, command.Country);
    }
}