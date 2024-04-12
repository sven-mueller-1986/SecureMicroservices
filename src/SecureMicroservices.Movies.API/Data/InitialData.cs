namespace SecureMicroservices.Movies.API.Data;

public class InitialData
{
    public static List<Movie> Movies = new List<Movie>
    {
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Drama",
            Title = "The Shawshank Redemption",
            Rating = "9.3",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(1994, 5, 5),
            Owner = "alice",
        },
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Romance",
            Title = "Forrest Gump",
            Rating = "8.8",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(1994, 5, 5),
            Owner = "bob",
        },
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Drama",
            Title = "Pulp Fiction",
            Rating = "8.9",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(1994, 5, 5),
            Owner = "alice",
        },
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Biography",
            Title = "Schindler's List",
            Rating = "8.9",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(1993, 5, 5),
            Owner = "alice",
        },
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Action",
            Title = "The Dark Knight",
            Rating = "9.1",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(2008, 5, 5),
            Owner = "bob",
        },
        new Movie
        {
            Id = Guid.NewGuid(),
            Genre = "Crime",
            Title = "The Godfather",
            Rating = "9.2",
            ImageUrl = "image/src",
            ReleaseDate = new DateTime(1972, 5, 5),
            Owner = "alice",
        }
    };
}
