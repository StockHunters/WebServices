using Web_Services.Shared.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Commands;
using Web_Services.SystemManagement.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Services;

namespace Web_Services.SystemManagement.Application.Internal.CommandServices;

public class UserAccountCommandService(IUserAccountRepository userAccountRepository, IUnitOfWork unitOfWork): IUserAccountCommandService
{
    public async Task<UserAccount?> Handle(CreateUserAccountCommand accountCommand)
    {
        var user = new UserAccount(accountCommand);
        try
        {
            await userAccountRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            return null;
        }
    }
}