using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Domain.Services;
using Web_Services.SystemManagement.Interfaces.REST.Resources;
using Web_Services.SystemManagement.Interfaces.REST.Transform;

namespace Web_Services.SystemManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Users Endpoints.")]
public class UserAccountController(IUserAccountCommandService userAccountCommandService, IUserAccountQueryService userAccountQueryService):ControllerBase
{
    [HttpGet("{userId:int}")]
    [SwaggerOperation("Get UserAccount by Id", "Get a user by its unique identifier.", OperationId = "GetUserById")]
    [SwaggerResponse(200, "The user was found and returned.", typeof(UserAccountResource))]
    [SwaggerResponse(404, "The user was not found.")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserAccountByIdQuery(userId);
        var user = await userAccountQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpPost]
    [SwaggerOperation("Create UserAccount", "Create a new user.", OperationId = "CreateUser")]
    [SwaggerResponse(201, "The user was created.", typeof(UserAccountResource))]
    [SwaggerResponse(400, "The user was not created.")]
    public async Task<IActionResult> CreateUser(CreateUserAccountResource accountResource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(accountResource);
        var user = await userAccountCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, userResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Users", "Get all users.", OperationId = "GetAllUsers")]
    [SwaggerResponse(200, "The users were found and returned.", typeof(IEnumerable<UserAccountResource>))]
    [SwaggerResponse(404, "The users were not found.")]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersAccountsQuery();
        var users = await userAccountQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}