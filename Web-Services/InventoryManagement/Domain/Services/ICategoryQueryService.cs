using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Queries;

namespace Web_Services.InventoryManagement.Domain.Services;

public interface ICategoryQueryService
{
    Task<Category?> Handle(GetCategoryByIdQuery query);
    
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
}