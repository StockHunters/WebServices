using Microsoft.AspNetCore.Mvc;
using Web_Services.SystemManagement.Application.Internal.CommandServices;
using Web_Services.SystemManagement.Application.Internal.QueryServices;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Interfaces.REST.Resources;
using Web_Services.SystemManagement.Interfaces.REST.Transform;

namespace Web_Services.SystemManagement.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AuditLogController : ControllerBase
{
    private readonly AuditLogCommandService _commandService;
    private readonly AuditLogQueryService _queryService;

    public AuditLogController(AuditLogCommandService commandService, AuditLogQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuditLog([FromBody] CreateAuditLogResource resource)
    {
        var command = AuditLogTransform.ToCommand(resource);
        await _commandService.CreateAuditLogAsync(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuditLogById(string id)
    {
        var query = new GetAuditLogByIdQuery { Id = id };
        var auditLog = await _queryService.GetAuditLogByIdAsync(query);
        if (auditLog == null) return NotFound();
        var resource = AuditLogTransform.ToResource(auditLog);
        return Ok(resource);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAuditLogsByUserId(string userId)
    {
        var query = new GetAuditLogsByUserIdQuery { UserId = userId };
        var auditLogs = await _queryService.GetAuditLogsByUserIdAsync(query);
        var resources = auditLogs.Select(AuditLogTransform.ToResource);
        return Ok(resources);
    }
}