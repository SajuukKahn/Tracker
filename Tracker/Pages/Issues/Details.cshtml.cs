namespace Tracker.Pages.Issues
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class DetailsModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        public Issue Issue { get; set; } = null!;

        [BindProperty]
        public string ResolutionNotes { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .Include(i => i.Project)
                .Include(i => i.Machine)
                .Include(i => i.ReportedBy)
                .Include(i => i.AssignedTo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (issue == null)
            {
                return NotFound();
            }

            Issue = issue;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            issue.IsResolved = true;
            issue.ResolvedDate = DateTime.UtcNow;
            issue.ResolutionNotes = ResolutionNotes;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = issue.Id });
        }
    }
}
