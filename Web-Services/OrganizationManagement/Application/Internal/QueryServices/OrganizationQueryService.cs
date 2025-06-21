using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Queries;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.OrganizationManagement.Domain.Services;

namespace Web_Services.OrganizationManagement.Application.Internal.QueryServices;

public class OrganizationQueryService(IOrganizationRepository organizationRepository):IOrganizationQueryService
{
    public async Task<IEnumerable<Organization>> Handle(GetAllOrganizationsQuery query)
    {
        return await organizationRepository.ListAsync();
    }
    
    public async Task<Organization?> Handle(GetOrganizationByIdQuery query)
    {
        return await organizationRepository.FindByIdAsync(query.Id);
    }
}