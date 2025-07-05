namespace Web_Services.ClientManagement.Domain.Model.Commands;

public record UpdateSaleCommand(int Id, DateTime Date, int Quantity, bool Status);