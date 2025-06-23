namespace Web_Services.InventoryManagement.Domain.Model.ValueObjects;

public record ProductAddress(string Address, string City, string Country)
{
    public ProductAddress() : this("", "", ""){}
}