namespace SecureMicroservices.Movies.API.Movies.CreateMovie;

public record CreateMovieCommand(Movie Movie) : ICommand<CreateMovieResult>;
public record CreateMovieResult(Guid Id);

public class CreateMovieQueryHandler(IMovieRepository repository)
    : ICommandHandler<CreateMovieCommand, CreateMovieResult>
{
    public async Task<CreateMovieResult> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await repository.CreateMovieAsync(command.Movie, cancellationToken);

        return new CreateMovieResult(movie.Id);
    }
}
