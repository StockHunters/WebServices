using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Commands;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.OrganizationManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.OrganizationManagement.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork): IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(command);
        try
        {
            await planRepository.AddAsync(plan);
            await unitOfWork.CompleteAsync();
            return plan;
        } catch (Exception e)
        {
            return null;
        }
    }
}