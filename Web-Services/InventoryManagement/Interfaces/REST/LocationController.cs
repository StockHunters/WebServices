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
[SwaggerTag("Available Location Endpoints")]
public class LocationController(ILocationCommandService locationCommandService, ILocationQueryService locationQueryService): ControllerBase
{
     /// <summary>
    ///     Get location by id
    /// </summary>
    /// <param name="locationId">
    ///     The location id
    /// </param>
    /// <returns>
    ///     The <see cref="LocationResource" /> location
    /// </returns>
    [HttpGet("{locationId:int}")]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetAllLocations")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of categories", typeof(LocationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No categories found")]
    public async Task<IActionResult> GetLocationById(int locationId)
    {
        var getLocationByIdQuery = new GetLocationByIdQuery(locationId);
        var location = await locationQueryService.Handle(getLocationByIdQuery);
        if (location is null) return NotFound();
        var resource = LocationResourceFromEntityAssembler.ToResourceFromEntity(location);
        return Ok(resource);
    }

    /// <summary>
    ///     Create a new location
    /// </summary>
    /// <param name="resource">
    ///     The <see cref="CreateLocationResource" /> location resource
    /// </param>
    /// <returns>
    ///     The <see cref="LocationResource" /> location created, or a bad request if the location could not be created
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new location",
        Description = "Create a new location",
        OperationId = "CreateLocation")]
    [SwaggerResponse(StatusCodes.Status201Created, "The location was created", typeof(LocationResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The location could not be created")]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationResource resource)
    {
        var createLocationCommand = CreateLocationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var location = await locationCommandService.Handle(createLocationCommand);
        if (location is null) return BadRequest();
        var locationResource = LocationResourceFromEntityAssembler.ToResourceFromEntity(location);
        return CreatedAtAction(nameof(GetLocationById), new { locationId = location.Id }, locationResource);
    }

    /// <summary>
    ///     Get all categories
    /// </summary>
    /// <returns>
    ///     The list of <see cref="LocationResource" /> categories
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Get all categories",
        OperationId = "GetAllLocations")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of categories", typeof(IEnumerable<LocationResource>))]
    public async Task<IActionResult> GetAllLocations()
    {
        var categories = await locationQueryService.Handle(new GetAllLocationsQuery());
        var locationResources = categories.Select(LocationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(locationResources);
    }
}