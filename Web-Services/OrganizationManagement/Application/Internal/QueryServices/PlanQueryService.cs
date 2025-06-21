using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Queries;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.OrganizationManagement.Domain.Services;

namespace Web_Services.OrganizationManagement.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository planRepository): IPlanQueryService
{
    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await planRepository.ListAsync();
    }
    
    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await planRepository.FindByIdAsync(query.Id);
    }
}