using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UniversityEventManagementAPI.Models;
using Microsoft.Extensions.Configuration;


namespace UniversityEventManagementAPI.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public DbSet<Domain.Event> Event { get; set; }
        public DbSet<Domain.Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

        }

    }
}
