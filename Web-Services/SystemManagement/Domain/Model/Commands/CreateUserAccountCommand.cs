namespace Web_Services.SystemManagement.Domain.Model.Commands;

public record CreateUserAccountCommand(int OrganizationId, int UserId, string Email, string FirstName, string LastName, string ProfileImageUrl);