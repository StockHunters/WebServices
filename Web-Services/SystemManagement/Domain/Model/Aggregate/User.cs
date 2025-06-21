using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Model.ValueObject;

namespace Web_Services.SystemManagement.Domain.Model.Aggregate;

public partial class User
{
    public int Id { get; }
    public int OrganizationId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfileImageUrl { get; set; }
    public UserRole Role { get; set; }
    
    public Organization Organization { get; set; }

    public User()
    {
        OrganizationId = 0;
        Username = string.Empty;
        Email = string.Empty;
        PasswordHash = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        ProfileImageUrl = string.Empty;
        Role = UserRole.Admin;
    }

    public User(CreateUserCommand command)
    {
        OrganizationId = command.OrganizationId;
        Username=command.Username;
        Email = command.Email;
        PasswordHash = command.PasswordHash;
        FirstName = command.FirstName;
        LastName = command.LastName;
        ProfileImageUrl = command.ProfileImageUrl;
        Role = UserRole.Admin;
    }
}