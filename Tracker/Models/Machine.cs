namespace Tracker.Models
{
    public class Machine
    {
        public required string SerialNumber { get; set; }
        public List<Person>? Project { get; set; }
        public List<Person>? Controls { get; set; }
        public List<Person>? Fluid { get; set; }
        public List<Person>? Software { get; set; }
        public List<Person>? Computer { get; set; }
        public List<Person>? Vision { get; set; }
        public List<Person>? Programming { get; set; }
        public List<Person>? Quality { get; set; }
        public List<Person>? Service { get; set; }
        
        public Machine? Reference { get; set; }
    }
}
