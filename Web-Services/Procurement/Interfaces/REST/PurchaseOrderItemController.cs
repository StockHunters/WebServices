using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Procurement.Interfaces.REST.Resources;
using Web_Services.Procurement.Interfaces.REST.Transform;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Purchase Order Items")]
public class PurchaseOrderItemController(IPurchaseOrderItemCommandService purchaseOrderItemCommandService, IPurchaseOrderItemQueryService purchaseOrderItemQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a purchase order item",
        Description = "Creates a purchase order item",
        OperationId = "CreatePurchaseOrderItem")]
    [SwaggerResponse(201, "The purchase order items were created", typeof(PurchaseOrderItemResource))]
    [SwaggerResponse(400, "The purchase order items were not created")]
    public async Task<ActionResult> CreatePurchaseOrderItem([FromBody] CreatePurchaseOrderItemResource resource)
    {
        var createPurchaseOrderItemCommand = CreatePurchaseOrderItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await purchaseOrderItemCommandService.Handle(createPurchaseOrderItemCommand);
        if (result is null) return BadRequest();
        return  CreatedAtAction(nameof(GetPurchaseOrderItemsById), new { id = result.id },
            PurchaseOrderItemResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a purchase order item by id",
        Description = "Gets a purchase order item by id",
        OperationId = "GetPurchaseOrderItemById")]
    [SwaggerResponse(200, "The purchase order item was found", typeof(PurchaseOrderItemResource))]
    [SwaggerResponse(404, "The purchase order item was not found")]
    public async Task<ActionResult> GetPurchaseOrderItemsById(int id)
    {
        var getPurchaseOrderItemsByIdQuery = new GetPurchaseOrderItemsByIdQuery(id);
        var result = await purchaseOrderItemQueryService.Handle(getPurchaseOrderItemsByIdQuery);
        if (result is null) return NotFound();
        var resource = PurchaseOrderItemResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}