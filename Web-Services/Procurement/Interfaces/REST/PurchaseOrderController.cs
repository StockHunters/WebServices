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
[Tags("Purchase Orders")]
public class PurchaseOrderController(IPurchaseOrderCommandService purchaseOrderCommandService, IPurchaseOrderQueryService purchaseOrderQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a purchase order",
        Description = "Creates a purchase order",
        OperationId = "CreatePurchaseOrder")]
    [SwaggerResponse(201, "The purchase order was created", typeof(PurchaseOrderResource))]
    [SwaggerResponse(400, "The purchase order was not created")]
    public async Task<ActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderResource resource)
    {
        var createPurchaseOrderCommand = CreatePurchaseOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetPurchaseOrderById), new {id = result.id},
            PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a purchase order by id",
        Description = "Gets a purchase order by id",
        OperationId = "GetPurchaseOrderById")]
    [SwaggerResponse(200, "The purchase order was found", typeof(PurchaseOrderResource))]
    [SwaggerResponse(404, "The purchase order was not found")]
    public async Task<ActionResult> GetPurchaseOrderById(int id)
    {
        var getPurchaseOrderByIdQuery = new GetPurchaseOrderByIdQuery(id);
        var result = await purchaseOrderQueryService.Handle(getPurchaseOrderByIdQuery);
        if (result is null) return NotFound();
        var resource = PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Purchase Order", "Get all Purchase Order.", OperationId = "GetAllPurchaseOrder")]
    [SwaggerResponse(200, "The Purchase Order were found and returned.", typeof(IEnumerable<PurchaseOrderResource>))]
    [SwaggerResponse(404, "The Purchase Order were not found.")]
    public async Task<IActionResult> GetAllPurchaseOrder()
    {
        var getAllPurchaseOrderQuery = new GetAllPurchaseOrderQuery();
        var purchaseOrders = await purchaseOrderQueryService.Handle(getAllPurchaseOrderQuery);
        var purchaseOrdersResources = purchaseOrders.Select(PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(purchaseOrdersResources);
    }
}