namespace Tracker.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class IndexModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        public List<Project> Projects { get; set; } = [];
        public Dictionary<int, int> ProjectIssueCounts { get; set; } = [];
        public Dictionary<int, int> ProjectOpenIssueCounts { get; set; } = [];

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects
                .Include(p => p.Machines)
                .Include(p => p.People)
                .Include(p => p.Issues)
                .ToListAsync();

            foreach (var project in Projects)
            {
                ProjectIssueCounts[project.Id] = project.Issues.Count;
                ProjectOpenIssueCounts[project.Id] = project.Issues.Count(i => !i.IsResolved);
            }
        }
    }
}
