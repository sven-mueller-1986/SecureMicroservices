using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Models;
using SecureMicroservices.Client.Services;

namespace SecureMicroservices.Client.Pages.Movies
{
    public class EditModel(IMovieApi movieApi)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await movieApi.UpdateMovie(new UpdateMovieRequest(Movie));

            return RedirectToPage("./Index");
        }

        private async Task<bool> MovieExists(Guid id)
        {
            return (await movieApi.GetMovies()).Movies.Any(e => e.Id == id);
        }
    }
}
