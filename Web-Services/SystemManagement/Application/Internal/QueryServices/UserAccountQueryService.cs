using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Services;

namespace Web_Services.SystemManagement.Application.Internal.QueryServices;

public class UserAccountQueryService(IUserAccountRepository userAccountRepository): IUserAccountQueryService
{
    public async Task<IEnumerable<UserAccount>> Handle(GetAllUsersAccountsQuery accountsQuery)
    {
        return await userAccountRepository.ListAsync();
    }
    
    public async Task<UserAccount?> Handle(GetUserAccountByIdQuery query)
    {
        return await userAccountRepository.FindByIdAsync(query.Id);
    }
}