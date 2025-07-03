using Web_Services.IAM.Domain.Model.Commands;
using Web_Services.IAM.Interfaces.REST.Resources;

namespace Web_Services.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}