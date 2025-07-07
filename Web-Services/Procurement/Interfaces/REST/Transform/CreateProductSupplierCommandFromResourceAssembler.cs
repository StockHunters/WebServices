using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class CreateProductSupplierCommandFromResourceAssembler
{
    public static CreateProductSupplierCommand ToCommandFromResource(CreateProductSupplierResource resource) =>
    new CreateProductSupplierCommand(resource.product_id, resource.supplier_id, resource.supply_price, resource.created_at);
}