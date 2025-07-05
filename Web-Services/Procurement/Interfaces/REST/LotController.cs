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
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Lots")]
public class LotController(ILotCommandService lotCommandService, ILotQueryService lotQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a lot",
        Description = "Creates a lot",
        OperationId = "CreateLot")]
    [SwaggerResponse(201, "The lot was created", typeof(LotResource))]
    [SwaggerResponse(400, "The lot was not created")]
    public async Task<ActionResult> CreateLot([FromBody] CreateLotResource resource)
    {
        var createLotCommand = CreateLotCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await lotCommandService.Handle(createLotCommand);
        if(result is null) return BadRequest();
        return CreatedAtAction(nameof(GetLotById), new {id = result.id},
            LotResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a lot by id",
        Description = "Gets a lot by id",
        OperationId = "GetLotById")]
    [SwaggerResponse(200, "The lot was found", typeof(LotResource))]
    [SwaggerResponse(404, "The lot was not found")]
    public async Task<ActionResult> GetLotById(int id)
    {
        var getLotByIdQuery = new GetLotByIdQuery(id);
        var result = await lotQueryService.Handle(getLotByIdQuery);
        if (result is null) return NotFound();
        var resource = LotResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Lot", "Get all Lot.", OperationId = "GetAllLots")]
    [SwaggerResponse(200, "The Lot were found and returned.", typeof(IEnumerable<LotResource>))]
    [SwaggerResponse(404, "The Lot were not found.")]
    public async Task<IActionResult> GetAllLots()
    {
        var getAllLotsQuery = new GetAllLotQuery();
        var lot = await lotQueryService.Handle(getAllLotsQuery);
        var lotResources = lot.Select(LotResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(lotResources);
    }
    
}