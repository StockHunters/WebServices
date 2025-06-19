using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_Services.ClientManagement.Domain.Model.Queries;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.ClientManagement.Interfaces.REST.Resources;
using Web_Services.ClientManagement.Interfaces.REST.Transform;

namespace Web_Services.ClientManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Sale Endpoints.")]
public class SaleController(ISaleCommandService saleCommandService, ISaleQueryService saleQueryService): ControllerBase
{
    [HttpGet("{saleId:int}")]
    [SwaggerOperation("Get Sale by Id", "Get a sale by its unique identifier.", OperationId = "GetSaleById")]
    [SwaggerResponse(200, "The sale was found and returned.", typeof(SaleResource))]
    [SwaggerResponse(404, "The sale was not found.")]
    public async Task<IActionResult> GetSaleById(int saleId)
    {
        var getSaleByIdQuery = new GetSaleByIdQuery(saleId);
        var sale = await saleQueryService.Handle(getSaleByIdQuery);
        if (sale is null) return NotFound();
        var saleResource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return Ok(saleResource);
    }
    
    [HttpGet]
    [SwaggerOperation("Get All Sales", "Get all sales.", OperationId = "GetAllSales")]
    [SwaggerResponse(200, "The sales were found and returned.", typeof(IEnumerable<SaleResource>))]
    [SwaggerResponse(404, "The sales were not found.")]
    public async Task<IActionResult> GetAllSales()
    {
        var getAllSalesQuery = new GetAllSalesQuery();
        var sales = await saleQueryService.Handle(getAllSalesQuery);
        var saleResources = sales.Select(SaleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(saleResources);
    }
    
    [HttpPost]
    [SwaggerOperation("Create Sale", "Create a new sale.", OperationId = "CreateSale")]
    [SwaggerResponse(201, "The sale was created.", typeof(SaleResource))]
    [SwaggerResponse(400, "The sale was not created.")]
    public async Task<IActionResult> CreateSale(CreateSaleResource resource)
    {
        var createSaleCommand = CreateSaleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var sale = await saleCommandService.Handle(createSaleCommand);
        if (sale is null) return BadRequest();
        var saleResource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return CreatedAtAction(nameof(GetSaleById), new { saleId = sale.Id }, saleResource);
    }
}