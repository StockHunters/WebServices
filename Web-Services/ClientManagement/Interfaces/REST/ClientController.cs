using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Web_Services.ClientManagement.Domain.Model.Queries;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.ClientManagement.Interfaces.REST.Resources;
using Web_Services.ClientManagement.Interfaces.REST.Transform;

namespace Web_Services.ClientManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Clients")]
public class ClientController(IClientCommandService  clientCommandService, IClientQueryService clientQueryService):ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a client",
        Description = "Creates a client",
        OperationId = "CreateClient")]
    [SwaggerResponse(201, "The client was created", typeof(ClientResource))]
    [SwaggerResponse(400, "The client was not created")]
    public async Task<ActionResult> CreateClient([FromBody] CreateClientResource resource)
    {
        var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await clientCommandService.Handle(createClientCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetClientById), new { id = result.Id }, ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }


    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a client by id",
        Description = "Gets a client by id",
        OperationId = "GetClientById")]
    [SwaggerResponse(200, "The client was created", typeof(ClientResource))]
    public async Task<ActionResult> GetClientById(int id)
    {
        var getClientByIdQuery = new GetClientByIdQuery(id);
        var result = await clientQueryService.Handle(getClientByIdQuery);
        if (result is null) return NotFound();
        var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}