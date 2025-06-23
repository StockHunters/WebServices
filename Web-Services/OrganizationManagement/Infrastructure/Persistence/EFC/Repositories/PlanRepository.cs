using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.OrganizationManagement.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context): BaseRepository<Plan>(context), IPlanRepository
{
    
}