using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Model.Queries;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork): ICategoryCommandService
{
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command);
        try
        {
            await categoryRepository.AddAsync(category);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return category;
    }
}