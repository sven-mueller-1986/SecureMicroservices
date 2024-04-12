namespace SecureMicroservices.Movies.API.Movies.DeleteMovie;

//public record DeleteMovieRequest(Guid Id);
public record DeleteMovieResponse(Movie? Movie);

public class DeleteMovieEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Movies/{id}", async (Guid id, ISender mediator) =>
        {
            var result = await mediator.Send(new DeleteMovieCommand(id));

            var response = result.Adapt<DeleteMovieResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization();
    }
}
