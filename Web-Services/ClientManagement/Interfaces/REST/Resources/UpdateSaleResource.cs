namespace Web_Services.ClientManagement.Interfaces.REST.Resources;

public record UpdateSaleResource(int Id, DateTime Date, int Quantity, bool Status);