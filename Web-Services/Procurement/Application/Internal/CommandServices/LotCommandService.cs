using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Commands;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.Procurement.Application.Internal.CommandServices;

public class LotCommandService(ILotRepository lotRepository, IUnitOfWork unitOfWork): ILotCommandService
{
    public async Task<lots?> Handle(CreateLotCommand command)
    {
        var lot = new lots(command);
        try
        {
            await lotRepository.AddAsync(lot);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return lot;
    }
}