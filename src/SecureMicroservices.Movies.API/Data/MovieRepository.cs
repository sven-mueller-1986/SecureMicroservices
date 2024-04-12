using Microsoft.EntityFrameworkCore;

namespace SecureMicroservices.Movies.API.Data;

public class MovieRepository(MoviesDbContext dbContext)
    : IMovieRepository
{
    public async Task<Movie> CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        var createdMovie = dbContext.Movies.Add(movie);
        await dbContext.SaveChangesAsync();

        return createdMovie.Entity;
    }

    public async Task<Movie?> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await GetMovieByIdAsync(id);

        if(movie is not null)
        {
            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
        }

        return movie;
    }

    public async Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await dbContext.Movies.FindAsync(id);

        return movie;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Movies.ToListAsync();
    }

    public async Task<Movie?> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        var existingMovie = await GetMovieByIdAsync(movie.Id);

        if (existingMovie is not null)
        {
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Rating = movie.Rating;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.ImageUrl = movie.ImageUrl;
            existingMovie.Owner = movie.Owner;


            dbContext.Movies.Update(existingMovie);
            await dbContext.SaveChangesAsync();
        }

        return existingMovie;
    }
}
