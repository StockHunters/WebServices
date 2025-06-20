namespace Web_Services.InventoryManagement.Domain.Model.Commands;

public record CreateProductLocationCommand(int ProductId, int LocationId, int Quantity);