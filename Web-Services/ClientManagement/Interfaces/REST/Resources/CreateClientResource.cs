namespace Web_Services.ClientManagement.Interfaces.REST.Resources;

public record CreateClientResource(string FirstName, string LastName, string Phone, string Email, string Dni, string Company);