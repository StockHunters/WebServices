using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Commands;

namespace Web_Services.ClientManagement.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand command);
}