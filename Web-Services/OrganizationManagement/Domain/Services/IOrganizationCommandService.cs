using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Commands;

namespace Web_Services.OrganizationManagement.Domain.Services;

public interface IOrganizationCommandService
{
    Task<Organization?> Handle(CreateOrganizationCommand command);
}