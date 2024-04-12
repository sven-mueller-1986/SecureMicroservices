using SecureMicroservices.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add Services to DI

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Configuration.Clients)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddTestUsers(Configuration.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

// Configure HTTPS pipeline

app.UseIdentityServer();

app.Run();
