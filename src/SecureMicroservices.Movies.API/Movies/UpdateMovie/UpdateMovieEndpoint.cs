namespace SecureMicroservices.Movies.API.Movies.UpdateMovie;

public record UpdateMovieRequest(Movie Movie);
public record UpdateMovieResponse(bool IsSuccess);

public class UpdateMovieEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/Movies", async (UpdateMovieRequest request, ISender mediator) =>
        {
            var command = request.Adapt<UpdateMovieCommand>();

            var result = await mediator.Send(command);

            var response = result.Adapt<UpdateMovieResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization();
    }
}
