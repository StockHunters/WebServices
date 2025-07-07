using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_Services.IAM.Domain.Model.Aggregates;

namespace Web_Services.IAM.Infrastructure.Pipeline.Middleware.Attributes;

/**
 * This attribute is used to decorate controllers and actions that require authorization.
 * It checks if the user is logged in by checking if HttpContext.UserAccount is set.
 * If a user is not signed in, then it returns a 401-status code.
 */
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    /**
     * <summary>
     *     This method is called when authorization is required.
     *     It checks if the user is logged in by checking if HttpContext.UserAccount is set.
     *     If a user is not signed in then it returns 401-status code.
     * </summary>
     * <param name="context">The authorization filter context</param>
     */
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

        if (allowAnonymous)
        {
            Console.WriteLine(" Skipping authorization");
            return;
        }

        // verify if a user is signed in by checking if HttpContext.UserAccount is set
        var user = (User?)context.HttpContext.Items["UserAccount"];

        // if a user is not signed in, then return 401-status code
        if (user == null) context.Result = new UnauthorizedResult();
    }
}