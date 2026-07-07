namespace Tracker.Models
{
    public class Role
    {
        public int Id { get; set; }

        public int DepartmentLeadId { get; set; }
        public required Person DepartmentLead { get; set; }

        public required string Department { get; set; }

        public required string Name { get; set; }
    }
}