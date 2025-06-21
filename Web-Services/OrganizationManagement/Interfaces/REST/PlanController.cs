using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.OrganizationManagement.Domain.Model.Queries;
using Web_Services.OrganizationManagement.Domain.Services;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;
using Web_Services.OrganizationManagement.Interfaces.REST.Transform;

namespace Web_Services.OrganizationManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Plan Endpoints.")]
public class PlanController(IPlanCommandService planCommandService, IPlanQueryService planQueryService):ControllerBase
{
    [HttpGet("{planId:int}")]
    [SwaggerOperation("Get Plan by Id", "Get a plan by its unique identifier.", OperationId = "GetPlanById")]
    [SwaggerResponse(200, "The plan was found and returned.", typeof(PlanResource))]
    [SwaggerResponse(404, "The plan was not found.")]
    public async Task<IActionResult> GetPlanById(int planId)
    {
        var getPlanByIdQuery = new GetPlanByIdQuery(planId);
        var plan = await planQueryService.Handle(getPlanByIdQuery);
        if (plan is null) return NotFound();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(planResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Plan", "Create a new plan.", OperationId = "CreatePlan")]
    [SwaggerResponse(201, "The plan was created.", typeof(PlanResource))]
    [SwaggerResponse(400, "The plan was not created.")]
    public async Task<IActionResult> CreatePlan(CreatePlanResource resource)
    {
        var createPlanCommand = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var plan = await planCommandService.Handle(createPlanCommand);
        if (plan is null) return BadRequest();
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return CreatedAtAction(nameof(GetPlanById), new { planId = plan.Id }, planResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Plans", "Get all plans.", OperationId = "GetAllPlans")]
    [SwaggerResponse(200, "The plans were found and returned.", typeof(IEnumerable<PlanResource>))]
    [SwaggerResponse(404, "The plans were not found.")]
    public async Task<IActionResult> GetAllPlans()
    {
        var getAllPlansQuery = new GetAllPlansQuery();
        var plans = await planQueryService.Handle(getAllPlansQuery);
        var planResources = plans.Select(PlanResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(planResources);
    }
}