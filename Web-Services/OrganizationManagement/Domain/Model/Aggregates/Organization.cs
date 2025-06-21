using Web_Services.OrganizationManagement.Domain.Model.Commands;

namespace Web_Services.OrganizationManagement.Domain.Model.Aggregates;

public partial class Organization
{
    public int Id { get; }
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public int PlanId { get; set; }
    
    public Plan Plan { get; set; }

    public Organization()
    {
        Name = string.Empty;
        ContactEmail = string.Empty;
        PlanId = 0;
    }

    public Organization(CreateOrganizationCommand command)
    {
        Name = command.Name;
        ContactEmail = command.ContactEmail;
        PlanId = command.PlanId;
    }
}