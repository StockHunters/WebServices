using Web_Services.InventoryManagement.Domain.Model.Commands;

namespace Web_Services.InventoryManagement.Domain.Model.Aggregates;

public partial class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

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