using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Models;
using SecureMicroservices.Client.Services;

namespace SecureMicroservices.Client.Pages.Movies
{
    public class IndexModel(IMovieApi movieApi)
        : PageModel
    {
        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = (await movieApi.GetMovies()).Movies.ToList();
        }
    }
}
