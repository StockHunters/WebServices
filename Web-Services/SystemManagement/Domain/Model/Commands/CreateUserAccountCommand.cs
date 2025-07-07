namespace Web_Services.SystemManagement.Domain.Model.Commands;

public record CreateUserAccountCommand(int OrganizationId, string Username, string Email, string PasswordHash, string FirstName, string LastName, string ProfileImageUrl);