using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.ClientManagement.Infrastructure.Repositories;

public class SaleRepository(AppDbContext context): BaseRepository<Sale>(context), ISaleRepository
{
   
}