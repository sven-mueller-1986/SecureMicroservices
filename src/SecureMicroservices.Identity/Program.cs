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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure HTTPS pipeline

app.UseIdentityServer();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
