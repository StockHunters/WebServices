namespace Web_Services.InventoryManagement.Interfaces.REST.Resources;

public record CreateLocationResource(int OrganizationId, string name, string address, string city, string country);