using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;

namespace Web_Services.OrganizationManagement.Interfaces.REST.Transform;

public static class OrganizationResourceFromEntityAssembler
{
    public static OrganizationResource ToResourceFromEntity(Organization entity)
    {
        return new OrganizationResource(entity.Id, entity.Name, entity.ContactEmail, entity.PlanId);
    }
}