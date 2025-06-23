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
[SwaggerTag("Available ProductLocations Endpoints.")]
public class ProductLocationController(IProductLocationCommandService productLocationCommandService, IProductLocationQueryService productLocationQueryService): ControllerBase
{
    [HttpGet("{productLocationId:int}")]
    [SwaggerOperation("Get ProductLocation by Id", "Get a productLocation by its unique identifier.", OperationId = "GetProductLocationById")]
    [SwaggerResponse(200, "The productLocation was found and returned.", typeof(ProductLocationResource))]
    [SwaggerResponse(404, "The productLocation was not found.")]
    public async Task<IActionResult> GetProductLocationById(int productLocationId)
    {
        var getProductLocationByIdQuery = new GetProductLocationByIdQuery(productLocationId);
        var productLocation = await productLocationQueryService.Handle(getProductLocationByIdQuery);
        if (productLocation is null) return NotFound();
        var productLocationResource = ProductLocationResourceFromEntityAssembler.ToResourceFromEntity(productLocation);
        return Ok(productLocationResource);
    }

    [HttpPost]
    [SwaggerOperation("Create ProductLocation", "Create a new productLocation.", OperationId = "CreateProductLocation")]
    [SwaggerResponse(201, "The productLocation was created.", typeof(ProductLocationResource))]
    [SwaggerResponse(400, "The productLocation was not created.")]
    public async Task<IActionResult> CreateProductLocation(CreateProductLocationResource resource)
    {
        var createProductLocationCommand = CreateProductLocationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var productLocation = await productLocationCommandService.Handle(createProductLocationCommand);
        if (productLocation is null) return BadRequest();
        var productLocationResource = ProductLocationResourceFromEntityAssembler.ToResourceFromEntity(productLocation);
        return CreatedAtAction(nameof(GetProductLocationById), new { productLocationId = productLocation.Id }, productLocationResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All ProductLocations", "Get all productLocations.", OperationId = "GetAllProductLocations")]
    [SwaggerResponse(200, "The productLocations were found and returned.", typeof(IEnumerable<ProductLocationResource>))]
    [SwaggerResponse(404, "The productLocations were not found.")]
    public async Task<IActionResult> GetAllProductLocations()
    {
        var getAllProductLocationsQuery = new GetAllProductLocationsQuery();
        var productLocations = await productLocationQueryService.Handle(getAllProductLocationsQuery);
        var productLocationResources = productLocations.Select(ProductLocationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productLocationResources);
    }
}