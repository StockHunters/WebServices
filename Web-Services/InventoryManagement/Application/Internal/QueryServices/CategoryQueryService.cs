using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;

namespace Web_Services.InventoryManagement.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository): ICategoryQueryService
{
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }
}