using SecureMicroservices.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Services;

namespace SecureMicroservices.Client.Pages.Movies
{
    public class CreateModel(IMovieApi movieApi)
        : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            var result = await movieApi.CreateMovie(new CreateMovieRequest(Movie));
            Movie.Id = result.Id;

            return RedirectToPage("./Index");
        }
    }
}
