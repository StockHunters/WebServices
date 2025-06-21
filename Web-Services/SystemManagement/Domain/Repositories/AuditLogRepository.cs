using Web_Services.SystemManagement.Domain.Model.Aggregates;
namespace Web_Services.SystemManagement.Domain.Repositories;

public class AuditLogRepository : IAuditLogRepository
    {
        private readonly List<AuditLog> _auditLogs;

        public AuditLogRepository()
        {
            _auditLogs = new List<AuditLog>
            {
                new AuditLog("AUD001", "USR001", "create", "Created user USR003", DateTime.Parse("2025-06-15T22:00:00-05:00"), "USR003"),
                new AuditLog("AUD002", "USR002", "update", "Updated product PROD001 price", DateTime.Parse("2025-06-15T22:05:00-05:00"), "PROD001"),
                new AuditLog("AUD003", "USR003", "create", "Created order ORD001", DateTime.Parse("2025-06-15T22:10:00-05:00"), "ORD001"),
                new AuditLog("AUD004", "USR004", "delete", "Deleted location LOC002", DateTime.Parse("2025-06-15T22:15:00-05:00"), "LOC002"),
                new AuditLog("AUD005", "USR005", "create", "Created sale SAL001", DateTime.Parse("2025-06-15T22:20:00-05:00"), "SAL001"),
                new AuditLog("AUD006", "USR006", "update", "Updated inventory for PROD003", DateTime.Parse("2025-06-15T22:25:00-05:00"), "PROD003"),
                new AuditLog("AUD007", "USR007", "create", "Created report REP001", DateTime.Parse("2025-06-15T22:30:00-05:00"), "REP001"),
                new AuditLog("AUD008", "USR008", "delete", "Deleted purchase PUR002", DateTime.Parse("2025-06-15T22:35:00-05:00"), "PUR002"),
                new AuditLog("AUD009", "USR009", "update", "Updated client CLI001 details", DateTime.Parse("2025-06-15T22:40:00-05:00"), "CLI001"),
                new AuditLog("AUD010", "USR010", "create", "Created adjustment ADJ001", DateTime.Parse("2025-06-15T22:45:00-05:00"), "ADJ001")
            };
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            _auditLogs.Add(auditLog);
            await Task.CompletedTask;
        }

        public async Task<AuditLog?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_auditLogs.FirstOrDefault(a => a.Id == id));
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId)
        {
            return await Task.FromResult(_auditLogs.Where(a => a.UserId == userId));
        }
    }   