namespace Web_Services.SystemManagement.Domain.Model.Commands;

    public class CreateActivityCommand
    {
        public string UserId { get; set; }
        public string ActivityType { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
    }
