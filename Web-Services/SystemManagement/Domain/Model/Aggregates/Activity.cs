namespace Web_Services.SystemManagement.Domain.Model.Aggregates;

    public class Activity
    {
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string ActivityType { get; private set; }
        public string Description { get; private set; }
        public DateTime ActivityDate { get; private set; }

        public Activity(string id, string userId, string activityType, string description, DateTime activityDate)
        {
            Id = id;
            UserId = userId;
            ActivityType = activityType;
            Description = description;
            ActivityDate = activityDate;
        }
    }
