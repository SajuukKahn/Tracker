namespace Tracker.Models
{
    public class MachineType
    {
        public required string Name { get; set; }
        public required char Prefix { get; set; } = 'A';
    }
}