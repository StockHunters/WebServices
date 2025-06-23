using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Queries;

namespace Web_Services.OrganizationManagement.Domain.Services;

public interface IOrganizationQueryService
{
    Task<IEnumerable<Organization>> Handle(GetAllOrganizationsQuery query);
    Task<Organization?> Handle(GetOrganizationByIdQuery query);
}