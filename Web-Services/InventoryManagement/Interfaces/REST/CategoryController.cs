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
[SwaggerTag("Available Category Endpoints.")]

public class CategoryController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService):ControllerBase
{
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation("Get Category by Id", "Get a category by its unique identifier.", OperationId = "GetCategoryById")]
    [SwaggerResponse(200, "The category was found and returned.", typeof(CategoryResource))]
    [SwaggerResponse(404, "The category was not found.")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category is null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Category", "Create a new category.", OperationId = "CreateCategory")]
    [SwaggerResponse(201, "The category was created.", typeof(CategoryResource))]
    [SwaggerResponse(400, "The category was not created.")]
    public async Task<IActionResult> CreateCategory(CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.Id }, categoryResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Categories", "Get all categories.", OperationId = "GetAllCategories")]
    [SwaggerResponse(200, "The categories were found and returned.", typeof(IEnumerable<CategoryResource>))]
    [SwaggerResponse(404, "The categories were not found.")]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var categoryResources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }
}