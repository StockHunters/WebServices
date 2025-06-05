using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Interfaces.REST.Resources;

namespace Web_Services.ClientManagement.Interfaces.REST.Transform;

public class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity) =>
    new ClientResource(entity.Id, entity.FirstName, entity.LastName, entity.Phone, entity.Email, entity.RegistrationDate,entity.Dni, entity.Status, entity.Company );
}