using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Interfaces.REST.Resources;

namespace Web_Services.ClientManagement.Interfaces.REST.Transform;

public class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource) =>
        new CreateClientCommand(resource.FirstName, resource.LastName, resource.Phone, resource.Email, DateTime.Now,
            resource.Dni, true, resource.Company);
}