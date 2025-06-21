namespace Web_Services.OrganizationManagement.Domain.Model.Commands;

public record CreateOrganizationCommand(string Name, string ContactEmail, int PlanId);