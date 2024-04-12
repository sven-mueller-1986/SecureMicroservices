namespace SecureMicroservices.Movies.API.Movies.UpdateMovie;

public record UpdateMovieCommand(Movie Movie) : ICommand<UpdateMovieResult>;
public record UpdateMovieResult(bool IsSuccess);

public class UpdateMovieQueryHandler(IMovieRepository repository)
    : ICommandHandler<UpdateMovieCommand, UpdateMovieResult>
{
    public async Task<UpdateMovieResult> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await repository.UpdateMovieAsync(command.Movie, cancellationToken);

        if (movie is null)
            throw new MovieNotFoundException(command.Movie.Id);

        return new UpdateMovieResult(true);
    }
}
