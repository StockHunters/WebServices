using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Interfaces.REST.Resources;

namespace Web_Services.Procurement.Interfaces.REST.Transform;

public static class CreateLotCommandFromResourceAssembler
{
    public static CreateLotCommand ToCommandFromResource(CreateLotResource resource) =>
        new CreateLotCommand(resource.product_id, resource.purchase_id, resource.lot_number, resource.purchase_date,
            resource.expiration_date, resource.created_at);
}