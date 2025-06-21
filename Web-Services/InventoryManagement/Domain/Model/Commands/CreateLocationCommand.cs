namespace Web_Services.InventoryManagement.Domain.Model.Commands;

public record CreateLocationCommand(int OrganizationId, string Name, string Address, string City, string Country);