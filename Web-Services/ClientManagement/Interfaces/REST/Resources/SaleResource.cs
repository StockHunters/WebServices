namespace Web_Services.ClientManagement.Interfaces.REST.Resources;

public record SaleResource(int Id, DateTime Date, int Quantity, bool Status, int ProductId, int ClientId, int UserId, int LocationId);