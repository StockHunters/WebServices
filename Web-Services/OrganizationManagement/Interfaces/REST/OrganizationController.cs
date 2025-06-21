using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.OrganizationManagement.Domain.Model.Queries;
using Web_Services.OrganizationManagement.Domain.Services;
using Web_Services.OrganizationManagement.Interfaces.REST.Resources;
using Web_Services.OrganizationManagement.Interfaces.REST.Transform;

namespace Web_Services.OrganizationManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Organization Endpoints.")]
public class OrganizationController(IOrganizationCommandService organizationCommandService, IOrganizationQueryService organizationQueryService):ControllerBase
{
    [HttpGet("{organizationId:int}")]
    [SwaggerOperation("Get Organization by Id", "Get a organization by its unique identifier.", OperationId = "GetOrganizationById")]
    [SwaggerResponse(200, "The organization was found and returned.", typeof(OrganizationResource))]
    [SwaggerResponse(404, "The organization was not found.")]
    public async Task<IActionResult> GetOrganizationById(int organizationId)
    {
        var getOrganizationByIdQuery = new GetOrganizationByIdQuery(organizationId);
        var organization = await organizationQueryService.Handle(getOrganizationByIdQuery);
        if (organization is null) return NotFound();
        var organizationResource = OrganizationResourceFromEntityAssembler.ToResourceFromEntity(organization);
        return Ok(organizationResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Organization", "Create a new organization.", OperationId = "CreateOrganization")]
    [SwaggerResponse(201, "The organization was created.", typeof(OrganizationResource))]
    [SwaggerResponse(400, "The organization was not created.")]
    public async Task<IActionResult> CreateOrganization(CreateOrganizationResource resource)
    {
        var createOrganizationCommand = CreateOrganizationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var organization = await organizationCommandService.Handle(createOrganizationCommand);
        if (organization is null) return BadRequest();
        var organizationResource = OrganizationResourceFromEntityAssembler.ToResourceFromEntity(organization);
        return CreatedAtAction(nameof(GetOrganizationById), new { organizationId = organization.Id }, organizationResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Organizations", "Get all organizations.", OperationId = "GetAllOrganizations")]
    [SwaggerResponse(200, "The organizations were found and returned.", typeof(IEnumerable<OrganizationResource>))]
    [SwaggerResponse(404, "The organizations were not found.")]
    public async Task<IActionResult> GetAllOrganizations()
    {
        var getAllOrganizationsQuery = new GetAllOrganizationsQuery();
        var organizations = await organizationQueryService.Handle(getAllOrganizationsQuery);
        var organizationResources = organizations.Select(OrganizationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(organizationResources);
    }
}