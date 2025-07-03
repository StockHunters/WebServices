using Web_Services.IAM.Domain.Model.Commands;
using Web_Services.IAM.Interfaces.REST.Resources;

namespace Web_Services.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}