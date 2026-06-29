namespace Tracker.Models
{
    public class Role
    {
        public required Person DepartmentLead { get; set; }
        public required string Department { get; set; }

        public required string Name { get; set; }
    }
}