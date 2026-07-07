namespace Tracker.Pages.Machines
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
        public Machine Machine { get; set; } = new() { SerialNumber = "" };

        public SelectList ProjectSelectList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? projectId)
        {
            var projects = await _context.Projects.ToListAsync();
            ProjectSelectList = new SelectList(projects, "Id", "Name", projectId);

            if (projectId.HasValue)
            {
                Machine.ProjectId = projectId.Value;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var projects = await _context.Projects.ToListAsync();
                ProjectSelectList = new SelectList(projects, "Id", "Name");
                return Page();
            }

            _context.Machines.Add(Machine);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Projects/Details", new { id = Machine.ProjectId });
        }
    }
}
