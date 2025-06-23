namespace Web_Services.ClientManagement.Interfaces.REST.Resources;

public record ClientResource(int Id, string FirstName, string LastName, string Phone, string Email,DateTime RegistrationDate, string Dni,  bool Status, string Company);