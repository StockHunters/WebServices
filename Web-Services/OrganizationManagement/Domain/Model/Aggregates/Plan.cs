using Web_Services.OrganizationManagement.Domain.Model.Commands;
using Web_Services.OrganizationManagement.Domain.Model.ValueObjects;

namespace Web_Services.OrganizationManagement.Domain.Model.Aggregates;

public partial class Plan
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PlanFeatures Feature { get; set; }
    public decimal Price { get; set; }
    
    public Plan()
    {
        Name = string.Empty;
        Description = string.Empty;
        Feature = PlanFeatures.Feature1;
        Price = 0;
    }

    public Plan(CreatePlanCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Feature = (PlanFeatures)command.Feature;
        Price = command.Price;
    }
    
    
}