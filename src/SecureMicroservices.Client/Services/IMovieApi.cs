using Refit;
using SecureMicroservices.Client.Models;

namespace SecureMicroservices.Client.Services;

public interface IMovieApi
{
    [Post("/Movies")]
    Task<CreateMovieResponse> CreateMovie([Body(BodySerializationMethod.Serialized)] CreateMovieRequest request);

    [Get("/Movies")]
    Task<GetMoviesResponse> GetMovies();

    [Put("/Movies")]
    Task<UpdateMovieResponse> UpdateMovie([Body(BodySerializationMethod.Serialized)] UpdateMovieRequest request);

    [Delete("/Movies/{id}")]
    Task<DeleteMovieResponse> DeleteMovie(Guid id);
}
