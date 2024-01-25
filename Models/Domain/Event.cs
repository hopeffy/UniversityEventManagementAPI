namespace UniversityEventManagementAPI.Models.Domain
{
    public class Event
    {

        public Guid id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public string Location { get; set; }

        public Person organizer { get; set; }

    }
}
