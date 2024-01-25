namespace UniversityEventManagementAPI.Models.DTO
{
    public class PersonDto
    {
        public Guid id { get; set; }
        public string? name { get; set; }

        public string? surname { get; set; }
        public string? role { get; set; }
        public DateTime createdTime { get; set; }
    }
}
