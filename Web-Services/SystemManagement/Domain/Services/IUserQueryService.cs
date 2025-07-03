using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Queries;

namespace Web_Services.SystemManagement.Domain.Services;

public interface IUserQueryService
{
    Task<UserAccount?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<UserAccount>> Handle(GetAllUsersQuery query);
}