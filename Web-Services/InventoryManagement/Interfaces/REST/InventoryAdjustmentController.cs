using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;
using Web_Services.InventoryManagement.Interfaces.REST.Transform;

namespace Web_Services.InventoryManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Inventory Adjustments Endpoints.")]
public class InventoryAdjustmentController(IInventoryAdjustmentCommandService inventoryAdjustmentCommandService, IInventoryAdjustmentQueryService inventoryAdjustmentQueryService): ControllerBase
{
    [HttpGet("{inventoryAdjustmentId:int}")]
    [SwaggerOperation("Get InventoryAdjustment by Id", "Get a inventoryAdjustment by its unique identifier.", OperationId = "GetInventoryAdjustmentById")]
    [SwaggerResponse(200, "The inventoryAdjustment was found and returned.", typeof(InventoryAdjustmentResource))]
    [SwaggerResponse(404, "The inventoryAdjustment was not found.")]
    public async Task<IActionResult> GetInventoryAdjustmentById(int inventoryAdjustmentId)
    {
        var getInventoryAdjustmentByIdQuery = new GetInventoryAdjustmentByIdQuery(inventoryAdjustmentId);
        var inventoryAdjustment = await inventoryAdjustmentQueryService.Handle(getInventoryAdjustmentByIdQuery);
        if (inventoryAdjustment is null) return NotFound();
        var inventoryAdjustmentResource = InventoryAdjustmentResourceFromEntityAssembler.ToResourceFromEntity(inventoryAdjustment);
        return Ok(inventoryAdjustmentResource);
    }

    [HttpPost]
    [SwaggerOperation("Create InventoryAdjustment", "Create a new inventoryAdjustment.", OperationId = "CreateInventoryAdjustment")]
    [SwaggerResponse(201, "The inventoryAdjustment was created.", typeof(InventoryAdjustmentResource))]
    [SwaggerResponse(400, "The inventoryAdjustment was not created.")]
    public async Task<IActionResult> CreateInventoryAdjustment(CreateInventoryAdjustmentResource resource)
    {
        var createInventoryAdjustmentCommand = CreateInventoryAdjustmentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var inventoryAdjustment = await inventoryAdjustmentCommandService.Handle(createInventoryAdjustmentCommand);
        if (inventoryAdjustment is null) return BadRequest();
        var inventoryAdjustmentResource = InventoryAdjustmentResourceFromEntityAssembler.ToResourceFromEntity(inventoryAdjustment);
        return CreatedAtAction(nameof(GetInventoryAdjustmentById), new { inventoryAdjustmentId = inventoryAdjustment.Id }, inventoryAdjustmentResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All InventoryAdjustments", "Get all inventoryAdjustments.", OperationId = "GetAllInventoryAdjustments")]
    [SwaggerResponse(200, "The inventoryAdjustments were found and returned.", typeof(IEnumerable<InventoryAdjustmentResource>))]
    [SwaggerResponse(404, "The inventoryAdjustments were not found.")]
    public async Task<IActionResult> GetAllInventoryAdjustments()
    {
        var getAllInventoryAdjustmentsQuery = new GetAllInventoryAdjustmentsQuery();
        var inventoryAdjustments = await inventoryAdjustmentQueryService.Handle(getAllInventoryAdjustmentsQuery);
        var inventoryAdjustmentResources = inventoryAdjustments.Select(InventoryAdjustmentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(inventoryAdjustmentResources);
    }
}