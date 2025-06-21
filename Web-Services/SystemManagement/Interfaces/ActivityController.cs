using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Interfaces.REST.Resources;
using Web_Services.SystemManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Web_Services.SystemManagement.Domain.Services;

namespace Web_Services.SystemManagement.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ActivityCommandService _commandService;
    private readonly ActivityQueryService _queryService;

    public ActivityController(ActivityCommandService commandService, ActivityQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] CreateActivityResource resource)
    {
        var command = ActivityTransform.ToCommand(resource);
        await _commandService.CreateActivityAsync(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivityById(string id)
    {
        var query = new GetActivityByIdQuery { Id = id };
        var activity = await _queryService.GetActivityByIdAsync(query);
        if (activity == null) return NotFound();
        var resource = ActivityTransform.ToResource(activity);
        return Ok(resource);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetActivitiesByUserId(string userId)
    {
        var query = new GetActivitiesByUserIdQuery { UserId = userId };
        var activities = await _queryService.GetActivitiesByUserIdAsync(query);
        var resources = activities.Select(ActivityTransform.ToResource);
        return Ok(resources);
    }
}