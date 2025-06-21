using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Queries;
using Web_Services.SystemManagement.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Services;

namespace Web_Services.SystemManagement.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository): IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
}