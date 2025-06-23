using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Queries;

namespace Web_Services.OrganizationManagement.Domain.Services;

public interface IPlanQueryService
{
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);
    
    Task<Plan?> Handle(GetPlanByIdQuery query);
}