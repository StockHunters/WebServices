﻿namespace Web_Services.SystemManagement.Interfaces.REST.Resources;

public record UserResource(int Id, int OrganizationId, string Username, string Email, string PasswordHash,string FirstName, string LastName, string ProfileImageUrl);