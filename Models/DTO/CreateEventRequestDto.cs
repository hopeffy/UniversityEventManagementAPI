using UniversityEventManagementAPI.Models.Domain;

namespace UniversityEventManagementAPI.Models.DTO
{
    public class CreateEventRequestDto
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public string? Location { get; set; }

        public Guid organizerId { get; set; }
    }
}
