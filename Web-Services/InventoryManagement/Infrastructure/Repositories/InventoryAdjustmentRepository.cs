using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Web_Services.InventoryManagement.Infrastructure.Repositories;

public class InventoryAdjustmentRepository(AppDbContext context): BaseRepository<InventoryAdjustment>(context), IInventoryAdjustmentRepository
{
    
}