namespace SecureMicroservices.Movies.API.Movies.DeleteMovie;

public record DeleteMovieCommand(Guid Id) : ICommand<DeleteMovieResult>;
public record DeleteMovieResult(Movie? Movie);

public class DeleteMovieQueryHandler(IMovieRepository repository)
    : ICommandHandler<DeleteMovieCommand, DeleteMovieResult>
{
    public async Task<DeleteMovieResult> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await repository.DeleteMovieAsync(command.Id, cancellationToken);

        return new DeleteMovieResult(movie);
    }
}
