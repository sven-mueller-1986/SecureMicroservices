using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Models;
using SecureMicroservices.Client.Services;

namespace SecureMicroservices.Client.Pages.Movies
{
    public class DetailsModel(IMovieApi movieApi)
        : PageModel
    {
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieResponse = await movieApi.GetMovies();
            var movie = movieResponse.Movies.FirstOrDefault(m => m.Id == id);
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
    }
}
