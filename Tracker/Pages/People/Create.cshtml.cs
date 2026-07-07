namespace Tracker.Pages.People
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Tracker.Contexts;
    using Tracker.Models;

    public class CreateModel(TrackerContext context) : PageModel
    {
        private readonly TrackerContext _context = context;

        [BindProperty]
        public Person Person { get; set; } = new() { FirstName = "", LastName = "", Email = "" };

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
