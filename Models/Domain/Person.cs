using Microsoft.AspNetCore.Identity;

namespace UniversityEventManagementAPI.Models.Domain
{
    public class Person
    {
        public Guid id { get; set; }
        public string? name { get; set; }

        public string? surname { get; set; }
        public string? role {get; set;}
        public DateTime createdTime { get; set; } 
    }
}
