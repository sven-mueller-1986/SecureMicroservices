namespace SecureMicroservices.Movies.API.Movies.CreateMovie;

public record CreateMovieRequest(Movie Movie);
public record CreateMovieResponse(Guid Id);

public class CreateMovieEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Movies", async (CreateMovieRequest request, ISender mediator) =>
        {
            var command = request.Adapt<CreateMovieCommand>();

            var result = await mediator.Send(command);

            var response = result.Adapt<CreateMovieResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization();
    }
}
