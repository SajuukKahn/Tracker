namespace Tracker.Pages.Projects
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class IndexModel : PageModel
    {
        private readonly TrackerContext _context;

        public IndexModel(TrackerContext context)
        {
            _context = context;
        }

        public List<Project> Projects { get; set; } = [];

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects
                .Include(p => p.Machines)
                .Include(p => p.People)
                .Include(p => p.Issues)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }
    }
}
