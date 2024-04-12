using EShopMicroservices.Services.Ordering.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services to DI
var assembly = typeof(Program).Assembly;

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddCarter(null, config =>
{
    var modules = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();
    config.WithModules(modules);
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddDbContext<MoviesDbContext>(options =>
{
    options.UseInMemoryDatabase("MovieDB");
});

var app = builder.Build();

// Configure HTTPS pipeline

app.MapCarter();

await app.InitialiseDatabaseAsync();

app.Run();
