using Web_Services.InventoryManagement.Domain.Model.Commands;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class Category
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }

    public Category()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }
    
}