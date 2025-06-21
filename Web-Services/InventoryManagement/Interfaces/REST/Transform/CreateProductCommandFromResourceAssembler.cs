using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource) =>
        new CreateProductCommand(resource.Name, resource.ImageUrl, resource.Stock, resource.CategoryId);
}