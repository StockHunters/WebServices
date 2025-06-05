using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.ClientManagement.Application.CommandServices;

public class ClientCommandService(IClientRepository clientRepository, IUnitOfWork unitOfWork): IClientCommandService
{
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var client = await clientRepository.FindByDniAsync(command.Dni);
        if (client != null)
            throw new Exception("El DNI de cliente ya existe");
        client = new Client(command);
        try
        {
            await clientRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        
        return client;
    }
}