using Web_Services.SystemManagement.Domain.Model.Aggregates;
namespace Web_Services.SystemManagement.Domain.Repositories;

public class ActivityRepository : IActivityRepository
    {
        private readonly List<Activity> _activities;

        public ActivityRepository()
        {
            _activities = new List<Activity>
            {
                new Activity("ACT001", "USR001", "purchase", "Processed sale SAL001", DateTime.Parse("2025-06-13T11:10:00-05:00")),
                new Activity("ACT002", "USR003", "purchase", "Processed sale SAL002", DateTime.Parse("2025-06-12T11:15:00-05:00")),
                new Activity("ACT003", "USR005", "purchase", "Processed sale SAL003", DateTime.Parse("2025-06-11T11:20:00-05:00")),
                new Activity("ACT004", "USR007", "purchase", "Processed sale SAL004", DateTime.Parse("2025-06-10T11:25:00-05:00")),
                new Activity("ACT005", "USR009", "purchase", "Processed sale SAL005", DateTime.Parse("2025-06-09T11:30:00-05:00")),
                new Activity("ACT006", "USR001", "purchase", "Processed sale SAL006", DateTime.Parse("2025-06-08T11:35:00-05:00")),
                new Activity("ACT007", "USR003", "purchase", "Processed sale SAL007", DateTime.Parse("2025-06-07T11:40:00-05:00")),
                new Activity("ACT008", "USR005", "purchase", "Processed sale SAL008", DateTime.Parse("2025-06-06T11:45:00-05:00")),
                new Activity("ACT009", "USR007", "purchase", "Processed sale SAL009", DateTime.Parse("2025-06-05T11:50:00-05:00")),
                new Activity("ACT010", "USR009", "purchase", "Processed sale SAL010", DateTime.Parse("2025-06-04T11:55:00-05:00"))
            };
        }

        public async Task AddAsync(Activity activity)
        {
            _activities.Add(activity);
            await Task.CompletedTask;
        }

        public async Task<Activity?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
        }

        public async Task<IEnumerable<Activity>> GetByUserIdAsync(string userId)
        {
            return await Task.FromResult(_activities.Where(a => a.UserId == userId));
        }
    }