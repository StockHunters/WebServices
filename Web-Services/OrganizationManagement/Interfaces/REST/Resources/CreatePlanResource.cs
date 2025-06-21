namespace Web_Services.OrganizationManagement.Interfaces.REST.Resources;

public record CreatePlanResource(string Name, string Description, int Feature, decimal Price);