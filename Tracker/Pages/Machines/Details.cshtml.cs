namespace Tracker.Pages.Machines
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class DetailsModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        public Machine Machine { get; set; } = null!;
        public List<Issue> RelatedIssues { get; set; } = [];

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id);

            if (machine == null)
            {
                return NotFound();
            }

            Machine = machine;

            RelatedIssues = await _context.Issues
                .Where(i => i.MachineId == id)
                .Include(i => i.Project)
                .OrderByDescending(i => i.ReportedDate)
                .ToListAsync();

            return Page();
        }
    }
}
