namespace Tracker.Pages.Projects
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class DetailsModel : PageModel
    {
        private readonly TrackerContext _context;

        public DetailsModel(TrackerContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = null!;
        public int OpenIssuesCount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Machines)
                .Include(p => p.People)
                .Include(p => p.Issues)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            Project = project;
            OpenIssuesCount = project.Issues.Count(i => !i.IsResolved);

            return Page();
        }
    }
}
