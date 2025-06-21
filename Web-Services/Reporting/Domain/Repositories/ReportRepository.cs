using Web_Services.Reporting.Domain.Model.Aggregates;

namespace Web_Services.Reporting.Domain.Repositories;

 public class ReportRepository : IReportRepository
    {
        private readonly List<Report> _reports;

        public ReportRepository()
        {
            // Inicializamos con datos de la fake API
            _reports = new List<Report>
            {
                new Report("REP001", "USR002", "sales", DateTime.Parse("2025-06-13T11:20:00-05:00"), "http://example.com/report_sales_001.pdf", new Dictionary<string, string> { { "date", "2025-06-13" } }),
                new Report("REP002", "USR004", "sales", DateTime.Parse("2025-06-12T11:25:00-05:00"), "http://example.com/report_sales_002.pdf", new Dictionary<string, string> { { "date", "2025-06-12" } }),
                new Report("REP003", "USR006", "sales", DateTime.Parse("2025-06-11T11:30:00-05:00"), "http://example.com/report_sales_003.pdf", new Dictionary<string, string> { { "date", "2025-06-11" } }),
                new Report("REP004", "USR008", "sales", DateTime.Parse("2025-06-10T11:35:00-05:00"), "http://example.com/report_sales_004.pdf", new Dictionary<string, string> { { "date", "2025-06-10" } }),
                new Report("REP005", "USR010", "sales", DateTime.Parse("2025-06-09T11:40:00-05:00"), "http://example.com/report_sales_005.pdf", new Dictionary<string, string> { { "date", "2025-06-09" } }),
                new Report("REP006", "USR002", "inventory", DateTime.Parse("2025-06-08T11:45:00-05:00"), "http://example.com/report_inventory_001.pdf", new Dictionary<string, string> { { "date", "2025-06-08" } }),
                new Report("REP007", "USR004", "inventory", DateTime.Parse("2025-06-07T11:50:00-05:00"), "http://example.com/report_inventory_002.pdf", new Dictionary<string, string> { { "date", "2025-06-07" } }),
                new Report("REP008", "USR006", "inventory", DateTime.Parse("2025-06-06T11:55:00-05:00"), "http://example.com/report_inventory_003.pdf", new Dictionary<string, string> { { "date", "2025-06-06" } }),
                new Report("REP009", "USR008", "inventory", DateTime.Parse("2025-06-05T12:00:00-05:00"), "http://example.com/report_inventory_004.pdf", new Dictionary<string, string> { { "date", "2025-06-05" } }),
                new Report("REP010", "USR010", "inventory", DateTime.Parse("2025-06-04T12:05:00-05:00"), "http://example.com/report_inventory_005.pdf", new Dictionary<string, string> { { "date", "2025-06-04" } })
            };
        }

        public async Task AddAsync(Report report)
        {
            _reports.Add(report);
            await Task.CompletedTask;
        }

        public async Task<Report> GetByIdAsync(string id)
        {
            return await Task.FromResult(_reports.FirstOrDefault(r => r.Id == id));
        }

        public async Task<IEnumerable<Report>> GetByUserIdAsync(string userId)
        {
            return await Task.FromResult(_reports.Where(r => r.UserId == userId));
        }
    }