namespace Tracker.Pages.Projects
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Tracker.Contexts;
    using Tracker.Models;

    public class AddPersonModel : PageModel
    {
        private readonly TrackerContext _context;

        public AddPersonModel(TrackerContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = null!;

        [BindProperty]
        public int ProjectId { get; set; }

        [BindProperty]
        public int PersonId { get; set; }

        public SelectList AvailablePeople { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.People)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound();
            }

            Project = project;
            ProjectId = project.Id;

            var allPeople = await _context.People.ToListAsync();
            var availablePeople = allPeople
                .Where(p => !project.People.Any(pp => pp.Id == p.Id))
                .Select(p => new { p.Id, FullName = $"{p.FirstName} {p.LastName}" })
                .ToList();

            AvailablePeople = new SelectList(availablePeople, "Id", "FullName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var project = await _context.Projects
                .Include(p => p.People)
                .FirstOrDefaultAsync(p => p.Id == ProjectId);

            if (project == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(PersonId);

            if (person == null)
            {
                return NotFound();
            }

            project.People.Add(person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = ProjectId });
        }
    }
}
