namespace SecureMicroservices.Movies.API.Exceptions;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException(Guid id) : base($"Movie with ID: {id} was not found.")
    { }
}
