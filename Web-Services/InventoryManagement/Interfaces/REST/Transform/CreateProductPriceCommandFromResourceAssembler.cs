using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Interfaces.REST.Resources;

namespace Web_Services.InventoryManagement.Interfaces.REST.Transform;

public static class CreateProductPriceCommandFromResourceAssembler
{
    public static CreateProductPriceCommand ToCommandFromResource(CreateProductPriceResource resource) =>
        new CreateProductPriceCommand(resource.ProductId, resource.Price, resource.Discount, resource.EffectiveDate);
}