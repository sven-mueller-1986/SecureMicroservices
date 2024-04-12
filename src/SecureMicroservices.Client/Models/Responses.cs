namespace SecureMicroservices.Client.Models;

public record CreateMovieResponse(Guid Id);
public record GetMoviesResponse(IEnumerable<Movie> Movies);
public record UpdateMovieResponse(bool IsSuccess);
public record DeleteMovieResponse(Movie? Movie);