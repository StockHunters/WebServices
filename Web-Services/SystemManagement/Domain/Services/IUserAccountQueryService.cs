using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Queries;

namespace Web_Services.SystemManagement.Domain.Services;

public interface IUserAccountQueryService
{
    Task<UserAccount?> Handle(GetUserAccountByIdQuery query);
    Task<IEnumerable<UserAccount>> Handle(GetAllUsersAccountsQuery query);
}