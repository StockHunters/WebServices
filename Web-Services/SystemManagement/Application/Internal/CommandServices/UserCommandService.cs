using Web_Services.Shared.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Services;

namespace Web_Services.SystemManagement.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            return null;
        }
    }
}