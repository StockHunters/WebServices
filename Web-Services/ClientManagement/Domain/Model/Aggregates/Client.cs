using Web_Services.ClientManagement.Domain.Model.Commands;

namespace Web_Services.ClientManagement.Domain.Model.Aggregates;

public class Client
{
    public int Id { get; }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public string Dni { get; private set; }
    public bool Status { get; private set; }
    public string Company  { get; private set; }
    
    
    protected Client()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Phone = string.Empty;
        Email = string.Empty;
        Dni = string.Empty;
        RegistrationDate = DateTime.Now;
        Company = string.Empty;
        Status = false;
    }

    public Client(CreateClientCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Phone = command.Phone;
        Email = command.Email;
        Dni = command.Dni;
        RegistrationDate = command.RegistrationDate;
        Company = command.Company;
        Status = command.Status;
    }
}