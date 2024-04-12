using Microsoft.EntityFrameworkCore;

namespace EShopMicroservices.Services.Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();

        //await context.Database.MigrateAsync();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(MoviesDbContext context)
    {
        await SeedMoviesAsync(context);
    }

    private static async Task SeedMoviesAsync(MoviesDbContext context)
    {
        if (await context.Movies.AnyAsync())
            return;

        await context.Movies.AddRangeAsync(InitialData.Movies);
        await context.SaveChangesAsync();
    }
}
