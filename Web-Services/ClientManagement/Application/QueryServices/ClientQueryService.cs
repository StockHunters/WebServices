using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Queries;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;

namespace Web_Services.ClientManagement.Application.QueryServices;

public class ClientQueryService(IClientRepository clientRepository): IClientQueryService
{
    public async Task<Client?> Handle(GetClientByDniQuery query)
    {
        return await clientRepository.FindByDniAsync(query.Dni);
    }

    public async Task<Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.Id);
    }
}