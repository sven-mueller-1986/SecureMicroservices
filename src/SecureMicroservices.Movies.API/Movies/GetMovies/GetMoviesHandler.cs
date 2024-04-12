namespace SecureMicroservices.Movies.API.Movies.GetMovies;

public record GetMoviesQuery() : IQuery<GetMoviesResult>;
public record GetMoviesResult(IEnumerable<Movie> Movies);

public class GetMoviesQueryHandler(IMovieRepository repository)
    : IQueryHandler<GetMoviesQuery, GetMoviesResult>
{
    public async Task<GetMoviesResult> Handle(GetMoviesQuery query, CancellationToken cancellationToken)
    {
        var movies = await repository.GetMoviesAsync(cancellationToken);

        return new GetMoviesResult(movies);
    }
}
