namespace Web_Services.SystemManagement.Interfaces.REST.Resources;

public record UserAccountResource(int Id, int OrganizationId, int UserId, string Email,string FirstName, string LastName, string ProfileImageUrl);