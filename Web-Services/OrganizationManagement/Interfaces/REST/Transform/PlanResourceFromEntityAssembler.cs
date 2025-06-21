using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;

namespace Web_Services.OrganizationManagement.Interfaces.REST.Transform;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(entity.Id, entity.Name, entity.Description, entity.Feature.ToString(), entity.Price);
    }
}