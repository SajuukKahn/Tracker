namespace Tracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public List<Machine> Machines { get; set; } = [];

        public List<Person> People { get; set; } = [];

        public List<Issue> Issues { get; set; } = [];

        public int? ReferenceId { get; set; }
        public Project? Reference { get; set; }
    }
}