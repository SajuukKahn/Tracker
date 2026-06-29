namespace Tracker.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Tracker.Models;

    public class TrackerContext(DbContextOptions<TrackerContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}