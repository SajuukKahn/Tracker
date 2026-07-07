namespace Tracker.Pages.Projects
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Tracker.Contexts;
    using Tracker.Models;

    public class CreateModel : PageModel
    {
        private readonly TrackerContext _context;

        public CreateModel(TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; } = new() { Name = "" };

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Project.CreatedDate = DateTime.UtcNow;
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Project.Id });
        }
    }
}
