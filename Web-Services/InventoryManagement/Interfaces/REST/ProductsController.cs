using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;
using Web_Services.InventoryManagement.Interfaces.REST.Transform;

namespace Web_Services.InventoryManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Products")]
public class ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a product",
        Description = "Create a product",
        OperationId = "CreateProduct")]
    [SwaggerResponse(201, "The product was created", typeof(ProductResource))]
    [SwaggerResponse(400, "The product was not created")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await productCommandService.Handle(createProductCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetProductById), new { id = result.Id },
            ProductResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a product by id",
        Description = "Gets a product by id",
        OperationId = "GetProductById")]
    [SwaggerResponse(200, "The product was created", typeof(ProductResource))]
    public async Task<ActionResult> GetProductById(int id)
    {
        var getProductByIdQuery = new GetProductByIdQuery(id);
        var result = await productQueryService.Handle(getProductByIdQuery);
        if (result is null) return NotFound();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    private async Task<ActionResult> GetAllProductsByCategoryId(int categoryId)
    {
        var getAllProductsByCategoryIdQuery = new GetAllProductsByCategoryIdQuery(categoryId);
        var result = await productQueryService.Handle(getAllProductsByCategoryIdQuery);
        var resource = result.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a product according to parameters",
        Description = "Gets a product for given parameters",
        OperationId = "GetProductFromQuery")]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(ProductResource))]
    public async Task<ActionResult> GetProductFromQuery([FromQuery] int categoryId)
    {
        return await GetAllProductsByCategoryId(categoryId);
    }

}