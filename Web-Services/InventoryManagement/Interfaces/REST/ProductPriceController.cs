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
[SwaggerTag("Available Product Prices Endpoint")]
public class ProductPriceController(IProductPriceCommandService productPriceCommandService, IProductPriceQueryService productPriceQueryService): ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of product prices", typeof(ProductPriceResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No product price found")]
    public async Task<IActionResult> GetProductPriceById(int id)
    {
        var getProductPriceByIdQuery = new GetProductPriceByIdQuery(id);
        var productPrice = await productPriceQueryService.Handle(getProductPriceByIdQuery);
        if (productPrice is null) return NotFound();
        var resource = ProductPriceResourceFromEntityAssembler.ToResourceFromEntity(productPrice);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new category",
        Description = "Create a new category",
        OperationId = "CreateCategory")]
    [SwaggerResponse(StatusCodes.Status201Created, "The category was created", typeof(ProductPriceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The category could not be created")]
    public async Task<IActionResult> CreateProductPrice([FromBody] CreateProductPriceResource resource)
    {
        var createProductPriceCommand = CreateProductPriceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var productPrice = await productPriceCommandService.Handle(createProductPriceCommand);
        if(productPrice is null) return BadRequest();
        var productPriceResource = ProductPriceResourceFromEntityAssembler.ToResourceFromEntity(productPrice);
        return CreatedAtAction(nameof(GetProductPriceById), new { id = productPrice.Id }, productPriceResource);
    }


}