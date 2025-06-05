using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.ClientManagement.Infrastructure.Repositories;

public class ClientRepository(AppDbContext context): BaseRepository<Client>(context), IClientRepository
{
    public async Task<Client?> FindByDniAsync(string dni)
    {
        return await Context.Set<Client>().FirstOrDefaultAsync(f => f.Dni == dni);
    }
}