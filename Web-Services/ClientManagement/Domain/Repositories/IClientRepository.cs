

using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.ClientManagement.Domain.Repositories;

public interface IClientRepository: IBaseRepository<Client>
{
    Task<Client?> FindByDniAsync(string dni);
}