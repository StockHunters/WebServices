using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;
using Web_Services.SystemManagement.Domain.Model.Aggregate;
using Web_Services.SystemManagement.Domain.Repositories;

namespace Web_Services.SystemManagement.Infrastructure.Persistence.EFC.Repositories;

public class UserAccountRepository(AppDbContext context): BaseRepository<UserAccount>(context), IUserAccountRepository
{
    
}