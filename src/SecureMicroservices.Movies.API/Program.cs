using EShopMicroservices.Services.Ordering.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add Services to DI
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

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5059";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddDefaultPolicy("authorized", policy =>
        policy
            .RequireClaim("client_id", "movieClient")
            .RequireClaim("scope", "movieAPI"));

var app = builder.Build();

// Configure HTTPS pipeline

app.MapCarter();

await app.InitialiseDatabaseAsync();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
