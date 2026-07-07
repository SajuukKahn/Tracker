namespace Tracker.Models
{
    using Tracker.Enums;

    public class Issue
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public Severity Severity { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public int? MachineId { get; set; }
        public Machine? Machine { get; set; }

        public int? ReportedById { get; set; }
        public Person? ReportedBy { get; set; }

        public int? AssignedToId { get; set; }
        public Person? AssignedTo { get; set; }

        public DateTime ReportedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ResolvedDate { get; set; }

        public bool IsResolved { get; set; }

        public string? ResolutionNotes { get; set; }
    }
}