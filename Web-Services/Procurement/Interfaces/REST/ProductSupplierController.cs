using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.Procurement.Domain.Model.Queries;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Procurement.Interfaces.REST.Resources;
using Web_Services.Procurement.Interfaces.REST.Transform;

namespace Web_Services.Procurement.Interfaces.REST;

[ApiController]
[Route("api/v1[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Product Suppliers")]
public class ProductSupplierController(IProductSupplierCommandService productSupplierCommandService, IProductSupplierQueryService productSupplierQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a product supplier",
        Description = "Creates a product supplier",
        OperationId = "CreateProductSupplier")]
    [SwaggerResponse(201, "The product supplier was created", typeof(ProductSupplierResource))]
    [SwaggerResponse(400, "The product supplier was not created")]
    public async Task<ActionResult> CreateProductSupplier([FromBody] CreateProductSupplierResource resource)
    {
        var createProductSupplierCommand = CreateProductSupplierCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await productSupplierCommandService.Handle(createProductSupplierCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetProductSupplierById), new { id = result.id },
            ProductSupplierResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a product supplier by id",
        Description = "Gets a product supplier by id",
        OperationId = "GetProductSupplierById")]
    [SwaggerResponse(200, "The product supplier was found", typeof(ProductSupplierResource))]
    [SwaggerResponse(404, "The product supplier was not found")]
    public async Task<ActionResult> GetProductSupplierById(int id)
    {
        var getProductSupplierByIdQuery = new GetProductSupplierByIdQuery(id);
        var result = await productSupplierQueryService.Handle(getProductSupplierByIdQuery);
        if (result is null) return NotFound();
        var resource = ProductSupplierResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}