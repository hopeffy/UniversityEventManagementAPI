namespace UniversityEventManagementAPI.Models.DTO
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
