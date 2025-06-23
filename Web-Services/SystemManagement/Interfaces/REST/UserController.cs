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
public class UserController(IUserCommandService userCommandService, IUserQueryService userQueryService):ControllerBase
{
    [HttpGet("{userId:int}")]
    [SwaggerOperation("Get User by Id", "Get a user by its unique identifier.", OperationId = "GetUserById")]
    [SwaggerResponse(200, "The user was found and returned.", typeof(UserResource))]
    [SwaggerResponse(404, "The user was not found.")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpPost]
    [SwaggerOperation("Create User", "Create a new user.", OperationId = "CreateUser")]
    [SwaggerResponse(201, "The user was created.", typeof(UserResource))]
    [SwaggerResponse(400, "The user was not created.")]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, userResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Users", "Get all users.", OperationId = "GetAllUsers")]
    [SwaggerResponse(200, "The users were found and returned.", typeof(IEnumerable<UserResource>))]
    [SwaggerResponse(404, "The users were not found.")]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}