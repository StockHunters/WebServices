using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Commands;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.InventoryManagement.Application.Internal.CommandServices;

public class LocationCommandService(ILocationRepository locationRepository, IUnitOfWork unitOfWork): ILocationCommandService
{
    public async Task<Location?> Handle(CreateLocationCommand command)
    {
        var location = new Location(command);
        try
        {
            await locationRepository.AddAsync(location);
            await unitOfWork.CompleteAsync();
            return location;
        } catch (Exception e)
        {
            return null;
        }
    }
}