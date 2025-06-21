namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record LocationResource(int Id, int OrganizationId, string Name, string Address, string City, string Country);
