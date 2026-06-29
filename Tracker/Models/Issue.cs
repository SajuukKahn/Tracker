namespace Tracker.Models
{
    using Tracker.Enums;

    public class Issue
    {
        public Severity Severity { get; set; }

        public required string Message { get; set; }
    }
}