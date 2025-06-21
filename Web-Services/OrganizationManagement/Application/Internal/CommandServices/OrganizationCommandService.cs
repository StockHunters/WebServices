using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Commands;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.OrganizationManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.OrganizationManagement.Application.Internal.CommandServices;

public class OrganizationCommandService(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork):IOrganizationCommandService
{
    public async Task<Organization?> Handle(CreateOrganizationCommand command)
    {
        var organization = new Organization(command);
        try
        {
            await organizationRepository.AddAsync(organization);
            await unitOfWork.CompleteAsync();
            return organization;
        } catch (Exception e)
        {
            return null;
        }
    }
}