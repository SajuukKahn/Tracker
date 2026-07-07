namespace Tracker.Pages.People
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class IndexModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        public List<Person> People { get; set; } = [];
        public Dictionary<int, int> PersonProjectCounts { get; set; } = [];

        public async Task OnGetAsync()
        {
            People = await _context.People
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();

            var projects = await _context.Projects
                .Include(p => p.People)
                .ToListAsync();

            foreach (var person in People)
            {
                PersonProjectCounts[person.Id] = projects.Count(p => p.People.Any(pe => pe.Id == person.Id));
            }
        }
    }
}
