using Web_Services.Procurement.Domain.Model.Aggregates;
using Web_Services.Shared.Domain.Repositories;


namespace Web_Services.Procurement.Domain.Repositories;

public interface ILotRepository: IBaseRepository<lots>
{
    Task<IEnumerable<lots>> FindByLotIdAsync(int lotId);
}