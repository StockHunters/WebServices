using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Procurement.Interfaces.REST.Resources;
using Web_Services.Procurement.Interfaces.REST.Transform;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Purchases")]
public class PurchaseController(IPurchaseCommandService purchaseCommandService, IPurchaseQueryService purchaseQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a purchase",
        Description = "Creates a purchase",
        OperationId = "CreatePurchase")]
    [SwaggerResponse(201, "The purchase was created", typeof(PurchaseResource))]
    [SwaggerResponse(400, "The purchase was not created")]
    public async Task<ActionResult> CreatePurchase([FromBody] CreatePurchaseResource resource)
    {
        var createPurchaseCommand = CreatePurchaseCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await purchaseCommandService.Handle(createPurchaseCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetPurchaseById), new {id = result.id},
            PurchaseResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a purchase by id",
        Description = "Gets a purchase by id",
        OperationId = "GetPurchaseById")]
    [SwaggerResponse(200, "The purchase was found", typeof(PurchaseResource))]
    [SwaggerResponse(404, "The purchase was not found")]
    public async Task<ActionResult> GetPurchaseById(int id)
    {
        var getPurchaseByIdQuery = new GetPurchaseByIdQuery(id);
        var result = await purchaseQueryService.Handle(getPurchaseByIdQuery);
        if (result is null) return NotFound();
        var resource = PurchaseResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    [HttpGet]
    [SwaggerOperation("Get All Purchase", "Get all Purchase.", OperationId = "GetAllPurchase")]
    [SwaggerResponse(200, "The Purchase were found and returned.", typeof(IEnumerable<PurchaseResource>))]
    [SwaggerResponse(404, "The Purchase were not found.")]
    public async Task<IActionResult> GetAllPurchase()
    {
        var getAllPurchaseQuery = new GetAllPurchaseQuery();
        var purchase = await purchaseQueryService.Handle(getAllPurchaseQuery);
        var purchaseResources = purchase.Select(PurchaseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(purchaseResources);
    }
}