namespace Web_Services.ClientManagement.Domain.Model.Commands;

public record CreateClientCommand(
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    DateTime RegistrationDate,
    string Dni,
    bool Status,
    string Company);
