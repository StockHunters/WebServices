using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Queries;

namespace Web_Services.ClientManagement.Domain.Services;

public interface IClientQueryService
{
    Task<Client?> Handle(GetClientByDniQuery query);
    
    Task<Client?> Handle(GetClientByIdQuery query);
}