namespace SecureMicroservices.Movies.API.Data;

public interface IMovieRepository
{
    Task<Movie> CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default);
    Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Movie?> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default);
    Task<Movie?> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);
}
