using Web_Services.OrganizationManagement.Domain.Model.ValueObjects;

namespace Web_Services.OrganizationManagement.Domain.Model.Commands;

public record CreatePlanCommand(string Name, string Description, int Feature, decimal Price);