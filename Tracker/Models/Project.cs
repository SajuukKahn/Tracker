namespace Tracker.Models
{
    public class Project
    {
        public List<Machine> Machines { get; set; } = [];
        public Project? Reference { get; set; }
    }
}