using Microsoft.AspNetCore.Mvc;
using Web_Services.Reporting.Application.Internal.CommandServices;
using Web_Services.Reporting.Application.Internal.QueryServices;
using Web_Services.Reporting.Domain.Model.Queries;
using Web_Services.Reporting.Interfaces.REST.Resources;
using Web_Services.Reporting.Interfaces.REST.Transform;

namespace Web_Services.Reporting.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportCommandService _commandService;
    private readonly ReportQueryService _queryService;

    public ReportController(ReportCommandService commandService, ReportQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource)
    {
        var command = ReportTransform.ToCommand(resource);
        await _commandService.CreateReportAsync(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReportById(string id)
    {
        var query = new GetReportByIdQuery { Id = id };
        var report = await _queryService.GetReportByIdAsync(query);
        if (report == null) return NotFound();
        var resource = ReportTransform.ToResource(report);
        return Ok(resource);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetReportsByUserId(string userId)
    {
        var query = new GetReportsByUserIdQuery { UserId = userId };
        var reports = await _queryService.GetReportsByUserIdAsync(query);
        var resources = reports.Select(ReportTransform.ToResource);
        return Ok(resources);
    }
}