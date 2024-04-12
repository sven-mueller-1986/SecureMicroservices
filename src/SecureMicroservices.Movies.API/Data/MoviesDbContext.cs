using Microsoft.EntityFrameworkCore;

namespace SecureMicroservices.Movies.API.Data;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    { }

    public DbSet<Movie> Movies { get; set; }


}
