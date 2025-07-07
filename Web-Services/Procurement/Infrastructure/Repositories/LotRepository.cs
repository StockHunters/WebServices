using Microsoft.EntityFrameworkCore;
using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.Procurement.Infrastructure.Repositories;

public class LotRepository(AppDbContext context): BaseRepository<lots>(context), ILotRepository
{
    public async Task<IEnumerable<lots>> FindByLotIdAsync(int lotId)
    {
        return await Context.Set<lots>().Where(f => f.id == lotId).ToListAsync();
    }
}