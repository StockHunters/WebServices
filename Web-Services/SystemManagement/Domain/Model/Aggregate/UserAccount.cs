using Web_Services.IAM.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Model.ValueObject;

namespace Web_Services.SystemManagement.Domain.Model.Aggregate;

public partial class UserAccount
{
    public int Id { get; }
    public int OrganizationId { get; set; }
    
    public int UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfileImageUrl { get; set; }
    public UserRole Role { get; set; }
    
    public Organization Organization { get; set; }
    
    public User User { get; set; }

    public UserAccount()
    {
        OrganizationId = 0;
        UserId = 0;
        Email = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        ProfileImageUrl = string.Empty;
        Role = UserRole.Admin;
    }

    public UserAccount(CreateUserAccountCommand accountCommand)
    {
        OrganizationId = accountCommand.OrganizationId;
        UserId=accountCommand.UserId;
        Email = accountCommand.Email;
        FirstName = accountCommand.FirstName;
        LastName = accountCommand.LastName;
        ProfileImageUrl = accountCommand.ProfileImageUrl;
        Role = UserRole.Admin;
    }
}