namespace Tracker.Pages.Issues
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class CreateModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        [BindProperty]
        public Issue Issue { get; set; } = new() { Title = "", Description = "" };

        public SelectList ProjectSelectList { get; set; } = null!;
        public SelectList MachineSelectList { get; set; } = null!;
        public SelectList PeopleSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? projectId)
        {
            await LoadSelectListsAsync(projectId);

            if (projectId.HasValue)
            {
                Issue.ProjectId = projectId.Value;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync(null);
                return Page();
            }

            Issue.ReportedDate = DateTime.UtcNow;
            Issue.IsResolved = false;

            _context.Issues.Add(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Issue.Id });
        }

        private async Task LoadSelectListsAsync(int? projectId)
        {
            var projects = await _context.Projects.ToListAsync();
            ProjectSelectList = new SelectList(projects, "Id", "Name", projectId);

            var machines = projectId.HasValue 
                ? await _context.Machines.Where(m => m.ProjectId == projectId.Value).ToListAsync()
                : await _context.Machines.ToListAsync();
            MachineSelectList = new SelectList(machines, "Id", "SerialNumber");

            var people = await _context.People.ToListAsync();
            PeopleSelectList = new SelectList(people.Select(p => new
            {
                p.Id,
                FullName = $"{p.FirstName} {p.LastName}"
            }), "Id", "FullName");
        }
    }
}
