namespace Tracker.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Tracker.Contexts;
    using Tracker.Enums;
    using Tracker.Models;

    public class SeedDataModel : PageModel
    {
        private readonly TrackerContext _context;

        public SeedDataModel(TrackerContext context)
        {
            _context = context;
        }

        public bool Success { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var people = new List<Person>
                {
                    new Person { FirstName = "John", LastName = "Smith", Email = "john.smith@example.com" },
                    new Person { FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@example.com" },
                    new Person { FirstName = "Mike", LastName = "Davis", Email = "mike.davis@example.com" },
                    new Person { FirstName = "Emily", LastName = "Wilson", Email = "emily.wilson@example.com" },
                    new Person { FirstName = "Daniel", LastName = "Brown", Email = "daniel.brown@example.com" },
                    new Person { FirstName = "Alicia", LastName = "Garcia", Email = "alicia.garcia@example.com" },
                    new Person { FirstName = "Chris", LastName = "Martinez", Email = "chris.martinez@example.com" },
                    new Person { FirstName = "Priya", LastName = "Patel", Email = "priya.patel@example.com" },
                    new Person { FirstName = "Liam", LastName = "Nguyen", Email = "liam.nguyen@example.com" },
                    new Person { FirstName = "Maya", LastName = "Kim", Email = "maya.kim@example.com" },
                    new Person { FirstName = "Jordan", LastName = "Lee", Email = "jordan.lee@example.com" },
                    new Person { FirstName = "Nina", LastName = "Rodriguez", Email = "nina.rodriguez@example.com" }
                };

                _context.People.AddRange(people);
                await _context.SaveChangesAsync();

                var projects = new List<Project>
                {
                    new Project
                    {
                        Name = "Assembly Line A",
                        Description = "Main production assembly line for product A",
                        CreatedDate = DateTime.UtcNow.AddDays(-30),
                        People = [people[0], people[1], people[2]]
                    },
                    new Project
                    {
                        Name = "Packaging System",
                        Description = "Automated packaging and labeling system",
                        CreatedDate = DateTime.UtcNow.AddDays(-24),
                        People = [people[3], people[4], people[5]]
                    },
                    new Project
                    {
                        Name = "Robot Cell 3",
                        Description = "Collaborative robotics workcell for palletizing",
                        CreatedDate = DateTime.UtcNow.AddDays(-18),
                        People = [people[6], people[7], people[8]]
                    },
                    new Project
                    {
                        Name = "Quality Inspection Station",
                        Description = "Vision-based inspection and defect verification",
                        CreatedDate = DateTime.UtcNow.AddDays(-12),
                        People = [people[9], people[10], people[11]]
                    }
                };

                _context.Projects.AddRange(projects);
                await _context.SaveChangesAsync();

                var machines = new List<Machine>
                {
                    new Machine { SerialNumber = "ASM-001", ProjectId = projects[0].Id },
                    new Machine { SerialNumber = "ASM-002", ProjectId = projects[0].Id },
                    new Machine { SerialNumber = "PKG-001", ProjectId = projects[1].Id },
                    new Machine { SerialNumber = "PKG-002", ProjectId = projects[1].Id },
                    new Machine { SerialNumber = "RBT-001", ProjectId = projects[2].Id },
                    new Machine { SerialNumber = "RBT-002", ProjectId = projects[2].Id },
                    new Machine { SerialNumber = "QIS-001", ProjectId = projects[3].Id },
                    new Machine { SerialNumber = "QIS-002", ProjectId = projects[3].Id }
                };

                _context.Machines.AddRange(machines);
                await _context.SaveChangesAsync();

                var severities = new[] { Severity.High, Severity.Medium, Severity.Critical, Severity.Low };
                var issueTitles = new[]
                {
                    "Conveyor Belt Misalignment",
                    "Sensor Calibration Needed",
                    "Software Update Failed",
                    "Hydraulic Fluid Leak",
                    "Drive Motor Overheating",
                    "Safety Interlock Fault",
                    "Network Latency Spike",
                    "Vision Camera Blur",
                    "Actuator Stall Detected",
                    "Label Printer Jam",
                    "Pressure Sensor Drift",
                    "Wiring Harness Wear",
                    "Control Panel Error",
                    "Pneumatic Valve Leak",
                    "Thermal Camera Offset",
                    "Operator HMI Freeze"
                };

                var issues = new List<Issue>();
                var baseDate = DateTime.UtcNow;

                for (var i = 0; i < 16; i++)
                {
                    var project = projects[i % projects.Count];
                    var machine = machines[(i + 2) % machines.Count];
                    var reporter = people[i % people.Count];
                    var assignee = people[(i + 3) % people.Count];

                    var issue = new Issue
                    {
                        Title = $"{issueTitles[i % issueTitles.Length]} #{i + 1}",
                        Description = $"Automated seed data issue {i + 1} for {project.Name}.",
                        Severity = severities[i % severities.Length],
                        ProjectId = project.Id,
                        MachineId = machine.Id,
                        ReportedById = reporter.Id,
                        ReportedDate = baseDate.AddDays(-(i + 1)),
                        IsResolved = i % 4 == 0
                    };

                    if (i % 2 == 0)
                    {
                        issue.AssignedToId = assignee.Id;
                    }

                    if (issue.IsResolved)
                    {
                        issue.ResolvedDate = baseDate.AddDays(-(i + 1) + 1);
                        issue.ResolutionNotes = "Resolved through routine maintenance and validation.";
                    }

                    issues.Add(issue);
                }

                _context.Issues.AddRange(issues);
                await _context.SaveChangesAsync();

                Success = true;
            }
            catch
            {
                Success = false;
            }

            return Page();
        }
    }
}