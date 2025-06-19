namespace Web_Services.ClientManagement.Domain.Model.Commands;

public record CreateSaleCommand(DateTime Date, int Quantity, bool Status, int ProductId, int ClientId, int UserId, int LocationId );