namespace Tracker.Pages.Issues
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class IndexModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        public List<Issue> Issues { get; set; } = [];
        public List<Issue> AllIssues { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; } = "open";

        public async Task OnGetAsync()
        {
            AllIssues = await _context.Issues
                .Include(i => i.Project)
                .Include(i => i.Machine)
                .Include(i => i.ReportedBy)
                .Include(i => i.AssignedTo)
                .ToListAsync();

            Issues = Filter switch
            {
                "open" => [.. AllIssues.Where(i => !i.IsResolved).OrderByDescending(i => i.Severity).ThenByDescending(i => i.ReportedDate)],
                "resolved" => [.. AllIssues.Where(i => i.IsResolved).OrderByDescending(i => i.ResolvedDate)],
                _ => AllIssues.OrderByDescending(i => i.ReportedDate).ToList()
            };
        }
    }
}
