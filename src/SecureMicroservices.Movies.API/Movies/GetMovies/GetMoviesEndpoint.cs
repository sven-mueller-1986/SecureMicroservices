namespace SecureMicroservices.Movies.API.Movies.GetMovies;

//public record GetMoviesRequest();
public record GetMoviesResponse(IEnumerable<Movie> Movies);

public class GetMoviesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Movies", async (ISender mediator) =>
        {
            var result = await mediator.Send(new GetMoviesQuery());

            var response = result.Adapt<GetMoviesResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization();
    }
}
