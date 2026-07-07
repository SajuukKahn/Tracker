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
                // Check if data already exists
                if (_context.Projects.Any())
                {
                    Success = false;
                    return Page();
                }

                // Create sample people
                var person1 = new Person { FirstName = "John", LastName = "Smith", Email = "john.smith@example.com" };
                var person2 = new Person { FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@example.com" };
                var person3 = new Person { FirstName = "Mike", LastName = "Davis", Email = "mike.davis@example.com" };
                var person4 = new Person { FirstName = "Emily", LastName = "Wilson", Email = "emily.wilson@example.com" };

                _context.People.AddRange(person1, person2, person3, person4);
                await _context.SaveChangesAsync();

                // Create sample projects
                var project1 = new Project
                {
                    Name = "Assembly Line A",
                    Description = "Main production assembly line for product A",
                    CreatedDate = DateTime.UtcNow,
                    People = [person1, person2]
                };

                var project2 = new Project
                {
                    Name = "Packaging System",
                    Description = "Automated packaging and labeling system",
                    CreatedDate = DateTime.UtcNow,
                    People = [person3, person4]
                };

                _context.Projects.AddRange(project1, project2);
                await _context.SaveChangesAsync();

                // Create sample machines
                var machine1 = new Machine { SerialNumber = "ASM-001", ProjectId = project1.Id };
                var machine2 = new Machine { SerialNumber = "ASM-002", ProjectId = project1.Id };
                var machine3 = new Machine { SerialNumber = "PKG-001", ProjectId = project2.Id };

                _context.Machines.AddRange(machine1, machine2, machine3);
                await _context.SaveChangesAsync();

                // Create sample issues
                var issue1 = new Issue
                {
                    Title = "Conveyor Belt Misalignment",
                    Description = "The conveyor belt on Assembly Line A is not properly aligned, causing product jams.",
                    Severity = Severity.High,
                    ProjectId = project1.Id,
                    MachineId = machine1.Id,
                    ReportedById = person1.Id,
                    AssignedToId = person3.Id,
                    ReportedDate = DateTime.UtcNow.AddDays(-5),
                    IsResolved = false
                };

                var issue2 = new Issue
                {
                    Title = "Sensor Calibration Needed",
                    Description = "Vision system sensors need recalibration for accurate measurements.",
                    Severity = Severity.Medium,
                    ProjectId = project1.Id,
                    MachineId = machine2.Id,
                    ReportedById = person2.Id,
                    AssignedToId = person4.Id,
                    ReportedDate = DateTime.UtcNow.AddDays(-3),
                    IsResolved = false
                };

                var issue3 = new Issue
                {
                    Title = "Software Update Failed",
                    Description = "The latest firmware update didn't install properly on the control system.",
                    Severity = Severity.Critical,
                    ProjectId = project2.Id,
                    MachineId = machine3.Id,
                    ReportedById = person3.Id,
                    ReportedDate = DateTime.UtcNow.AddDays(-1),
                    IsResolved = false
                };

                var issue4 = new Issue
                {
                    Title = "Hydraulic Fluid Leak",
                    Description = "Minor hydraulic fluid leak detected near actuator arm.",
                    Severity = Severity.Low,
                    ProjectId = project1.Id,
                    MachineId = machine1.Id,
                    ReportedById = person1.Id,
                    ReportedDate = DateTime.UtcNow.AddDays(-10),
                    IsResolved = true,
                    ResolvedDate = DateTime.UtcNow.AddDays(-8),
                    ResolutionNotes = "Seal was replaced and system was pressure tested."
                };

                _context.Issues.AddRange(issue1, issue2, issue3, issue4);
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
