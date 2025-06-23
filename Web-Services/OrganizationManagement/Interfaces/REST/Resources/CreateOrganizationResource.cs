namespace Web_Services.OrganizationManagement.Interfaces.REST.Resources;

public record CreateOrganizationResource(string Name, string ContactEmail, int PlanId);