using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Models;
using SecureMicroservices.Client.Services;

namespace SecureMicroservices.Client.Pages.Movies
{
    public class DeleteModel(IMovieApi movieApi)
        : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await movieApi.GetMovies();
            var movie = movieResponse.Movies.FirstOrDefault(x => x.Id == id.Value);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await movieApi.DeleteMovie(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
