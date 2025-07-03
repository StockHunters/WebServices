using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Model.Commands;

namespace Web_Services.SystemManagement.Domain.Services;

public interface IUserCommandService
{
    Task<UserAccount?> Handle(CreateUserCommand command);
}