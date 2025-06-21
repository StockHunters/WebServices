using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Queries;

namespace Web_Services.SystemManagement.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}