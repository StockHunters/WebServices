using System.Reflection.Metadata.Ecma335;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.Commands;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.Shared.Domain.Repositories;

namespace Web_Services.ClientManagement.Application.CommandServices;

public class SaleCommandService(ISaleRepository saleRepository, IUnitOfWork unitOfWork): ISaleCommandService
{
    public async Task<Sale?> Handle(CreateSaleCommand command)
    {
        var sale = new Sale(command);
        try
        {
            await saleRepository.AddAsync(sale);
            await unitOfWork.CompleteAsync();
            return sale;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}