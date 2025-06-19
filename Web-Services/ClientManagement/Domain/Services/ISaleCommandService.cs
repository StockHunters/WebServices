using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Commands;

namespace Web_Services.ClientManagement.Domain.Services;

public interface ISaleCommandService
{
    Task<Sale?> Handle(CreateSaleCommand command);
}