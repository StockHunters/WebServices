namespace Web_Services.SystemManagement.Interfaces.REST.Resources;

public record CreateUserAccountResource(int OrganizationId, int UserId, string Email, string FirstName, string LastName, string ProfileImageUrl);